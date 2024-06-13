using Calculator.Models;

namespace Calculator.Utilities
{
    public static class Calculator
    {
        public static double SolveEquation(string eq)
        {
            NumericEquation equation = new NumericEquation(eq);
            double result = equation.GetResult();
            return result;
        }
    }
}
