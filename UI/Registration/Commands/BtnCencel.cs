using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.Registration.Commands
{
    public class BtnCencel: ICommand
    {
        //public ClientsDTO Clients { get; set; }

        //public BtnCencel(ClientsDTO clients)
        //{
        //    Clients = clients;
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
            //Clients.CencelAddCl();      //добавити функцію в клас
        }
    }
}
