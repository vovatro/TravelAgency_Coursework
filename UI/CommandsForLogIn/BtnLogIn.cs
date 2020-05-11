using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ServiceReference1;

namespace UI.CommandsForLogIn
{
    public class BtnLogIn: ICommand
    {
        //public UserDTO Users { get; set; }

        //public BtnLogIn(UsersDTO users)
        //{
        //    Users = users;
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
            //Clients.CencelAddCl();        //добавити функцію find
        }
    }
}
