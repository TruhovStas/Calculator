using System.Collections;
using Calculator.Utilities;

namespace Calculator.Tests.ParserTests
{
    public class ReplaceVariablesTest
    {
        sealed class TestCases : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return TestCase1();
                yield return TestCase2();
                yield return TestCase3();
            }

            static object[] TestCase1()
            {
                string variable = "x=-9,8";
                string equation = "x+2-7";
                string expectedResult = "(-9,8)+2-7";
                return new object[] { variable, equation, expectedResult };
            }

            static object[] TestCase2()
            {
                string variable = "x=0";
                string equation = "x+x(3)-2-7";
                string expectedResult = "(0)+x(3)-2-7";
                return new object[] { variable, equation, expectedResult };
            }

            static object[] TestCase3()
            {
                string variable = "x=-2";
                string equation = "-x+(-x)";
                string expectedResult = "-(-2)+(-(-2))";
                return new object[] { variable, equation, expectedResult };
            }
        }



        [Theory]
        [ClassData(typeof(TestCases))]
        public static void Test(string variable, string equation, string expectedResult)
        {
            var parser = new Parser();
            parser.Parse(variable);
            var result = parser.ReplaceVariables(equation);
            Assert.Equal(expectedResult, result);
        }
    }
}