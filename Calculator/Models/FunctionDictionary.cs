using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class FunctionDictionary : IFunctionDictionary
    {

        private Dictionary<string, Function> dict;
        public FunctionDictionary()
        {
            dict = new Dictionary<string, Function>();
        }
        public void Add(Function func)
        {
            dict[func.Name] = func;
        }
        public Function GetFunction(string name) 
        {
            return dict[name];
        }
        public List<Function> GetAllFunctions()
        {
            List<Function> list = [.. dict.Values];
            return list;
        }
    }
}
