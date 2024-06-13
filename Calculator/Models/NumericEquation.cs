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

		private List<string> SeparateEquation(string equation)
		{
			//use this infix eq
			//get number here
			throw new NotImplementedException();
		}

		private double GetNumber() // used for getting fractional numbers
		{
			throw new NotImplementedException();
		}
	}

}
