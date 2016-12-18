using FileSystemSerialization.Interfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Interfaces
{
    interface IBuilderable
    {
        IConfigurable CreateConfigureReader();
        IStorable CreateDataStore(IConfigurable checkModule);
    }
}
