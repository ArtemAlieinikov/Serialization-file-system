using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.DeserializationModules
{
    class BinaryDeserializer : DataDeserializer
    {
        public override List<Person> DataDeserialize()
        {
            List<Person> result = new List<Person>();
            BinaryFormatter binarySerializer = new BinaryFormatter();

            using (FileStream fStream = new FileStream("BinData.txt", FileMode.Open))
            {
                result = (List<Person>)binarySerializer.Deserialize(fStream);
            }

            return result;
        }
    }
}
