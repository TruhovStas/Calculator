namespace Calculator.Models
{
    public class Variable
    {
        private string name;

        private double value;
        public string Name { get { return name; } }
        public double Value { get { return value; } }

        public Variable(string Expression)
        {
            ParseExpression(Expression);
        }

        public Variable(string Expression, VariableDictionary dict)
        {
            ParseExpression(Expression);
            dict.Add(this);
        }

        private void ParseExpression(string Expression)
        {
            this.name = Expression.Remove(Expression.IndexOf('='));
            this.value = Convert.ToDouble(Expression.Substring(Expression.IndexOf('=') + 1));
        }

        public string GetToStringValue()
        {
            return Convert.ToString(this.value);
        }
    }
}
