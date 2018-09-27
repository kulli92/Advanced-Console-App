using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.ViewModel
{
    class ViewModelLocator
    {
        public static Console_WindowVM Mine { get; } = new Console_WindowVM();
    }
}
