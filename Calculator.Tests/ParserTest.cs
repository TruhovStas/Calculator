using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Calculator.Utilities;
using Moq;


namespace Calculator.Tests
{
    [TestFixture]
    internal class ParserTest
    {
        private Parser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new Parser();
        }

        [Test]
        public void TestCase1()
        {

        }

    }
}
