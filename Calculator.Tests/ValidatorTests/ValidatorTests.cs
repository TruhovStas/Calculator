using System.ComponentModel.DataAnnotations;
using Calculator.Utilities;

namespace Calculator.ValidatorTests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("x12=5")]
        [InlineData("y=-3,5")]
        [InlineData("z=0")]
        [InlineData("a=10")]
        [InlineData("b=-7,8")]
        [InlineData("c=2,718")]
        [InlineData("d=-100")]
        [InlineData("e=3,14159")]
        [InlineData("f=-2,5")]
        [InlineData("g=7,0")]
        public void UserVariableDefinitionTest_WithCorrectDefinitions(string varDef)
        {
            var result = Calculator.Utilities.Validator.CanParseUserVariable(varDef);
            Assert.True(result);
        }

        [Theory]
        [InlineData("x12=5=8")]
        [InlineData("y=abc")]
        [InlineData("z=3.5")]
        [InlineData("a+b=10")]
        [InlineData("x=5y")]
        [InlineData("x=10,,5")]
        [InlineData("x=-")]
        [InlineData("x=5.7.2")]
        [InlineData("x=5+")]
        [InlineData("x 5=10")]
        public void UserVariableDefinitionTest_WithIncorrectDefinitions(string varDef)
        {
            Action act = () => Calculator.Utilities.Validator.CanParseUserVariable(varDef);
            ValidationException exception = Assert.Throws<ValidationException>(act);
            Assert.IsType<ValidationException>(exception);
        }


        [Theory]
        [InlineData("((-12-1,2)+4)*3/(1-2)")]
        [InlineData("((-5-2)*4)/2")]
        [InlineData("((-8.0/2)+3)*5")]
        [InlineData("((10-3)*2)/4")]
        [InlineData("((-6*3,2)+9)/3")]
        [InlineData("((-1+4)*7)/2")]
        [InlineData("((8/2)-1)*3")]
        [InlineData("((-7+3)*2)/1")]
        [InlineData("((-4*2)+6)/3")]
        [InlineData("((-9/3)+5)*2")]
        [InlineData("((-2+6)*8)/4")]
        public void MathExpressionTest_WithCorrectDefinitions(string expression)
        {
            var result = Calculator.Utilities.Validator.CanParseMathExpression(expression);
            Assert.True(result);
        }

        [Theory]
        [InlineData("((-12-1,2)+4)*3/(1-2")]
        [InlineData("(-12-1,2)+4)*3/(1-2)")]
        [InlineData("(-12-1,2)+4-)*3/(1-2")]
        [InlineData("(-12-1,2)+4)*3/(1-2))")]
        [InlineData("(-12-1,2)+4)*3/(1-2))")]
        [InlineData("(-12-1,2)+4)*3/(1-2")]
        [InlineData("(-12-1,2)+4)*3/(1-2")]
        [InlineData("(-12-1,2)+4)*3/(1-2")]
        [InlineData("(-12-1,2)+4)*3/(1-2")]
        public void MathExpressionTest_WithIncorrectDefinitions(string expression)
        {
            Action act = () => Calculator.Utilities.Validator.CanParseMathExpression(expression);
            ValidationException exception = Assert.Throws<ValidationException>(act);
            Assert.IsType<ValidationException>(exception);
        }

        [Theory]
        [InlineData("f(x,y)=x-y")]
        [InlineData("f(x,y)=x-y+1")]
        [InlineData("f(x)=x ")]
        [InlineData("f()=1")]
        [InlineData("f(x)=x-2+3")]
        [InlineData("f(x,y,z)=x-y*2-z")]
        public void UserFunctionDefineTest_WithCorrectDefinitions(string expression)
        {
            var result = Calculator.Utilities.Validator.CanParseUserFunction(expression);
            Assert.True(result);
        }

        [Theory]
        [InlineData("f(x,y,z,)=x-y*2z")]
        [InlineData("f(x,y,z)==x-y*2z")]
        [InlineData("f(x,y,=z)=x-y*2z")]
        [InlineData("f(x,y,z)=x%y*2z")]
        [InlineData("f(xj,y,z))=x-y*2z")]
        [InlineData("f(x,,y,z)=x-y*2z")]
        [InlineData("f((x,y.z)=x-y*2z")]
        [InlineData("f(x+y,z)=x-y*2z")]

        public void UserFunctionDefineTest_WithIncorrectDefinitions(string expression)
        {
            Action act = () => Calculator.Utilities.Validator.CanParseUserFunction(expression);
            ValidationException exception = Assert.Throws<ValidationException>(act);
            Assert.IsType<ValidationException>(exception);
        }
    }
}
