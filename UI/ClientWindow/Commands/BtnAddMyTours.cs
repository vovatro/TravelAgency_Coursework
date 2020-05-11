using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.ClientWindow.Commands
{
    public class BtnAddMyTours: ICommand
    {
        //public ActualToursDTO Tours { get; set; }

        //public BtnAddMyTours(ActualToursDTO tours)
        //{
        //    Tours = tours;
        //}

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
            //Clients.CencelAddCl();        //добавити функцію add
        }
    }
}
