using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Function
    {
        private string name = null;

        private List<string> parameters;

        private string body;

        public string Name { get { return name; } }

        public string Body { get { return body; } }

        public List<string> Parameters { get { return parameters; } }

        public Function(string Expression)
        {
            ParseExpression(Expression);
        }

        public Function(string Expression, FunctionDictionary dict)
        {
            ParseExpression(Expression);
            dict.Add(this);
        }
        private void ParseExpression(string Expression)
        {
            this.name = Expression.Remove(Expression.IndexOf('('), Expression.Length - Expression.IndexOf('('));
            this.body = Expression.Substring(Expression.IndexOf('='), Expression.Length - Expression.IndexOf('='));

            this.parameters = Expression.Substring(Expression.IndexOf('('), Expression.IndexOf(')') - Expression.IndexOf('(')).Replace(" ", "").Split(',').ToList();

        }
    }
}
