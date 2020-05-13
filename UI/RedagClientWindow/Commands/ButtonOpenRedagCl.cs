using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Classes;
using UI.ServiceReference1;

namespace UI.RedagClientWindow.Commands
{
    public class ButtonOpenRedagCl : ICommand
    {
        public ClientsAgency Clients { get; set; }

        public ButtonOpenRedagCl(ClientsAgency clients)
        {
            Clients = clients;
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
            if ((parameter as PersonDTO) != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            Clients.OpenRadag();
        }
    }
}
