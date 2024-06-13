using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
	public class NumericEquation
	{
		public string infixEquation { get; private set; }
		public string postfixEquation { get; private set; }


		public NumericEquation(string equation)
		{
			this.infixEquation = equation;
			this.postfixEquation = Convert2Postfix();

		}


		private string Convert2Postfix()
		{
			List<string> tokenizedEquation = SeparateEquation();

			List<string> outputString = new List<string>();
			Stack<string> symbolBuffer = new Stack<string>(); // needs for temporary keeping symbols 

			foreach (var token in infixNotationString)
			{

			}
			throw new NotImplementedException();
			//get number must be here
			return outputString.ToString();
		}


		private static List<string> SeparateEquation()
		{
			//use this infix eq
			//get number here
			throw new NotImplementedException();
		}
	}

}
