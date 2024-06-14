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

        public Variable(string Expression)
        {
            ParseExpression(Expression);
        }

        public Variable(string Expression, VariableDictionary dict)
        {
            ParseExpression(Expression);
            dict.Add(this);
        }

        private void ParseExpression(string Expression)
        {
            this.name = Expression.Remove(Expression.IndexOf('='), Expression.Length - Expression.IndexOf('='));
            this.value = Convert.ToDouble(Expression.Substring(Expression.IndexOf('=') + 1, Expression.Length - Expression.IndexOf("=")));
        }

        public string GetToStringValue()
        {
            return Convert.ToString(this.value);
        }
    }
}
