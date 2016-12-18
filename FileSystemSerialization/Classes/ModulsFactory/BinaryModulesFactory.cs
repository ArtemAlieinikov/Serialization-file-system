using FileSystemSerialization.Classes.DeserializationModules;
using FileSystemSerialization.Classes.SerializeModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.ModulsFactory
{
    class BinaryModulesFactory : ModulsFactory
    {
        public override DataDeserializer CreateDeserializer()
        {
            return new BinaryDeserializer();
        }

        public override DataSerializer CreateSerializer()
        {
            return new BinarySerializer();
        }
    }
}
