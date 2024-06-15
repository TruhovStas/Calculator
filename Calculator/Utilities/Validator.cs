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
		private static List<string> standartOperators = new List<string>() { "(", ")", "+", "-", "*", "/", "^" };

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
			List<string> tokens = SeparateEquation(variableDef);
			if (tokens.Count != 3) return false;
			if (CountSymbolOccurrences(tokens, '=') != 1) return false;
			if (CountNumbers(tokens) != 1) return false;
			if (CountWords(tokens) != 1) return false;
			return true;
			// only 1 '='
			// only 1 number
			// only 1 string, numbers included
			// no special symbols except '='
		}


		public static bool CanParseMathExpression(string expression) // func12 (x,y) = x + y
		{
			throw new NotImplementedException();
		}


		private static int CountSymbolOccurrences(List<string> tokens, char symbol)
		{
			return tokens.Count(item => item.Equals(symbol.ToString()));
		}


		private static int CountNumbers(List<string> tokens)
		{
			int res = 0;
			foreach (var item in tokens)
			{
				if (int.TryParse(item, out int _)) res++;
			}

			return res;
		}


		private static int CountWords(List<string> tokens)
		{
			int res = 0;
			foreach (var item in tokens)
			{
				int curLen = 0;
				foreach (var s in item)
				{
					if (char.IsDigit(s) || char.IsLetter(s)) curLen++;
				}

				if (curLen == item.Length && OnlyNumbers(item))
				{
					res++;
				}
			}

			return res;

			bool OnlyNumbers(string str)
			{
				return str.ToCharArray().Count(char.IsDigit) == str.Length;
			}
		}

		private static List<string> SeparateEquation(string equation)
		{
			List<string> result = new List<string>();

			int pos = 0;
			while (pos < equation.Length)
			{
				string s = string.Empty + equation[pos];
				if (!standartOperators.Contains(equation[pos].ToString()))
				{
					if (Char.IsDigit(equation[pos]))
						for (int i = pos + 1;
						     i < equation.Length &&
						     (Char.IsDigit(equation[i]) || equation[i] == ',');
						     i++)
							s += equation[i];
					else if (Char.IsLetter(equation[pos]))
						for (int i = pos + 1;
						     i < equation.Length &&
						     (Char.IsLetter(equation[i]) || Char.IsDigit(equation[i]));
						     i++)
							s += equation[i];
				}

				result.Add(s);
				pos += s.Length;
			}

			return result.Where(i => !string.IsNullOrWhiteSpace(i)).ToList();
		}
	}
}
