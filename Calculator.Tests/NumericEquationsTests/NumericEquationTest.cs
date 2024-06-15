using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Tests.NumericEquationTests
{
    public class NumericEquationTest
    {
        sealed class TestCases : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return TestCase1();
                yield return TestCase2();
            }

            static object[] TestCase1()
            {
                var equation = new NumericEquation("1+1");
                var expectedInfixEquation = new List<string> { "1", "+", "1" };
                var expectedPostfixEquation = new List<string> { "1", "1", "+" };
                return new object[] { equation, expectedInfixEquation, expectedPostfixEquation };
            }

            static object[] TestCase2()
            {
                var equation = new NumericEquation("((-12-1,2)+4)*3/(1-2)");
                var expectedInfixEquation = new List<string> { "(", "(", "-", "12", "-", "1,2", ")", "+", "4", ")", "*", "3", "/", "(", "1", "-", "2", ")" };
                var expectedPostfixEquation = new List<string> { "12", "-", "1,2", "-", "4", "+", "3", "*", "1", "2", "-", "/" };
                return new object[] { equation, expectedInfixEquation, expectedPostfixEquation };
            }

        }



        [Theory]
        [ClassData(typeof(TestCases))]
        public static void InfixEquationTest(NumericEquation equation, List<string> expectedInfixEquation, List<string> expectedPostfixEquation)
        {
            Assert.Equal(expectedInfixEquation, equation.infixEquation);
        }

        [Theory]
        [ClassData(typeof(TestCases))]
        public static void PostfixEquationTest(NumericEquation equation, List<string> expectedInfixEquation, List<string> expectedPostfixEquation)
        {
            Assert.Equal(expectedPostfixEquation, equation.postfixEquation);
        }
    }
}
