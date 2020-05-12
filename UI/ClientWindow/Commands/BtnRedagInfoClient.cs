using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Classes;
using UI.ServiceReference1;

namespace UI.ClientWindow.Commands
{
    public class BtnRedagInfoClient : ICommand
    {
        private ProfilClient profilClient;

        public BtnRedagInfoClient(ProfilClient profilClient)
        {
            this.profilClient = profilClient;
        }

        //public ClientDTO Clients { get; set; }

        //public BtnRedagInfoClient(ClientDTO clients)
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
            //Clients.CencelAddCl();        //добавити функцію update
        }
    }
}
