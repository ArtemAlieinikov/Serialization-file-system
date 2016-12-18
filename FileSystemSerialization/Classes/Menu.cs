using FileSystemSerialization.Interfaces;
using FileSystemSerialization.Interfaces.DataStore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes
{
    class Menu
    {
        private IBuilderable builder;
        private IConfigurable checkModule;
        private IStorable dataStore;
        private string[] commands;

        public Menu()
        {
            builder = new Builder();
        }

        public void Run()
        {
            try
            {
                checkModule = builder.CreateConfigureReader();
                dataStore = builder.CreateDataStore(checkModule);
                dataStore.ReadData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("PRESS ENTER");
                Console.ReadLine();
            }

            while (true)
            {
                try
                {
                    Console.Clear();
                    ShowCommands();

                    if (commands == null)
                    {
                        commands = Console.ReadLine().Split(new char[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else { }

                    if (commands.Length < 1)
                    {
                        throw new ArgumentException("Input command is incorrect");
                    }
                    else if ((commands.Length == 1) && ("exit" == commands[0].ToLower()))
                    {
                        dataStore.WriteData();
                        break;
                    }
                    else if (commands.Length > 3)
                    {
                        throw new ArgumentException("Input command is incorrect");
                    }
                    else if (commands.Length == 2)
                    {
                        if ("show" == commands[0].ToLower())
                        {
                            GoToShowCommands();
                            commands = null;
                        }
                        else
                        {
                            throw new ArgumentException("Input command is incorrect");
                        }
                    }
                    else if (commands.Length == 3)
                    {
                        GoToCreateDeleteCommands();
                        commands = null;
                    }
                    else
                    {
                        throw new ArgumentException("Input command is incorrect");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    ShowCommands();
                    Console.WriteLine(e.Message);
                    commands = null;
                    commands = Console.ReadLine().Split(new char[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        private void ShowCommands()
        {
            Console.WriteLine("COMMAND LIST");
            Console.WriteLine("Serialize type - {0}", checkModule.ReadConfigurationFile());
            Console.WriteLine();
            Console.WriteLine("Create a person");
            Console.WriteLine("\t - create_new_person");
            Console.WriteLine("Delete a person by id");
            Console.WriteLine("\t - delete_person_id");
            Console.WriteLine("Show all persons");
            Console.WriteLine("\t - show_all");
            Console.WriteLine("Show person by id");
            Console.WriteLine("\t - show_id");
            Console.WriteLine("Exit programm");
            Console.WriteLine("\t - exit");
        }

        private void GoToShowCommands()
        {
            if ("all" == commands[1].ToLower())
            {
                if (dataStore is IShow)
                {
                    IShow store = (IShow)dataStore;
                    Console.Clear();
                    Console.WriteLine("|   ID\t|   NAME\t|\tAGE\t|\tPHONE\t\t|");
                    Console.WriteLine(new string('-', 65));

                    foreach (Person person in store.ShowAll())
                    {
                        Console.WriteLine(person);
                    }

                    Console.ReadLine();
                }
                else
                {
                    throw new ArgumentException("Wrong object");
                }
            }
            else if (Int32.Parse(commands[1]) > 0)
            {
                if (dataStore is IShow)
                {
                    IShow store = (IShow)dataStore;
                    Console.Clear();
                    Console.WriteLine("|   ID\t|   NAME\t|\tAGE\t|\tPHONE\t\t|");
                    Console.WriteLine(new string('-', 65));
                    Console.WriteLine(store.ShowOnePerson(Int32.Parse(commands[1])));
                    Console.ReadLine();
                }
                else
                {
                    throw new ArgumentException("Wrong object");
                }
            }
            else
            {
                throw new ArgumentException("Input command is incorrect");
            }
        }

        private void GoToCreateDeleteCommands()
        {
            if ("create" == commands[0].ToLower())
            {
                CreateEntity();
            }
            else if ("delete" == commands[0].ToLower())
            {
                if ("person" == commands[1])
                {
                    int id = Int32.Parse(commands[2]);

                    if (id > 0)
                    {
                        DeleteEntity(id);
                    }
                    else
                    {
                        throw new ArgumentException("Id can not be less than zero");
                    }
                }
                else
                {
                    throw new ArgumentException("Input command is incorrect");
                }
            }
            else
            {
                throw new ArgumentException("Input command is incorrect");
            }
        }

        private void CreateEntity()
        {
            if ("person" == commands[2].ToLower())
            {
                int age;
                string name, phoneNumber;
                Console.Clear();
                Console.Write("Please write person NAME : ");
                name = Console.ReadLine();
                Console.Write("Please write person AGE : ");
                age = Int32.Parse(Console.ReadLine());
                Console.Write("Please write person PHONE NUMBER in format - (xxx)xxxxxxx : ");
                phoneNumber = Console.ReadLine();

                dataStore.CreatePerson(name, age, phoneNumber);
            }
            else
            {
                throw new ArgumentException("Input command is incorrect");
            }
        }

        private void DeleteEntity(int id)
        {
            dataStore.DeletePerson(id);
        }
    }
}
