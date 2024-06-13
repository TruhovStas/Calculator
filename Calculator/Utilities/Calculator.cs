using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utilities
{
    // should i not use token instead of some another definition???
    public static class Calculator
    {
        /// <summary>
        /// Method solve equations which consists of numbers and math operations
        /// Based on Sort Station Alghorythm
        /// </summary>
        /// <param name="equation">Numbers and math operatons</param>
        /// <returns>Result of math operations</returns>
        public static double SolveEquation(string equation) // completed
        {
            // convert to reverse polish notation
            List<string> separatedEquation = SeparateEquation(equation);
			List<string> pnEquation = Calculator.Convert2PostfixNotation(separatedEquation);
            double result = CalculatePostfixNotationEquation(pnEquation);
            return result;
        }


      

        private static double GetNumber() // used for getting fractional numbers
        {
            throw new NotImplementedException();
        }


        private static double CalculatePostfixNotationEquation(List<string> equationTokens) //this method should calculate such funcs like sin cos abs and take it from Math C#
        {
            throw new NotImplementedException();
        }

    }

    internal class Equation
    {

    }

    // релазиовать методы
    // реализовать метод польской нотации
}
