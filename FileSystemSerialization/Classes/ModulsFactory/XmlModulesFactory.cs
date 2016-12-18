using FileSystemSerialization.Classes.DeserializationModules;
using FileSystemSerialization.Classes.SerializeModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes.ModulsFactory
{
    class XmlModulesFactory : ModulsFactory
    {
        public override DataDeserializer CreateDeserializer()
        {
            return new XmlDeserializer();
        }

        public override DataSerializer CreateSerializer()
        {
            return new XmlDataSerializer();
        }
    }
}
