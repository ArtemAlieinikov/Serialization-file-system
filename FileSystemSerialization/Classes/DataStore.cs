using FileSystemSerialization.Classes.DeserializationModules;
using FileSystemSerialization.Classes.ModulsFactory;
using FileSystemSerialization.Classes.SerializeModules;
using FileSystemSerialization.Enums;
using FileSystemSerialization.Interfaces;
using FileSystemSerialization.Interfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes
{
    class DataStore : IStorable
    {
        private DataDeserializer readModule;
        private DataSerializer writeModule;
        private IConfigurable checkModule;
        private List<Person> entitySet = new List<Person>();

        public IConfigurable CheckModule
        {
            get
            {
                return checkModule;
            }
            protected set
            {
                checkModule = value;
            }
        }

        public DataStore(IConfigurable checkModule)
        {
            CheckModule = checkModule;
            CreateModules();
        }

        private void CreateModules()
        {
            SerializeType serializeType = CheckModule.ReadConfigurationFile();

            if (serializeType == SerializeType.Bin)
            {
                BinaryModulesFactory binFactory = new BinaryModulesFactory();

                readModule = binFactory.CreateDeserializer();
                writeModule = binFactory.CreateSerializer();
            }
            else if (serializeType == SerializeType.Xml)
            {
                XmlModulesFactory xmlFactory = new XmlModulesFactory();

                readModule = xmlFactory.CreateDeserializer();
                writeModule = xmlFactory.CreateSerializer();
            }
            else
            {
                throw new IncorrectSerializeType("Serialize type is incorrect. Data won't be save.");
            }
        }

        public void ReadData()
        {
            entitySet = readModule.DataDeserialize();
        }

        public void WriteData()
        {
            writeModule.DataSerialize(entitySet);
        }

        public void CreatePerson(string name, int age, string phoneNumber)
        {
            int newId = entitySet.Count + 1;
            Person newPerson = new Person(newId, name, age, phoneNumber);
            entitySet.Add(newPerson);
        }

        public void DeletePerson(int id)
        {
            if ((id >= 1) && (id <= entitySet.Count))
            {
                --id;
                entitySet.RemoveAt(id);
            }
            else
            {
                throw new ArgumentException("Wrong id.");
            }
        }

        public List<Person> ShowAll()
        {
            return entitySet;
        }

        public Person ShowOnePerson(int id)
        {
            if ((id >= 1) && (id <= entitySet.Count))
            {
                return entitySet[id - 1];
            }
            else
            {
                throw new ArgumentException("Wrong id.");
            }
        }
    }
}
