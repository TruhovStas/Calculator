using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utilities
{
    public class Parser
    {
        private VariavleDictionary variableDictionary;
        private FunctionDictionary functionDictionary;

        public Parser() { }
        /// <summary>
        /// Method <c>Parse</c> is replacing all variable with their values and all functions with their definitions.
        /// </summary>
        public void Parse(string Expression)
        {
            Expression = Expression.Replace(" ", "");
            if(AddInDictionary(Expression)) 
            {
                return;
            }
            variableDictionary = new VariavleDictionary();
            functionDictionary = new FunctionDictionary();
        }
        // public for testing, should be private

        /// <summary>
        /// Method <c>ReplaceVariables</c> is replacing all variables with their values.
        /// </summary>
        public string ReplaceVariables(string Expression)
        {
            int left_border = 0;
            int size = 0;
            bool letterFound = false;
            for (int i = 0; i < Expression.Length; ++i)
            {
                if (!letterFound && char.IsLetter(Expression[i]))
                {
                    letterFound = true;
                    left_border = i;
                    size = 1;
                }
                else if (letterFound && char.IsLetter(Expression[i]))
                {
                    size += 1;
                }
                else if (letterFound && Expression[i] == '(')
                {
                    letterFound = false;
                }
                else if (letterFound && !char.IsLetter(Expression[i]))
                {
                    string before_insertion = Expression.Substring(0, left_border);

                    string after_insertion = Expression.Substring(left_border + size);

                    Expression = before_insertion + variableDictionary.GetVariable(Expression.Substring(left_border, size)) + after_insertion;

                    letterFound = false;
                }
            }

            return Expression;
        }

        /// <summary>
        /// Method <c>ReplaceFunctions</c> is replacing all functions with their definitions.
        /// </summary>
        public string ReplaceFunctions(string Expression)
        {
            int left_border = 0;
            int size = 0;
            bool letterFound = false;
            for (int i = 0; i < Expression.Length; ++i)
            {
                if (!letterFound && char.IsLetter(Expression[i]))
                {
                    letterFound = true;
                    left_border = i;
                    size = 1;
                }
                else if (letterFound && char.IsLetter(Expression[i]))
                {
                    size += 1;
                }
                else if (letterFound && Expression[i] == '(')
                {
                    string name = Expression.Substring(left_border, size);
                    ++size;

                    string parametres = "";

                    for (int j = i + 1; ; ++j)
                    {
                        ++size;

                        if (Expression[j] == ')')
                        {
                            parametres = Expression.Substring(i + 1, j - i - 1);
                            i = j;
                            break;
                        }
                    }

                    string before_insertion = Expression.Substring(0, left_border);

                    string after_insertion = Expression.Substring(left_border + size);

                    List<string> string_values = parametres.Split(',').ToList();

                    List<double> values = new List<double>();

                    for(int j = 0; j < string_values.Count; ++j)
                    {
                        values.Add(Convert.ToDouble(string_values[j]));
                    }

                    Expression = before_insertion + '(' + functionDictionary.GetFunction(name).ReplaceVariables(values) + ')' + after_insertion;

                    letterFound = false;
                }
                else if (letterFound && !char.IsLetter(Expression[i]))
                {
                    letterFound = false;
                }
            }

            return Expression;
        }

        /// <summary>
        /// Method <c>AddInDictionary</c> puts the function and variables into dictionary .
        /// </summary>
        private bool AddInDictionary(string Expression)
        {

            if (Expression.Contains('=') && Expression.IndexOf('=') != Expression.Length - 1 && Expression.Contains('('))
            {
                Function Func = new Function(Expression, functionDictionary);
                return true;
            }
            else if (Expression.Contains('=') && Expression.IndexOf('=') != Expression.Length - 1 && !Expression.Contains('('))
            {
                Variable Func = new Variable(Expression, variableDictionary);
                return true;
            }

            return false;
        }
    }
}
