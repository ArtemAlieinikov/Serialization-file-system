using FileSystemSerialization.Classes.DeserializationModules;
using FileSystemSerialization.Classes.SerializeModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.ModulsFactory
{
    abstract class ModulsFactory
    {
        public abstract DataSerializer CreateSerializer();
        public abstract DataDeserializer CreateDeserializer();
    }
}
