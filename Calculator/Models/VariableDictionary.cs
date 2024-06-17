namespace Calculator.Models
{
    public class VariableDictionary : IVariableDictionary
    {
        private Dictionary<string, Variable> dict;
        public VariableDictionary()
        {
            dict = new Dictionary<string, Variable>();
        }
        public void Add(Variable func)
        {
            dict[func.Name] = func;
        }
        public Variable GetVariable(string name)
        {
            return dict[name];
        }
        public List<Variable> GetAllVariables() 
        {
            List<Variable> list = [.. dict.Values];
            return list;
        }
    }
}
