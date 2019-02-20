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
using DictionaryHandler;

namespace Console.View
{
    /// <summary>
    /// Interaction logic for Console_Window.xaml
    /// </summary>
    public partial class Console_Window : Window

    {
        public ValuesObjects ValuesBuffer { get; set; } = new ValuesObjects();
        public static bool Debug_On { get; private set; } = false;

        public Console_Window()
        {
            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1000);
            dt.Tick += UpdateEverySecond;
            dt.Start();
        }
        private void UpdateEverySecond(object sender, EventArgs e)
        {
            DG.ScrollIntoView(DG.Items.GetItemAt(DG.Items.Count - 1));
        }
        private void Open_Parameter_Selector(object sender, RoutedEventArgs e)
        {
            ParameterSelector win2 = new ParameterSelector();
            win2.Show();
        }
        // auto scroll with optional stop 
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
        public void ParameterWindowHasBeenClosed()
        {
            //Delete all previous Columns
            while (DG.Columns.Count > 0)
            {
                DG.Columns.RemoveAt(DG.Columns.Count - 1);
            }
            // Assign Headers and bindings to columns
            for (int i = 0; i < ViewModel.ParameterSelectorVM.ConfigurationList.Count; i++)
            {
                var TempCol = new DataGridTextColumn();
                TempCol.Header = ViewModel.ParameterSelectorVM.ConfigurationList[i];
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
                    case 9:
                        TempCol.Binding = new Binding("Val10");
                        break;
                    case 10:
                        TempCol.Binding = new Binding("Val11");
                        break;
                    case 11:
                        TempCol.Binding = new Binding("Val12");
                        break;
                    case 12:
                        TempCol.Binding = new Binding("Val13");
                        break;
                    case 13:
                        TempCol.Binding = new Binding("Val14");
                        break;
                    case 15:
                        TempCol.Binding = new Binding("Val16");
                        break;
                    case 16:
                        TempCol.Binding = new Binding("Val17");
                        break;
                    case 17:
                        TempCol.Binding = new Binding("Val18");
                        break;
                    case 18:
                        TempCol.Binding = new Binding("Val19");
                        break;
                    case 19:
                        TempCol.Binding = new Binding("Val20");
                        break;
                    default:
                        break;
                }

                DG.Columns.Add(TempCol);

            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            ParameterWindowHasBeenClosed();
        }
        private void Open_Formatter(object sender, RoutedEventArgs e)
        {
            var FormatterWindow = new StartUp_Report_Formatter();
            FormatterWindow.Show();
        }
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
