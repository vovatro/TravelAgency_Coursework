using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.ServiceReference1;

namespace UI.Classes
{
    public class NextTours : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;

        public NextTours()
        {
            proxy = new AgensyServiceClient();
          //  getTour();
        }

        //public async void getTour()
        //{
        //    NEXT_T_LIST = await proxy.getActualTour();
        //}

        private List<ToursDTO> next_t_list;
        public List<ToursDTO> NEXT_T_LIST
        {
            get
            {
                return next_t_list;
            }
            set
            {
                next_t_list = value;
                OnPropertyChanged("NEXT_T_LIST");
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
