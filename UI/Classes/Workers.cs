using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Registration;
using UI.ServiceReference1;
using UI.WorkerWindow.Commands;

namespace UI.Classes
{
    public class Workers : INotifyPropertyChanged
    {
        AgensyServiceClient proxy = null;

        public BtnAddWorker ButtonAddWork { get; set; }


        public Workers()
        {
            proxy = new AgensyServiceClient();

            getWorkers();

            ButtonAddWork = new BtnAddWorker(this);
        }

        private RegistrationWindow addWorkWind = null;
        public RegistrationWindow AddWorkWind { get => addWorkWind; set => addWorkWind = value; }

        public async void getWorkers()
        {

            C_LIST = from i in await proxy.GetAllPersonAsync()
                     where i.PersonStatus != "client"
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


        public void OpenAddWindow()
        {
            try
            {
                addWorkWind = new RegistrationWindow();
                addWorkWind.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
