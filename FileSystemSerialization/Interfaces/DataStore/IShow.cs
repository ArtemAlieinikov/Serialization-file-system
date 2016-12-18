using FileSystemSerialization.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSerialization.Interfaces.DataStore
{
    interface IShow
    {
        List<Person> ShowAll();
        Person ShowOnePerson(int id);
    }
}
