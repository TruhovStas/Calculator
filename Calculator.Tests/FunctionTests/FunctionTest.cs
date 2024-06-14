﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Tests.FunctionTests
{
    public class FunctionTest
    {
        sealed class TestCases: IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return TestCase1();
                yield return TestCase2();
                yield return TestCase3();
                yield return TestCase4();
            }

            static object[] TestCase1()
            {
                var func = new Function("f(x)=x");

                var values = new List<object>
                {
                    "f", "x", new List<string>{"x"}
                };

                return new object[] { func, values };
            }

            static object[] TestCase2()
            {
                var func = new Function("xxx(xxx,yyy)=xxx*xxx-yyy");

                var values = new List<object>
                {
                    "xxx", "xxx*xxx-yyy", new List<string>{"xxx", "yyy"}
                };

                return new object[] { func, values };
            }

            static object[] TestCase3()
            {
                var func = new Function("f(x)=x+x*(x+x)");

                var values = new List<object>
                {
                    "f", "x+x*(x+x)", new List<string>{"x"}
                };

                return new object[] { func, values };
            }

            static object[] TestCase4()
            {
                var func = new Function("xyz(x, y, z)=((x + y) * x) + z");

                var values = new List<object>
                {
                    "xyz", "((x + y) * x) + z", new List<string>{"x", "y", "z"}
                };

                return new object[] { func, values };
            }

        }



        [Theory]
        [ClassData(typeof(TestCases))]
        public static void nameTest(Function actual, List<object> expected)
        {
            Assert.Equal(expected[0], actual.Name);
        }

        [Theory]
        [ClassData(typeof(TestCases))]
        public static void bodyTest(Function actual, List<object> expected)
        {
            Assert.Equal(expected[1], actual.Body);
        }

        [Theory]
        [ClassData(typeof(TestCases))]
        public static void parametersTest(Function actual, List<object> expected)
        {
            Assert.Equal(expected[2], actual.Parameters);
        }
    }
}
