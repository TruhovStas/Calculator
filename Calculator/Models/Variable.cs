using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    internal class Variable
    {
        private string name;

        private double value;
        public string Name { get { return name; } }
        public double Value { get { return value; } }

        Variable(string Expression)
        {
            this.name = Expression.Remove(Expression.IndexOf('='), Expression.Length - Expression.IndexOf('='));
            this.value = Convert.ToDouble(Expression.Substring(Expression.IndexOf('='), Expression.Length - Expression.IndexOf("=")));
        }

        Variable(string Expression, VariableDictionary dict)
        {
            this.name = Expression.Remove(Expression.IndexOf('='), Expression.Length - Expression.IndexOf('='));
            this.value = Convert.ToDouble(Expression.Substring(Expression.IndexOf('='), Expression.Length - Expression.IndexOf("=")));
            dict.Add(this);
        }

        public string GetToStringValue()
        {
            return Convert.ToString(this.value);
        }
    }
}
