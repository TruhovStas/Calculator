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

       private List<string> vars;

       private string body;    

        public string Name { get { return name; } }

        public string Body { get { return body; } }


    }
}
