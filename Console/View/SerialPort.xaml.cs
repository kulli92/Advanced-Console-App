using DictionaryHandler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Console.View
{
    /// <summary>
    /// Interaction logic for SerialPort.xaml
    /// </summary>
    public partial class SerialPort : UserControl
    {
        public SerialPort()

        {
            InitializeComponent();
        }

        public List<string> Coms { get; set; } = new List<string> { };

        private void Open_Port(object sender, RoutedEventArgs e)
        {
            if ((string)OpenPort.Content != "Open Port")
            {
                OpenPort.Content = "Open Port";
                DictonaryImporter.Tunnel.ClosePort();
                AvailableCom.IsEnabled = true;
            }
            else
            {
                OpenPort.Content = "Close Port";
                DictonaryImporter.Tunnel.OpenPort(AvailableCom.SelectedItem.ToString());
                AvailableCom.IsEnabled = false;
            }
        }
        private void AvailableCom_DropDownOpened(object sender, EventArgs e)
        {
            foreach (var item in System.IO.Ports.SerialPort.GetPortNames())
            {
               Coms.Add(item);
            }
            AvailableCom.ItemsSource = Coms;
        }
    }
}
