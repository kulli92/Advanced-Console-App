using DictionaryHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.ViewModel
{
    class StartUp_Report_FormatterVM
    {
        public static Dictionary<string, ParameterObject> RowDictionary { get; set; }
        public List<string> NamesList { get; set; } = new List<string> { };
        public static ObservableCollection<string> ConfigurationList { get; set; } = new ObservableCollection<string>() { };

        public StartUp_Report_FormatterVM()
        {
            RowDictionary = DictonaryImporter.RowObjectDictionaryProvider();
            foreach (var item in RowDictionary)
            {
                NamesList.Add(item.Value.Name);
            }

        }
        public static string ConfigurationStringGenerator()
        {
            string ObjectString = "";
            foreach (var item in ConfigurationList)
            {
                var MyValue = RowDictionary.First(x => x.Value.Name == item).Value.Value;
                ObjectString += MyValue;
                
            };

            return "GQGRGSGTGUGVGWGgGhGiGj";

        }

    }
}
