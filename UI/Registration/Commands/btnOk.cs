using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Classes;

namespace UI.Registration.Commands
{
    public class BtnOk: ICommand
    {
        private Registr registr;

        public BtnOk(Registr registr)
        {
            this.registr = registr;
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
            registr.Ok();
        }
    }
}
