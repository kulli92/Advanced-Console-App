using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using DictionaryHandler;
using GalaSoft.MvvmLight.Command;

namespace Console.ViewModel
{
  public class Console_WindowVM :INotifyPropertyChanged
    {
        public ObservableCollection<Parameter> MyList { get; set; } 
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoadedCommand {
            get
            {
                return _loadedCommand ??
                     (_loadedCommand = new RelayCommand<int>(Execute_LoadedCommand, CanExecute_LoadedCommand));
            }
        }
        private ICommand _loadedCommand;
        public AnyType JustValuesObject { get; set; } = new AnyType();
        public ObservableCollection<AnyType> DummyList { get; set; } = new ObservableCollection<AnyType>() { };

        public Console_WindowVM()   
        {
            MyList = new ObservableCollection<Parameter>() { };
            MyList = DictonaryImporter.ParameterList();
            GetLine(new object  (), new EventArgs());
        }
        private void GetLine(object sender, EventArgs e)
        {
            MyList = DictonaryImporter.ParameterList();
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

                    default:
                        break;
                }
            }
            DummyList.Add(JustValuesObject);
            /*
            Random ra = new Random();
            DummyList.Add(new AnyType {
                Val1 = DateTime.Now.ToString(),
                Val2 = ra.Next(1, 1000).ToString(),
                Val3 = ra.Next(1, 1000).ToString(),
                Val4 = ra.Next(1, 1000).ToString(),
                Val5 = ra.Next(1, 1000).ToString(),
                Val6 = ra.Next(1, 1000).ToString(),
                Val7 = ra.Next(1, 1000).ToString(),
                Val8 = ra.Next(1, 1000).ToString(),
                Val9 = ra.Next(1, 1000).ToString(),

            });
            //Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => counter = counter +"added"));App.Current.MainWindow.Dispatcher
       */
        }
        private bool CanExecute_LoadedCommand(int arg)
        {
            return true;
        }
        private void Execute_LoadedCommand(int obj)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1000);
            dt.Tick += GetLine;
            dt.Start();
        }
        protected void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
