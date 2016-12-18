﻿using FileSystemSerialization.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Interfaces
{
    interface IConfigurable
    {
        SerializeType ReadConfigurationFile();
    }
}
