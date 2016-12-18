using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileSystemSerialization.Classes.SerializeModules
{
    class XmlDataSerializer : DataSerializer
    {
        public override void DataSerialize(List<Person> personList)
        {
            XmlSerializer serializer = new XmlSerializer(personList.GetType());
            using (FileStream fStream = new FileStream("XmlData.txt", FileMode.Create))
            {
                serializer.Serialize(fStream, personList);
            }
        }
    }
}
