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
            Variable func;
            try
            {
                func = dict[name];
            }
            catch { throw new ArgumentException("Переменная не найдена в списке."); }
            return func;
        }
        public List<Variable> GetAllVariables() 
        {
            List<Variable> list = [.. dict.Values];
            return list;
        }
    }
}
