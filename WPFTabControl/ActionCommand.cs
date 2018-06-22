using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTabControl
{
    public class ActionCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<Object> predicate;

        public ActionCommand(Action<Object> action) : this(action, null)
        {

        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>.");
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (this.predicate == null)
            {
                return true;
            }
            return this.predicate(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
