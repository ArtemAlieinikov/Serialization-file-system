using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileSystemSerialization.Classes.DeserializationModules
{
    class XmlDeserializer : DataDeserializer
    {
        public override List<Person> DataDeserialize()
        {
            List<Person> result = new List<Person>();
            XmlSerializer xmlSerializer = new XmlSerializer(result.GetType());

            using (FileStream fStream = new FileStream("XmlData.txt", FileMode.Open))
            {
                result = (List<Person>)xmlSerializer.Deserialize(fStream);
            }

            return result;
        }
    }
}
