using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.DeserializationModules
{
    abstract class DataDeserializer
    {
        public abstract List<Person> DataDeserialize();
    }
}
