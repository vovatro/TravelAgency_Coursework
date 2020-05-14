using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.ClientWindow.Commands;
using UI.ServiceReference1;

namespace UI.Classes
{
    public class NextTours : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;
        public PersonDTO person;
        public BtnAddMyTours ButtonAddMyTours { get; set; }
        public int bronya { get; set; }
        public ToursDTO toursBR { get; set; }

        public NextTours()
        {
            proxy = new AgensyServiceClient();
            getTour();
        }

        public NextTours(PersonDTO pers)
        {
            proxy = new AgensyServiceClient();
            person = pers;
            ButtonAddMyTours = new BtnAddMyTours(this);
            toursBR = new ToursDTO();
            getTour();
        }

        public async void getTour()
        {
            NEXT_T_LIST = await proxy.getActualTourAsync();
        }

        public void AddingMyTour()
        {
            if (bronya > 0)
            {
                ListOfTouristBuyDTO bye = new ListOfTouristBuyDTO { ClientId = person.Id, ToursId = toursBR.Id };
                for (int i = 0; i < bronya; i++)
                {
                    proxy.AddItemListOfTouristBuy(bye);
                }
                bronya = 0;
            }
            else if (bronya < 1)
            {
                MessageBox.Show("Заповніть кількість броньованих місць!!!");            
            }
            else
                MessageBox.Show("Виберіть тур для бронювання!!!");
        }

        private IEnumerable<ToursDTO> next_t_list;
        public IEnumerable<ToursDTO> NEXT_T_LIST
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
