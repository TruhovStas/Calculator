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

        public string ReplaceVariables(List<double> values)
        {
            if (values.Count != Parameters.Count) throw new ArgumentException("Количество параметров в функции не совпадает, должно быть " + Parameters.Count);
            string replaced_body = body;
            int left_border = 0;
            int size = 0;
            bool letterFound = false;
            for (int i = 0; i < replaced_body.Length; ++i)
            {
                if (!letterFound && char.IsLetter(replaced_body[i]))
                {
                    letterFound = true;
                    left_border = i;
                    size = 1;
                }
                else if (letterFound && char.IsLetter(replaced_body[i]))
                {
                    size += 1;
                }
                if (letterFound && (!char.IsLetter(replaced_body[i]) || i == replaced_body.Length - 1))
                {
                    string before_insertion = replaced_body.Substring(0, left_border);

                    string after_insertion = replaced_body.Substring(left_border + size);

                    string replace = values[parameters.IndexOf(replaced_body.Substring(left_border, size))].ToString();
                    
                    replaced_body = before_insertion + replace + after_insertion;

                    letterFound = false;

                    i = left_border + replace.Length - 1;
                }
            }

            return replaced_body;
        }
    }
}
