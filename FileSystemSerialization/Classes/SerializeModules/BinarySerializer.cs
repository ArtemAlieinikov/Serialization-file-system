using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.SerializeModules
{
    class BinarySerializer : DataSerializer
    {
        public override void DataSerialize(List<Person> personList)
        {
            BinaryFormatter binarySerializer = new BinaryFormatter();
            using (FileStream fStream = new FileStream("BinData.txt", FileMode.Create))
            {
                binarySerializer.Serialize(fStream, personList);
            }
        }
    }
}
