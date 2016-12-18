using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes
{
    [Serializable]
    public class Person
    {
        private int id;
        private string name;
        private int age;
        private string phoneNumber;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id cannot be less than zero.");
                }
                else
                {
                    id = value;
                }
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be less or equal than zero.");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                string pattern = @"^\(\d{3}\)\d{7}$";
                if (Regex.IsMatch(value, pattern))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Phone number in incorrect format.");
                }
            }
        }

        public Person()
        { }

        public Person(int id, string name, int age, string phoneNumber)
        {
            Id = id;
            this.name = name;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return String.Format("|   {0} \t|   {1} \t|\t {2} \t|\t {3} \t|", Id, Name, Age, PhoneNumber);
        }
    }
}
