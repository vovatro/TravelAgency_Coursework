using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.ServiceReference1;
using UI.RedagClientWindow;
using UI.RedagClientWindow.Commands;

namespace UI.Classes
{
    public class ClientsAgency : INotifyPropertyChanged
    {
        AgensyServiceClient proxy = null;

        public PersonDTO selectClient { get; set; }

        public ButtonOpenRedagCl ButtonClick { get; set; }
        public ButtonOkRedag ButtonOk { get; set; }
        public ButtonCencelRedag ButtonCen { get; set; }


        public ClientsAgency()
        {
            proxy = new AgensyServiceClient();
            selectClient = new PersonDTO();
            getClients();
            ButtonClick = new ButtonOpenRedagCl(this);
            ButtonOk = new ButtonOkRedag(this);
            ButtonCen = new ButtonCencelRedag(this);
        }



        public async void getClients()
        {

            C_LIST = from i in await proxy.GetAllPersonAsync()
                     where i.PersonStatus == "client"
                     select new PersonDTO
                     {
                         LastName = i.LastName,
                         FirstName = i.FirstName,
                         SurName = i.SurName,
                         Email = i.Email,
                         DateOfBirth = i.DateOfBirth,
                         DateOfCreateAccount = i.DateOfCreateAccount,
                         Id = i.Id,
                         PersonStatus = i.PersonStatus,
                         ExtensionData = i.ExtensionData,
                         Login = i.Login,
                         Password = i.Password,
                         ListClientShowInfoTour = i.ListClientShowInfoTour,
                         ListOfTouristBuy = i.ListOfTouristBuy,
                         PhoneNumber = i.PhoneNumber,
                         ResponsibleForTheTours = i.ResponsibleForTheTours
                     };
        }





        private RedagClientWindow.RedagClientWindow redagWindow = null;
        public RedagClientWindow.RedagClientWindow RedagWindow { get => redagWindow; set => redagWindow = value; }




        private IEnumerable<PersonDTO> c_list;
        public IEnumerable<PersonDTO> C_LIST
        {
            get
            {
                return c_list;
            }
            set
            {
                c_list = value;
                OnPropertyChanged("C_LIST");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public void OpenRadag()
        {
            redagWindow = new RedagClientWindow.RedagClientWindow(/*selectClient*/) { DataContext = this };
            RedagWindow.ShowDialog();
        }

        public void CencelRadag()
        {
            redagWindow.Close();
        }

        public void OkRadag()
        {
            //if (RedagWindow.tb_PIB.Text != "" && RedagWindow.tb_EMAIL.Text != "" && RedagWindow.tb_PHONE.Text != "" && RedagWindow.tp_Birt.SelectedDate != null)
            //{
            //    h.SetClient(selectClient.Id, RedagWindow.tb_PIB.Text, RedagWindow.tb_EMAIL.Text, RedagWindow.tb_PHONE.Text, RedagWindow.tp_Birt.SelectedDate.Value.Date);
            //    redagWindow.Close();
            //}
        }
    }
}
