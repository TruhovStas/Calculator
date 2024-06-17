using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public interface IVariableDictionary
    {
        void Add(Variable func);
        Variable GetVariable(string name);
    }
}
