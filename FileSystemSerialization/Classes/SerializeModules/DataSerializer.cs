using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.SerializeModules
{
    abstract class DataSerializer
    {
        public abstract void DataSerialize(List<Person> personList);
    }
}
