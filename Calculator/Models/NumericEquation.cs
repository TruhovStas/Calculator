
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Models
{
	public class NumericEquation
	{
		public List<string> infixEquation { get; private set; }
		public List<string> postfixEquation { get; private set; }

		private static List<string> standartOperators = new List<string>() { "(", ")", "+", "-", "*", "/", "^" };


		public NumericEquation(string equation)
		{
			this.infixEquation = SeparateEquation(equation);
			this.postfixEquation = Convert2PostfixNotation(infixEquation);
		}


		/// <summary>
		/// Get equation and rewrite it in postfix notation
		/// </summary>
		/// <param name="infixEquation">Original equation</param>
		/// <returns>Postfix variation of equation</returns>
		private List<string> Convert2PostfixNotation(List<string> infixEquation)
		{
			List<string> outputSeparated = new List<string>();
			Stack<string> stack = new Stack<string>();
			foreach (string c in new List<string>(infixEquation))
			{
				if (standartOperators.Contains(c))
				{
					if (stack.Count > 0 && !c.Equals("("))
					{
						if (c.Equals(")"))
						{
							string s = stack.Pop();
							while (s != "(")
							{
								outputSeparated.Add(s);
								s = stack.Pop();
							}
						}
						else if (GetOperationPriority(c) > GetOperationPriority(stack.Peek()))
							stack.Push(c);
						else
						{
							while (stack.Count > 0 && GetOperationPriority(c) <= GetOperationPriority(stack.Peek()))
								outputSeparated.Add(stack.Pop());
							stack.Push(c);
						}
					}
					else
						stack.Push(c);
				}
				else
					outputSeparated.Add(c);
			}

			if (stack.Count > 0)
				foreach (string c in stack)
					outputSeparated.Add(c);

			return outputSeparated;
		}



		public double GetResult() => CalculatePostfixNotationEquation();



		/// <summary>
		/// Calculates an equation written in postfix notation
		/// </summary>
		/// <returns>Result of equation</returns>
		private double CalculatePostfixNotationEquation()
		{
			Stack<string> stack = new Stack<string>();
			Queue<string> queue = new Queue<string>(postfixEquation);
			string str = queue.Dequeue();
			while (queue.Count >= 0)
			{
				if (!standartOperators.Contains(str))
				{
					stack.Push(str);
					str = queue.Dequeue();
				}
				else
				{
					double curVal = 0;
					// as elements can contain "~" it should be convert to "-"
					try
					{
						string num1 = stack.Pop();
						double a = Convert.ToDouble(num1.Replace('~', '-'));

						string num2 = stack.Pop();
						double b = Convert.ToDouble(num2.Replace('~', '-'));

						curVal = ExecuteBinaryOperation(a, b, str);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.StackTrace);
					}

					stack.Push(curVal.ToString());
					if (queue.Count > 0)
						str = queue.Dequeue();
					else
						break;
				}

			}

			return Convert.ToDouble(stack.Pop());
		}



		/// <summary>
		/// Separates equation on every small part for its easy processing.
		/// Divides brackets, operators and fractional numbers
		/// </summary>
		/// <param name="equation">Current equation</param>
		/// <returns>List of tokenized parts of equation</returns>
		private List<string> SeparateEquation(string equation)
		{
			string[] tokens = Regex.Split(equation, @"([*()\^\/]|(?<!E)[\+\-])");
			tokens = tokens.Where(empty => !string.IsNullOrEmpty(empty)).ToArray();

			var trueTokens = UnitUnaryMinuses(tokens.ToList());
			return trueTokens;

		}

		private static List<string> UnitUnaryMinuses(List<string> original)
		{
			List<string> operators = new List<string>() { "+", "-", "*", "/", "^", "(" };
			List<string> united = new List<string>();
			for (int i = 0; i < original.Count; i++)
			{
				// if minus then check if next element number and previous is operator then unite into one element
				if (original[i] == "-")
				{
					try
					{
						if (Double.TryParse(original[i + 1], out double nextNum) && operators.Contains(original[i - 1]))
						{
							string newElem = "~" + original[i + 1];
							united.Add(newElem);
							i++;
							continue;
						}
					}
					catch (IndexOutOfRangeException e)
					{
						continue;
					}
				}

				united.Add(original[i]);
			}

			return united;
		}


		private double ExecuteBinaryOperation(double x, double y, string op)
		{
			switch (op)
			{
				case "+": return x + y;
				case "-": return y - x;
				case "*": return x * y;
				case "/": return y / x;
				case "^": return Math.Pow(y, x);
				default: return 0;
			}
		}



		private int GetOperationPriority(string op)
		{
			switch (op)
			{
				case "(": return 0;
				case ")": return 0;
				case "+": return 1;
				case "-": return 1;
				case "*": return 2;
				case "/": return 2;
				case "^": return 3;
				case "~": return 4;
				default: return 5;
			}
		}
	}
}
