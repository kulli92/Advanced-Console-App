using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class BringThemHome
    {
        public int onee { get; set; }

        public Collection<int> Generator()
        {
            var list = new Collection<int>
            {
                new Parameter
                {
                    Name = "firls",
                    Value = 13
                },
                  new Parameter
                {
                    Name = "Second",
                    Value = 12
                }
            };
            return list;
        }
    }
}
