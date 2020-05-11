using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.Registration.Commands
{
    public class BtnOk: ICommand
    {
        //public ClientsDTO Clients { get; set; }

        //public BtnOk(Clients clients)
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
            //Clients.RegistrationOk();      //добавити функцію в клас
        }
    }
}
