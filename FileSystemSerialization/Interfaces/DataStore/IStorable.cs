using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Interfaces.DataStore
{
    interface IStorable : IDataReadable, IDataWritable, IPersonCreatable, IPersonDelete, IShow
    {
    }
}
