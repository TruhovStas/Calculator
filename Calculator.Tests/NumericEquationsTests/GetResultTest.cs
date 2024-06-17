using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Tests.NumericEquationTests
{
    public class GetResultTest
    {
        sealed class TestCases : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return TestCase1();
                yield return TestCase2();
                yield return TestCase3();
                yield return TestCase4();
                yield return TestCase4();
                yield return TestCase5();
            }

            static object[] TestCase1()
            {
                var equation = new NumericEquation("1+1");
                var expectedResult = 2d;
                return new object[] { equation, expectedResult };
            }

            static object[] TestCase2()
            {
                var equation = new NumericEquation("((-12-1,2)+4)*3/(1-2)");
                var expectedResult = 27.6d;
                return new object[] { equation, expectedResult };
            }

            static object[] TestCase3()
            {
                var equation = new NumericEquation("123/2+12/(13-11)");
                var expectedResult = 67.5d;
                return new object[] { equation, expectedResult };
            }

            static object[] TestCase4()
            {
                var equation = new NumericEquation("0,4*0,2+1+1,4");
                var expectedResult = 2.48d;
                return new object[] { equation, expectedResult };
            }

            static object[] TestCase5()
            {
                var equation = new NumericEquation("1*(-1)+(-1-1)");
                var expectedResult = -3d;
                return new object[] { equation, expectedResult };
            }
        }



        [Theory]
        [ClassData(typeof(TestCases))]
        public static void Test(NumericEquation equation, double expectedResult)
        {
            Assert.Equal(expectedResult, equation.GetResult(), 0.01);
        }
    }
}
