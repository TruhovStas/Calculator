namespace Calculator.Models
{
    public class FunctionDictionary : IFunctionDictionary
    {

        private Dictionary<string, Function> dict;
        public FunctionDictionary()
        {
            dict = new Dictionary<string, Function>();
        }
        public void Add(Function func)
        {
            dict[func.Name] = func;
        }
        public Function GetFunction(string name) 
        {
            Function func;
            try
            {
                func = dict[name];
            } 
            catch { throw new ArgumentException("Функция не найдена в списке."); }
            return func;
        }
        public List<Function> GetAllFunctions()
        {
            List<Function> list = [.. dict.Values];
            return list;
        }
    }
}
