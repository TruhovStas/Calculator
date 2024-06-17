namespace Calculator.Models
{
    public interface IVariableDictionary
    {
        void Add(Variable func);
        Variable GetVariable(string name);
        List<Variable> GetAllVariables();
    }
}
