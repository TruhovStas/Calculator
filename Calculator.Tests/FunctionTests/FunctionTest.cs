using System;
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



        //[Fact]
        //public void TestCase1()
        //{
        //    var func = new Function("f(x)=x");
        //    Assert.Equal("f", func.Name);
        //    Assert.Equal("x", func.Body);
        //    Assert.Equal("x", func.Parameters[0]);
        //}

        //[Fact]
        //public void TestCase2()
        //{
        //    var func = new Function("xxx(xxx,yyy)=xxx*xxx-yyy");
        //    Assert.Equal("xxx", func.Name);
        //    Assert.Equal("xxx*xxx-yyy", func.Body);
        //    Assert.Equal("xxx", func.Parameters[0]);
        //    Assert.Equal("yyy", func.Parameters[1]);
        //}

        //[Fact]
        //public void TestCase3()
        //{
        //    var func = new Function("f(x)=x+x*(x+x)");
        //    Assert.Equal("f", func.Name);
        //    Assert.Equal("x+x*(x+x)", func.Body);
        //    Assert.Equal("x", func.Parameters[0]);
        //}

    }
}
