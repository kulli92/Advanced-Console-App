using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Model
{
   public class Parameter
    {
     //  public string Name { get; set; }
        public int Value { get; set; }
        public string ParamName { get;  set; }
        public string MemoryAddress { get; set; }
        public int Index { get; internal set; }
        public string MaxValue { get; internal set; }
        public string MinValue { get; internal set; }
    }
}
