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

            this.name = Expression.Remove(Expression.IndexOf('('));
            this.body = Expression.Substring(Expression.IndexOf('=') + 1);
            this.parameters = Expression.Substring(Expression.IndexOf('(') + 1, Expression.IndexOf(')') - Expression.IndexOf('(') - 1).Replace(" ", "").Split(',').ToList();
        }

        public string ReplaceVariable(List<double> values)
        {
            string replaced_body = body;
            int left_border = 0;
            int size = 0;
            bool letterFound = false;
            for (int i = 0; i < body.Length; ++i)
            {
                if (!letterFound && char.IsLetter(body[i]))
                {
                    letterFound = true;
                    left_border = i;
                    size = 1;
                }
                else if (letterFound && char.IsLetter(body[i]))
                {
                    size += 1;
                }
                else if (letterFound && !char.IsLetter(body[i]))
                {
                    string before_insertion = replaced_body.Substring(0, left_border);

                    string after_insertion = replaced_body.Substring(left_border + size);

                    replaced_body = before_insertion + values[parameters.IndexOf(replaced_body.Substring(left_border, size - 1))] + after_insertion;

                    letterFound = false;
                }
            }

            return replaced_body;
        }
    }
}
