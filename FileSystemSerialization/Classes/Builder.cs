using FileSystemSerialization.Interfaces;
using FileSystemSerialization.Interfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes
{
    class Builder : IBuilderable
    {
        public IConfigurable CreateConfigureReader()
        {
            return new ConfigureReader();
        }
        public IStorable CreateDataStore(IConfigurable checkModule)
        {
            return new DataStore(checkModule);
        }
    }
}
