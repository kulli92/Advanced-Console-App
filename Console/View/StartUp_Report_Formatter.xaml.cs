﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Console.View
{
    /// <summary>
    /// Interaction logic for StartUp_Report_Formatter.xaml
    /// </summary>
    public partial class StartUp_Report_Formatter : Window
    {
        public static ObservableCollection<string> TempList { get; set; } = new ObservableCollection<string>() { };
        public StartUp_Report_Formatter()
        {
            InitializeComponent();
        }

        //-----------------------------------
        private void MoveElement(object sender, RoutedEventArgs e)
        {
            TempList.Clear();
            
            foreach (var item in FirstList.SelectedItems)
            {
                TempList.Add(item.ToString());
            }
            SecondList.ItemsSource = TempList;
        }

        //-----------------------------------
        private void Save_And_Exit(object sender, RoutedEventArgs e)
        {
            //used in creating new columns header
            ViewModel.StartUp_Report_FormatterVM.ConfigurationList = TempList;

            Close();

        }
    }
}
