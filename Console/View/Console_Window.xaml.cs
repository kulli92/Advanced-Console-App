using Console.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

using System.Data;
using System;
using System.Collections;
using Console.Model;
using System.Collections.ObjectModel;

namespace Console.View
{
    /// <summary>
    /// Interaction logic for Console_Window.xaml
    /// </summary>
    public partial class Console_Window : Window

    {
        public AnyType ValuesBuffer { get; set; } = new AnyType();

        public Console_Window()
        {
            InitializeComponent();

            var ViewModel = new Console_WindowVM();

            for (int i = 0; i < ViewModel.MyList.Count; i++)
            {
                var TempCol = new DataGridTextColumn();
                TempCol.Header = ViewModel.MyList[i].ParamName;
                switch (i)
                {
                    case 0:
                        TempCol.Binding = new Binding("Val1");
                        break;
                    case 1:
                        TempCol.Binding = new Binding("Val2");
                        break;
                    case 2:
                        TempCol.Binding = new Binding("Val3");
                        break;
                    case 3:
                        TempCol.Binding = new Binding("Val4");
                        break;
                    case 4:
                        TempCol.Binding = new Binding("Val5");
                        break;
                    case 5:
                        TempCol.Binding = new Binding("Val6");
                        break;
                    case 6:
                        TempCol.Binding = new Binding("Val7");
                        break;
                    case 7:
                        TempCol.Binding = new Binding("Val8");
                        break;
                    case 8:
                        TempCol.Binding = new Binding("Val9");
                        break;
                    default:
                        break;
                }

                DG.Columns.Add(TempCol);
                DispatcherTimer dt = new DispatcherTimer();
                dt.Interval = TimeSpan.FromMilliseconds(1000);
                dt.Tick += UpdateEverySecond;
                dt.Start();
            }

        }

        private void UpdateEverySecond(object sender, EventArgs e)
        {
            DG.ScrollIntoView(DG.Items.GetItemAt(DG.Items.Count - 1));

        }


        /*  private bool AutoScroll = true;
private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
{
DG.HeadersVisibility = System.Windows.Controls.DataGridHeadersVisibility.All ;
// User scroll event : set or unset autoscroll mode
if (e.ExtentHeightChange == 0)
{   // Content unchanged : user scroll event
if ((e.Source as ScrollViewer).VerticalOffset == (e.Source as ScrollViewer).ScrollableHeight)
{   // Scroll bar is in bottom
    // Set autoscroll mode
    AutoScroll = true;
}
else
{   // Scroll bar isn't in bottom
    // Unset autoscroll mode
    AutoScroll = false;
}
}

// Content scroll event : autoscroll eventually
if (AutoScroll && e.ExtentHeightChange != 0)
{   // Content changed and autoscroll mode set
// Autoscroll
//(e.Source as ScrollViewer).ScrollToVerticalOffset((e.Source as ScrollViewer).ExtentHeight);
}
}
*/
    }


    }

























//Ideas worth Noticing

// var _priceDataArray = from row in Dic select new { Item = row.Key, Price = row.Value };
/*
           for (int i = 0; i < ints.list2.Count; i++)
           {
               var col = new DataGridTextColumn();
               col.Binding = bb;
               col.Header = ints.list2[i].ParamName;
               DG2.Columns.Add(col);
           }
           for (int i = 0; i < ints.list3.Count; i++)
           {
               var col = new DataGridTextColumn();
               col.Binding = bb;
               col.Header = ints.list3[i].ParamName;
               DG3.Columns.Add(col);
           }
           */
