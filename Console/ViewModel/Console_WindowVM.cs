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
        public string[] a { get; set; } = new string[] { "ss", "dd", "dfsf" };
        public string count { get; set; } = "theh anme";
        public string counter 
        {
            get { return _counter; }
            set
            {
                if (_counter != value) return;
                _counter = value;
                RaisePropertyChanged();
            }
        }
        public string StringCounter
        {
            get { return _stringCounter; }
            set
            {
                if (value == _stringCounter)
                    return;
                _stringCounter = value;
                RaisePropertyChanged();

            }
        }
        private string _stringCounter;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoadedCommand {
            get
            {
                return _loadedCommand ??
                     (_loadedCommand = new RelayCommand<int>(Execute_LoadedCommand, CanExecute_LoadedCommand));
            }
        }
        private ICommand _loadedCommand;
        private string _counter;

        public Console_WindowVM()
            
        {
            MyList = DictonaryImporter.ParameterList();
          

        }

        private void GetLine(object sender, EventArgs e)
        {
           MyList.Add( new Parameter { ParamName = "sexond", Value = "111111 00000000 111111111 11111111111 1111111111111 1111111111", Index = 2, MaxValue = "sdf", MinValue = "dff" });
            //Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => counter = counter +"added"));App.Current.MainWindow.Dispatcher
        }

        private bool CanExecute_LoadedCommand(int arg)
        {
            return true;
        }
        private void Execute_LoadedCommand(int obj)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += GetLine;
            dt.Start();
        }
        protected void RaisePropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

}
