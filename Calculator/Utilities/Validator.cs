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
		private static readonly List<string> StandartOperators = new List<string>() { "(", ")", "+", "-", "*", "/", "^" };

		public static bool CanParseUserFunction(string functionDef)
		{
			List<string> tokens = SeparateEquation(functionDef);

			// only 1 '=' +
			if (CountSymbolOccurrences(tokens, '=',0, tokens.Count - 1) != 1) return false;

			// no special symbols except '=' +
			if (CountSymbolOccurrencesWithExcept(tokens, '=') != 0) return false;

			// correct brackets
			if (!AllBracketsCorrect(tokens)) return false;
			if(tokens.IndexOf("(") == -1 || tokens.IndexOf(")") == -1 || tokens.IndexOf("(") > tokens.IndexOf(")")) return false;

			// '=' after ')'
			if (tokens.IndexOf("=") < tokens.IndexOf(")")) return false;

			// any operator after '='
			if (tokens.IndexOf("+") < tokens.IndexOf("=") && tokens.IndexOf("+") != -1) return false;
			if (tokens.IndexOf("-") < tokens.IndexOf("=") && tokens.IndexOf("-") != -1) return false;
			if (tokens.IndexOf("*") < tokens.IndexOf("=") && tokens.IndexOf("*") != -1) return false;
			if (tokens.IndexOf("/") < tokens.IndexOf("=") && tokens.IndexOf("/") != -1) return false;
			if (tokens.IndexOf("^") < tokens.IndexOf("=") && tokens.IndexOf("^") != -1) return false;

			// count of variables == count of ',' + 1
			if(CountOfVariables(tokens) != CountSymbolOccurrences(tokens,',', tokens.IndexOf("("), tokens.IndexOf(")")) + 1) return false;
			return true;
		}

		public static bool CanParseUserVariable(string variableDef)
		{
			List<string> tokens = SeparateEquation(variableDef);
			// it can be only 3 tokens in definition
			if (tokens.Count != 3) return false;

			// only 1 '='
			if (CountSymbolOccurrences(tokens, '=' , 0, tokens.Count -1) != 1) return false;

			// only 1 number
			if (CountNumbers(tokens) != 1) return false;

			// only 1 string, numbers included
			if (CountWords(tokens) != 1) return false;

			// no special symbols except '='
			if (CountSymbolOccurrencesWithExcept(tokens,'=') != 0) return false;

			return true;
		}


		public static bool CanParseMathExpression(string expression)
		{
			throw new NotImplementedException();
		}



		private static int CountOfVariables(List<string> tokens)
		{
			int start = tokens.IndexOf("(");
			int end = tokens.IndexOf(")");
			int res = 0;
			for (int i = start + 1; i < end; i++)
			{
				if (tokens[i] != ",") res++;
			}

			return res;
		}

		private static bool AllBracketsCorrect(List<string> tokens)
		{
			Stack<string> brackets = new Stack<string>();
			foreach (string token in tokens)
			{
				if(token == "(") brackets.Push(token);
				else if (token == ")")
				{
					if(brackets.Count == 0) return false;
					if (brackets.Peek() == "(")
					{
						brackets.Pop();
					}
				}
			}

			return true;
		}

		private static int CountSymbolOccurrences(List<string> tokens, char symbol, int startIndex, int endIndex)
		{
			return tokens.Skip(startIndex).SkipLast(tokens.Count - endIndex).Count(item => item.Equals(symbol.ToString()));
		}

		private static int CountSymbolOccurrencesWithExcept(List<string> tokens, char exceptedSymbol)
		{
			return tokens.Count(item => !item.Equals(exceptedSymbol.ToString()));
		}

		private static int CountNumbers(List<string> tokens, int startIndex = 0)
		{
			int res = 0;
			for (int i = startIndex; i < tokens.Count; i++)
			{
				if (int.TryParse(tokens[i], out int _)) res++;
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
				if (!Validator.StandartOperators.Contains(equation[pos].ToString()))
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
