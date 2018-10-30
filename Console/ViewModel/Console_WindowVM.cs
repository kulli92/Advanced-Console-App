using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using DictionaryHandler;
using GalaSoft.MvvmLight.Command;

namespace Console.ViewModel
{
  public class Console_WindowVM :INotifyPropertyChanged
    {
        public ObservableCollection<Parameter> MyList { get; set; } = new ObservableCollection<Parameter>() { };
        public ObservableCollection<Parameter> MyList2 { get; set; } = new ObservableCollection<Parameter>() { };
        public string StartUpReportString
        {
            get { return _StartUp; }
            set
            {
                _StartUp = value;
                RaisePropertyChanged();
            }

        }

        public ObservableCollection<ValuesObjects> DataGridBindingList { get; set; } = new ObservableCollection<ValuesObjects>() { };
        public static bool Debug_ON { get; set; } = true;
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();
        public bool OnlyOnce = true;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Console_WindowVM()
        {
           // MyList = new ObservableCollection<Parameter>() { };
         //   MyList = DictonaryImporter.ParameterList();
            //GetNewLine(new object(), new EventArgs());
        }

        //---------- Commands------------
 
        int Debug_Switch = 0;

        private RelayCommand<int> _Debug_On_Command;
     
        public ICommand Debug_On_Command {
            get
            {
                return _Debug_On_Command ??
                     (_Debug_On_Command = new RelayCommand<int>(Execute_Debug_On_Command, CanExecute_Debug_On_Command) );
            }
        }

        private void Execute_Debug_On_Command(int obj)
        {   //Recheck for Can Excute
            Debug_Switch = 1;
            _Debug_Off_Command.RaiseCanExecuteChanged();
            _Debug_On_Command.RaiseCanExecuteChanged();
            if (OnlyOnce)
            {
                dt.Interval = TimeSpan.FromMilliseconds(1000);
                dt.Tick += GetNewLine;
                OnlyOnce = false;
            }
            
            dt.Start();
            
        }
        //Check Every Second For UI update...
     

        private async void GetNewLine(object sender, EventArgs e)
        {
            // Application.Current.Dispatcher.Invoke(CommandManager.InvalidateRequerySuggested);
            MyList?.Clear();
        
            try
            {
                MyList = await DictonaryImporter.ParameterList(ParameterSelectorVM.ConfigurationStringGenerator());
                MyList2 =  await DictonaryImporter.ParameterList(StartUp_Report_FormatterVM.ConfigurationStringGenerator());
            }
            catch (Exception)
            {
                MyList.Add(new Parameter
                {
                    ParamName = "Error",
                    Value = "Somthing Went Wrong....Make Sure the Device is connected then Press Debug ON again"

                });
                MyList2.Add(new Parameter
                {
                    ParamName = "Error",
                    Value = "Somthing Went Wrong....Make Sure the Device is connected then Press Debug ON again"

                });
                dt.Stop();
            }
            StartUpReportString = "";
            foreach (var item in MyList2)
            {
                
                StartUpReportString += item.ParamName + "    " + item.Value + "\n";
            }
            
           ValuesObjects JustValuesObject = new ValuesObjects();
           for (int i = 0; i < MyList.Count; i++)
           {
               switch (i)
               {
                   case 0:
                       JustValuesObject.Val1 = MyList[i].Value;
                       break;
                   case 1:
                       JustValuesObject.Val2 = MyList[i].Value;
                       break;
                   case 2:
                       JustValuesObject.Val3 = MyList[i].Value;
                       break;
                   case 3:
                       JustValuesObject.Val4 = MyList[i].Value;
                       break;
                   case 4:
                       JustValuesObject.Val5 = MyList[i].Value;
                       break;
                   case 5:
                       JustValuesObject.Val6 = MyList[i].Value;
                       break;
                   case 6:
                       JustValuesObject.Val7 = MyList[i].Value;
                       break;
                   case 7:
                       JustValuesObject.Val8 = MyList[i].Value;
                       break;
                   case 8:
                       JustValuesObject.Val9 = MyList[i].Value;
                       break;
                   case 9:
                       JustValuesObject.Val10 = MyList[i].Value;
                       break;
                   case 10:
                       JustValuesObject.Val11 = MyList[i].Value;
                       break;
                   case 11:
                       JustValuesObject.Val12 = MyList[i].Value;
                       break;
                   case 12:
                       JustValuesObject.Val13 = MyList[i].Value;
                       break;
                   case 13:
                       JustValuesObject.Val14 = MyList[i].Value;
                       break;
                   case 14:
                       JustValuesObject.Val15 = MyList[i].Value;
                       break;
                   case 15:
                       JustValuesObject.Val16 = MyList[i].Value;
                       break;
                   case 16:
                       JustValuesObject.Val17 = MyList[i].Value;
                       break;
                   case 17:
                       JustValuesObject.Val18 = MyList[i].Value;
                       break;
                   case 18:
                       JustValuesObject.Val19 = MyList[i].Value;
                       break;
                   case 19:
                       JustValuesObject.Val20 = MyList[i].Value;
                       break;

                   default:
                       break;
               }
           }
          
           DataGridBindingList.Add(JustValuesObject);
            
        }

        private bool CanExecute_Debug_On_Command(int arg)
        {
            return (Debug_Switch ==0) ;
        }

        // Debug_Off Command
        private RelayCommand<int> _Debug_Off_Command;
        private string _StartUp;

        public ICommand Debug_Off_Command
        {
            get
            {
                return _Debug_Off_Command ??
                     (_Debug_Off_Command = new RelayCommand<int>(Execute_Debug_Off_Command, CanExecute_Debug_Off_Command));
            }
        }

        private void Execute_Debug_Off_Command(int obj)
        {
            Debug_Switch = 0;
            dt.Stop();
            _Debug_On_Command.RaiseCanExecuteChanged();
            _Debug_Off_Command.RaiseCanExecuteChanged();
            
        }

        private bool CanExecute_Debug_Off_Command(int arg)
        {
            return (Debug_Switch != 0);
        }
    }
}

  
