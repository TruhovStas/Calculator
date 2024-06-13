using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal class VariableDictionary : IVariableDictionary
    {
        private Dictionary<string, Variable> dict;
        VariableDictionary()
        {
            dict = new Dictionary<string, Variable>();
        }
        public void Add(Variable func)
        {
            dict[func.Name] = func;
        }
        public Variable GetVariable(string name)
        {
            return dict[name];
        }
    }
}
