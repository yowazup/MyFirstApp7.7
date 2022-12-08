using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    public class Human<T>
    {
        public T Field;
    }
    public class Client<T> : Human<string>
    {
        public T Name { get; set; }

    }
}
