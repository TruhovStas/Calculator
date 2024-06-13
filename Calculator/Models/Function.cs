using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Function
    {
       private string name=null;

       private List<string> parametres;

       private string body;    

        public string Name { get { return name; } }

        public string Body { get { return body; } }

        Function(string Expression)
        {
            this.name = Expression.Remove(Expression.IndexOf('('), Expression.Length - Expression.IndexOf('('));
            this.body = Expression.Remove(0, Expression.IndexOf('='));
            parametres = Expression.Remove(Expression.IndexOf('('), Expression.IndexOf(')') - Expression.IndexOf('(')).Replace(" ","").Split(',').ToList();
        }

        Function(string Expression,FunctionDictionary dict)
        {
            this.name = Expression.Remove(Expression.IndexOf('('), Expression.Length - Expression.IndexOf('('));
            this.body = Expression.Remove(0, Expression.IndexOf('='));
            parametres = Expression.Remove(Expression.IndexOf('('), Expression.IndexOf(')') - Expression.IndexOf('(')).Replace(" ", "").Split(',').ToList();
            

        }

    }
}
