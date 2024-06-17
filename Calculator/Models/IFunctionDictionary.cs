namespace Calculator.Models
{
    public interface IFunctionDictionary
    {
        void Add(Function func);
        Function GetFunction(string name);
        List<Function> GetAllFunctions();
    }
}
