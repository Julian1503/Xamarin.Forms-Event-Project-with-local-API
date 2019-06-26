using System;
using System.Windows.Input;

namespace SmartEvent.ModelView
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _execute;
        private Func<bool> _canExecute;
        private ICommand crearUsuarioCommand;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(ICommand crearUsuarioCommand)
        {
            this.crearUsuarioCommand = crearUsuarioCommand;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute();
            
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
        public void RaiseCanExecutedChanged()
        {
           CanExecuteChanged?.Invoke(this,new EventArgs());
        }
    }
    
}
