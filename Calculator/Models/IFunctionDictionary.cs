using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal interface IFunctionDictionary
    {
        public void Add(Function func);
        public Function GetFunction(string name);
    }
}
