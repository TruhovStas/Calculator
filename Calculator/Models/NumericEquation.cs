
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
	public class NumericEquation
	{
		public List<string> infixEquation { get; private set; }
		public List<string> postfixEquation { get; private set; }

		private static List<string> standartOperators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "^" });


		public NumericEquation(string equation)
		{
			this.infixEquation = SeparateEquation(equation);
			this.postfixEquation = Convert2PostfixNotation(infixEquation);
		}



		private List<string> Convert2PostfixNotation(List<string> infixEquation) // dont forget to copy list
		{
			throw new NotImplementedException();
			//List<string> output = new List<string>();
			//Stack<string> symbolBuffer = new Stack<string>(); // needs for temporary keeping symbols 

			//foreach (var token in )
			//{

			//}
			//throw new NotImplementedException();
			////get number must be here
			//return output;
		}



		public double GetResult() => CalculatePostfixNotationEquation();



		private double CalculatePostfixNotationEquation() //this method should calculate such funcs like sin cos abs and take it from Math C#
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
					try
					{

						switch (str)
						{

							case "+":
								{
									double a = Convert.ToDouble(stack.Pop());
									double b = Convert.ToDouble(stack.Pop());
									curVal = a + b;
									break;
								}
							case "-":
								{
									double a = Convert.ToDouble(stack.Pop());
									double b = Convert.ToDouble(stack.Pop());
									curVal = b - a;
									break;
								}
							case "*":
								{
									double a = Convert.ToDouble(stack.Pop());
									double b = Convert.ToDouble(stack.Pop());
									curVal = b * a;
									break;
								}
							case "/":
								{
									double a = Convert.ToDouble(stack.Pop());
									double b = Convert.ToDouble(stack.Pop());
									curVal = b / a;
									break;
								}
							case "^":
								{
									double a = Convert.ToDouble(stack.Pop());
									double b = Convert.ToDouble(stack.Pop());
									curVal = Math.Pow(Convert.ToDouble(b), Convert.ToDouble(a));
									break;
								}
						}
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
		/// <param name="equation">current equation</param>
		/// <returns>List of tokenized parts of equation</returns>
		private List<string> SeparateEquation(string equation)
		{
			List<string> result = new List<string>();

			int pos = 0;
			while (pos < equation.Length)
			{
				string s = string.Empty + equation[pos];
				if (!standartOperators.Contains(equation[pos].ToString()))
				{
					if (Char.IsDigit(equation[pos]))
						for (int i = pos + 1; i < equation.Length &&
							(Char.IsDigit(equation[i]) || equation[i] == ',' || equation[i] == '.'); i++)
							s += equation[i];
					else if (Char.IsLetter(equation[pos]))
						for (int i = pos + 1; i < equation.Length &&
							(Char.IsLetter(equation[i]) || Char.IsDigit(equation[i])); i++)
							s += equation[i];
				}
				result.Add(s);
				pos += s.Length;
			}

			return result;
		}



		private double ExecuteBinaryOperation(double x, double y, string op)
		{
			switch (op)
			{
				case "+": return x + y;                  //    Сложение
				case "-": return x - y;             //    Вычитание
				case "*": return x * y;                  //    Умножение
				case "/": return x / y;                  //    Деление
				case "^": return Math.Pow(x, y); //    Степень
				default: return 0;  //	Возвращает, если не был найден подходящий оператор
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
				default: return 4;
			};
		}
	}
}
