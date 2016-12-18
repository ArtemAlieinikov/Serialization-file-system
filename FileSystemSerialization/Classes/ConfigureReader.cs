using FileSystemSerialization.Enums;
using FileSystemSerialization.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSystemSerialization.Classes
{
    class ConfigureReader : IConfigurable
    {
        private bool CheckOptionFile()
        {
            if (File.Exists("option.ini"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateOptionFile(bool isExists)
        {
            if (!isExists)
            {
                using (StreamWriter writer = new StreamWriter("option.ini"))
                {
                    writer.WriteLine("xml");
                    //writer.Write("xml");
                }
                Console.WriteLine("Option file had not existed, new default file has been created,");
                Console.WriteLine("To continue please press ENTER");
                Console.ReadLine();
            }
            else { }
        }

        public SerializeType ReadConfigurationFile()
        {
            CreateOptionFile(CheckOptionFile());

            string result;

            using (StreamReader sReader = new StreamReader("option.ini"))
            {
                result = sReader.ReadToEnd();
            }

            result = result.Trim();

            if ("bin" == result.ToLower())
            {
                return SerializeType.Bin;
            }
            else if ("xml" == result.ToLower())
            {
                return SerializeType.Xml;
            }
            else
            {
                return SerializeType.Unsupported;
            }
        }
    }
}
