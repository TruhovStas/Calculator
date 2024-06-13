using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utilities
{
    public class Parser
    {
        private VariavleDictionary variableDictionary;
        private FunctionDictionary functionDictionary;

        public Parser();
        public void Parse(string Expression)
        {
            variableDictionary = new VariavleDictionary();
            functionDictionary = new FunctionDictionary();
        }
        // public for testing, should be private

        /// <summary>
        /// Method <c>ReplaceVariables</c> is replacing all variables with their values.
        /// </summary>
        public string ReplaceVariables(string Expression)
        {
            string name = "";
            bool letterFound = false;
            for (int i = 0; i < Expression.Length; ++i)
            {
                if (!letterFound && Expression[i].IsLetter)
                {
                    letterFound = true;
                    name += Expression[i];
                }
                else if (letterFound && Expression[i] == '(')
                {
                    letterFound = false;
                    name = "";
                }
                else if (letterFound && !Expression[i].IsLetter)
                {
                    try
                    {
                        Variable variable = variableDictionary.GetVariable();
                        Expression.Replace(name, variable.Value.ToString());
                        name = "";
                        letterFound = false;
                    }
                    catch (Exception e)
                    {
                        // TODO: Обработать ошибку
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Method <c>ReplaceFunctions</c> is replacing all functions with their definitions.
        /// </summary>
        public string ReplaceFunctions(string Expression)
        {
            string name = "";
            bool letterFound = false;
            for (int i = 0; i < Expression.Length; ++i)
            {
                if (!letterFound && Expression[i].IsLetter)
                {
                    letterFound = true;
                    name += Expression[i];
                }
                else if (letterFound && !Expression[i].IsLetter)
                {
                    letterFound = false;
                    name = "";
                }
                else if (letterFound && Expression[i] == '(')
                {
                    try
                    {
                        Function function = functionDictionary.GetFunction();
                        string body = function.ReplaceVariables(); // TODO: написать реализацию метода
                        Expression.Replace(name, body);
                        name = "";
                        letterFound = false;
                    }
                    catch (Exception e)
                    {
                        // TODO: Обработать ошибку
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Method <c>AddInDictionary</c> puts the function and variables into dictionary .
        /// </summary>

        void AddInDictionary(string Expression)
        {

            if (Expression.Contains('=') && Expression.Contains('('))
            {
                Function Func = new Function(Expression, functionDictionary);
            }
            else if (Expression.Contains('=') && !Expression.Contains('('))
            {
                Variable Func = new Variable(Expression, variableDictionary);
            }

        }
    }
}
