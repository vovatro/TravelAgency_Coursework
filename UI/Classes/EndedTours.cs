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
    public class EndedTours : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;

        public EndedTours()
        {
            proxy = new AgensyServiceClient();
            //  getTour();
        }

        //public async void getTour()
        //{
        //    END_T_LIST = await proxy.getEndedTour();
        //}

        private List<ToursDTO> end_t_list;
        public List<ToursDTO> END_T_LIST
        {
            get
            {
                return end_t_list;
            }
            set
            {
                end_t_list = value;
                OnPropertyChanged("END_T_LIST");
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
