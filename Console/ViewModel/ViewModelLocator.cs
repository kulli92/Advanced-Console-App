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
        public static ParameterSelectorVM ParameterSelectorViewModel { get; } = new ParameterSelectorVM();
        public static StartUp_Report_FormatterVM StartUpReportViewModel { get; } = new StartUp_Report_FormatterVM();

    }
}
