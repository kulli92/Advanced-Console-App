﻿using Console.ViewModel;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Console.View
{
    /// <summary>
    /// Interaction logic for Console_Window.xaml
    /// </summary>
    public partial class Console_Window : Window

    {
     

       
        public Console_Window()
        {
            InitializeComponent();
         
        }
        
        private bool AutoScroll = true;
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
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
                (e.Source as ScrollViewer).ScrollToVerticalOffset((e.Source as ScrollViewer).ExtentHeight);
            }
        }

       
    }
}
