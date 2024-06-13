using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;
using NUnit;
using Moq;

namespace Calculator.Tests
{
    [TestFixture]
    internal class FunctionTest
    {
        Function _function;

        [SetUp]
        public void SetUp()
        {
            _function = new Function();
        }

        [Test]
        public void Test() { }

    }
}
