using System;
using System.Windows.Input;

namespace Monster.UI.ViewModel.Commands
{
    public class CommandHandler : ICommand
    {
        private readonly Action Action;
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public CommandHandler(Action action)
        {
            Action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action?.Invoke();
        }
    }
}
