using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal interface IVariableDictionary
    {
        public void Add(Variable func);
        public Variable GetVariable(string name);
    }
}
