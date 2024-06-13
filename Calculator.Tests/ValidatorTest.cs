using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Moq;
using Calculator.Utilities;
using Calculator.Models;

namespace Calculator.Tests
{
    [TestFixture]
    internal class ValidatorTest
    { 
        Validator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new Validator();
        }

        [Test]
        public void TestCase1()
        { }
    }
}
