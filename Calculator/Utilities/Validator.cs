using Calculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Utilities
{
	public static class Validator
	{
		private static readonly List<string> StandartOperators = new List<string>()
			{ "(", ")", "+", "-", "*", "/", "^" };

		public static bool CanParseUserFunction(string functionDef)
		{
			List<string> tokens = SeparateEquation(functionDef);

			// only 1 '=' +
			if (CountSymbolOccurrences(tokens, '=', 0, tokens.Count - 1) != 1)
			{
				throw new ValidationException("В функции больше одного символа '='");
			}

			// no special symbols except '='
			if (CountSymbolOccurrencesWithExcept4Function(functionDef, '=') != 0)
			{
				throw new ValidationException("В функции обнаружены недопустимые символы");
			}

			// correct brackets
			if (!AllBracketsCorrect(tokens))
			{
				throw new ValidationException("В функции нарушена последовательность скобок");
			}

			if (tokens.IndexOf("(") == -1 || tokens.IndexOf(")") == -1 || tokens.IndexOf("(") > tokens.IndexOf(")"))
			{
				throw new ValidationException("В функции нарушена последовательность скобок");
			}


			// '=' after ')'
			if (tokens.IndexOf("=") < tokens.IndexOf(")"))
			{
				throw new ValidationException("В функции символ '=' стоит неправильно");
			}


			// any operator after '='
			if (tokens.IndexOf("+") < tokens.IndexOf("=") && tokens.IndexOf("+") != -1)
			{
				throw new ValidationException("В функции оператор '+' находится в неправильном положении");
			}

			if (tokens.IndexOf("-") < tokens.IndexOf("=") && tokens.IndexOf("-") != -1)
			{
				throw new ValidationException("В функции оператор '-' находится в неправильном положении");
			}

			if (tokens.IndexOf("*") < tokens.IndexOf("=") && tokens.IndexOf("*") != -1)
			{
				throw new ValidationException("В функции оператор '*' находится в неправильном положении");
			}

			if (tokens.IndexOf("/") < tokens.IndexOf("=") && tokens.IndexOf("/") != -1)
			{
				throw new ValidationException("В функции оператор '/' находится в неправильном положении");
			}

			if (tokens.IndexOf("^") < tokens.IndexOf("=") && tokens.IndexOf("^") != -1)
			{
				throw new ValidationException("В функции оператор '^' находится в неправильном положении");
			}


			// count of variables == count of ',' + 1
			if ((CountOfVariables(tokens) !=
				 CountSymbolOccurrences(tokens, ',', tokens.IndexOf("("), tokens.IndexOf(")")) + 1) &&
				(tokens.IndexOf(")") - tokens.IndexOf("(") > 1))
			{
				throw new ValidationException("В объявлении функции неправильно разделены параметры");
			}

			return true;
		}

		public static bool CanParseUserVariable(string variableDef)
		{
			List<string> tokens = SeparateEquation(variableDef);

			// only 1 '='
			if (CountSymbolOccurrences(tokens, '=', 0, tokens.Count - 1) != 1)
			{
				throw new ValidationException("В переменной больше одного символа '='");
			}


			// only 1 number
			if (CountNumbers(tokens) != 1)
			{
				throw new ValidationException("В переменной обнаружено больше одного числа");
			}


			// only 1 string, numbers included
			if (CountWords(tokens) != 1)
			{
				throw new ValidationException("Обнаружено несколько переменных");
			}


			// no special symbols except '='
			if (CountSymbolOccurrencesWithExcept(variableDef, '=') != 0)
			{
				throw new ValidationException("В переменной обнаружены недопустимые символы");
			}


			return true;
		}

		public static bool CanParseMathExpression(string expression)
		{
			List<string> tokens = SeparateEquation(expression);
			string pattern = @"^[A-Za-z0-9\,\.\(\)\+\-\*\/\s]+$";

			// no special symbols except operators and ',' and '.'
			if (!ContainsOnlyAcceptedSymbols(expression, pattern))
			{
				throw new ValidationException("В уравнении обнаружены недопустимые символы");
			}

			// correct brackets
			if (!AllBracketsCorrect(tokens))
			{
				throw new ValidationException("В уравнении нарушена последовательность скобок");
			}

			return true;
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
				if (token == "(") brackets.Push(token);
				else if (token == ")")
				{
					if (brackets.Count == 0) return false;
					if (brackets.Peek() == "(")
					{
						brackets.Pop();
					}
				}
			}

			return brackets.Count == 0;
		}

		private static int CountSymbolOccurrences(List<string> tokens, char symbol, int startIndex, int endIndex)
		{
			return tokens.Skip(startIndex).SkipLast(tokens.Count - endIndex)
				.Count(item => item.Equals(symbol.ToString()));
		}

		private static int CountSymbolOccurrencesWithExcept(string expression, char exceptedSymbol)
		{
			string pattern = @"^[A-Za-z0-9\=\-\,\,]$";
			Regex reg = new Regex(pattern, RegexOptions.Compiled);

			int res = 0;
			foreach (char s in expression)
			{
				var match = reg.Match(s.ToString());
				if (match.Success) res++;
			}

			return expression.Length - res;
		}

		private static int CountSymbolOccurrencesWithExcept4Function(string expression, char exceptedSymbol)
		{
			string pattern = @"^[A-Za-z0-9\=\-\,\.\+\-\*\/\(\)\s]$";
			Regex reg = new Regex(pattern, RegexOptions.Compiled);

			int res = 0;
			foreach (char s in expression)
			{
				var match = reg.Match(s.ToString());
				if (match.Success) res++;
			}

			return expression.Length - res;
		}


		private static int CountNumbers(List<string> tokens, int startIndex = 0)
		{
			int res = 0;
			for (int i = startIndex; i < tokens.Count; i++)
			{
				if (double.TryParse(tokens[i], out double _)) res++;
			}

			return res;
		}

		private static int CountWords(List<string> tokens)
		{
			string pattern = @"^[a-zA-Z][a-zA-Z0-9]*$";
			Regex reg = new Regex(pattern, RegexOptions.Compiled);

			int res = 0;
			foreach (var s in tokens)
			{
				var match = reg.Match(s);
				if (match.Success) res++;
			}

			return res;

		}

		public static List<string> SeparateEquation(string equation)
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

		private static bool ContainsOnlyAcceptedSymbols(string expression, string regexPattern)
		{
			Regex condition = new Regex(regexPattern, RegexOptions.Compiled);

			return (condition.Match(expression).Success);
		}
	}
}
