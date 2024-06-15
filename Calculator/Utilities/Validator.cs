using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utilities
{
    public static class Validator
    {
        public static bool CanParseUserFunction(string functionDef)
        {
            throw new NotImplementedException();
            // only 1 '='
            // no special symbols except '='
            //проерять стоит ли открывающая скобка перед закрывающей 
            //стоит ли равно после закрывающей скобки
            //если стоит оператор, то после ли равно

            //количество переменных = кол-во запятых + 1
            //колличество переменных слева = кол-ву переменных справа 

		}


		public static bool CanParseUserVariable(string variableDef) // xw1 = 5
		{
			throw new NotImplementedException();
			// only 1 '='
			// only 1 number
			// only 1 string, numbers included
			// no special symbols except '='
		}


		public static bool CanParseMathExpression(string expression) // func12 (x,y) = x + y
		{
			throw new NotImplementedException();
		}


		private static int CountSymbolOccurrences(string str, char symbol)
		{
			return str.ToCharArray().Count(item => item == symbol);
		}

		// -1 equals error
		private static int CountNumbers(string str)
		{
			int indexOfEq = str.IndexOf('=');
			if (indexOfEq == -1)
			{
				return -1;
			}

			var trimmed = str.Substring(indexOfEq+1, str.Length - indexOfEq);

			var partsOfNumber = new List<char>();

			for (int i = 0; i < trimmed.Length; i++)
			{
				if (trimmed[i] == '-' || trimmed[i] == '+')
				{
					if (partsOfNumber.Contains('-') || partsOfNumber.Contains('+')) return -1;

					partsOfNumber.Add(trimmed[i]);
					continue;
				}

				if ((trimmed[i] == ',' || trimmed[i] == '.') && (partsOfNumber.Contains('-') || partsOfNumber.Contains('+')))
				{
					if (partsOfNumber.Contains(',') || partsOfNumber.Contains('.')) return -1;

					partsOfNumber.Add(trimmed[i]);
					continue;

				}


			}
		}

		private static int CountWords(string str)
		{
			throw new NotImplementedException();
		}
    }
}
