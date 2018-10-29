using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Console.ViewModel
{
    internal class RelayCommandMod<T> : RelayCommand<T>
    {
        public RelayCommandMod(Action<T> execute, bool keepTargetAlive = false) : base(execute, keepTargetAlive)
        {
        }

        public RelayCommandMod(Action<T> execute, Func<T, bool> canExecute, bool keepTargetAlive = false) : base(execute, canExecute, keepTargetAlive)
        {
        }

        new public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}