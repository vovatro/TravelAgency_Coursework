using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.ClientWindow.Commands
{
    public class CbSelectCity: ICommand
    {
        public ShowPlacesDTO ShowPlaces { get; set; }

        public CbSelectCountry(ShowPlacesDTO showPlaces)
        {
            ShowPlaces = showPlaces;
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
            //ShowPlaces.selCountry();      //функція getitems
        }
    }
}
