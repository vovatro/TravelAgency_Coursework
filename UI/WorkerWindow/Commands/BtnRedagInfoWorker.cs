using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Classes;

namespace UI.WorkerWindow.Commands
{
    public class BtnRedagInfoWorker : ICommand
    {
        private ProfilWorker profilWorker;

        public BtnRedagInfoWorker(ProfilWorker profilWorker)
        {
            this.profilWorker = profilWorker;
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
