using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Tests.FunctionTests
{
    public class ReplaceVariableTest
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
                var func = new Function("f(x)=x");
                var values = new List<double> { 1 };
                string expected = "1";
                return new object[] { func, values, expected };
            }


            static object[] TestCase2()
            {
                var func = new Function("f(x,y,z,i,m,n)=x+y*z-i/m+n");
                var values = new List<double> { -1, 0, -1.8, 9.99, 5, 3 };
                string expected = "-1+0*(-1,8)-9,99/5+3";
                return new object[] { func, values, expected };
            }


            static object[] TestCase3()
            {
                var func = new Function("f(x,xx,xxx)=x+xx-xxx");
                var values = new List<double> { -1, -1, -1 };
                string expected = "-1-1+1";
                return new object[] { func, values, expected };
            }
        }



        [Theory]
        [ClassData(typeof(TestCases))]
        public static void Test(Function function, List<double> values, string expected)
        {

            var result = function.ReplaceVariable(values);

            Assert.Equal(expected, result);
        }
    }
}
