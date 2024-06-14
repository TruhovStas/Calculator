using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Tests.VariableTests
{
    public class VariableTest
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
                var variable = new Variable("f=1");

                var value = new List<object>
                {
                    "f", 1
                };

                return new object[] { variable, value };
            }

            static object[] TestCase2()
            {
                var variable = new Variable("f1 = -1");

                var value = new List<object>
                {
                    "f1", -1
                };

                return new object[] { variable, value };
            }

            static object[] TestCase3()
            {
                var variable = new Variable("f1f1 =-1.5");

                var value = new List<object>
                {
                    "f1f1", -1.5
                };

                return new object[] { variable, value };
            }


        }


        [Theory]
        [ClassData(typeof(TestCases))]
        public static void nameTest(Variable actual, List<object> expected)
        {
            Assert.Equal(expected[0], actual.Name);
        }

        [Theory]
        [ClassData(typeof(TestCases))]
        public static void valueTest(Variable actual, List<object> expected)
        {
            Assert.Equal(expected[1], actual.Value);
        }
    }
}
