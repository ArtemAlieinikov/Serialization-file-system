using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Classes
{
    class IncorrectSerializeType : Exception
    {
        public IncorrectSerializeType(string message)
            : base(message)
        { }
    }
}
