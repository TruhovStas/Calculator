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

		private List<string> standart_operators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "^" });


		public NumericEquation(string equation)
		{
			this.infixEquation = SeparateEquation(equation);
			this.postfixEquation = Convert2PostfixNotation();
		}


		private List<string> Convert2PostfixNotation() // dont forget to copy list
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
			throw new NotImplementedException();
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
				if (!standart_operators.Contains(equation[pos].ToString()))
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

			// add remove text
			return result;
		}

		private double GetFullNumber(string equation, ref int pos) // used for getting fractional numbers
		{
			throw new NotImplementedException();
		}
	}

}
