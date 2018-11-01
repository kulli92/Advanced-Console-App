using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryHandler
{
   public class ParameterObject
    {
        public string Name { get; set; }
        public string MemoryAddress { get; set; }
        public string Value { get; set; } = "";
        public ObservableCollection<Parameter> ContainedParams { get; set; }
    }
}
