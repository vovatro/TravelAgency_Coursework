using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.ServiceReference1;

namespace UI.Classes
{
    public class MyTours : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;
        public PersonDTO person;

        public MyTours(PersonDTO pers)
        {
            proxy = new AgensyServiceClient();
            person = pers;
            getTour();
        }

        public async void getTour()
        {
            MY_T_LIST = await proxy.getMyTourAsync(person);
        }

        private IEnumerable<ToursDTO> my_t_list;
        public IEnumerable<ToursDTO> MY_T_LIST
        {
            get
            {
                return my_t_list;
            }
            set
            {
                my_t_list = value;
                OnPropertyChanged("MY_T_LIST");
            }
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
