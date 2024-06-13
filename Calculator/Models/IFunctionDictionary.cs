using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public interface IFunctionDictionary
    {
        void Add(Function func);
        Function GetFunction(string name);
    }
}
