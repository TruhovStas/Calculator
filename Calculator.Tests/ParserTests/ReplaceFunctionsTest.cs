using System.Collections;
using Calculator.Utilities;

namespace Calculator.Tests.ParserTests
{
    public class ReplaceFunctionsTest
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
                string function = "f(x)=3/2";
                string equation = "f(1)";
                string expectedResult = "(3/2)";
                return new object[] { function, equation, expectedResult };
            }

            static object[] TestCase2()
            {
                string function = "x(x,xx,xxx)=x-xx-xxx";
                string equation = "x(1,2,3)";
                string expectedResult = "((1)-(2)-(3))";
                return new object[] { function, equation, expectedResult };
            }

            static object[] TestCase3()
            {
                string function = "x(x)=x+x-x";
                string equation = "x(-1)";
                string expectedResult = "((-1)+(-1)-(-1))";
                return new object[] { function, equation, expectedResult };
            }
        }



        [Theory]
        [ClassData(typeof(TestCases))]
        public static void Test(string function, string equation, string expectedResult)
        {
            var parser = new Parser();
            parser.Parse(function);
            var result = parser.ReplaceFunctions(equation);
            Assert.Equal(expectedResult, result);
        }
    }

}