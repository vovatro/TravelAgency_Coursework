using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Classes;

namespace UI.CommandsForLogIn
{
    public class BtnRegistration: ICommand
    {
        private LogIn logIn;

        public BtnRegistration(LogIn logIn)
        {
            this.logIn = logIn;
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
            return true;
        }

        public void Execute(object parameter)
        {
            logIn.OpenRegistrWindow();
        }
    }
}
