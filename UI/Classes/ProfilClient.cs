using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.ClientWindow.Commands;
using UI.ServiceReference1;

namespace UI.Classes
{
    public class ProfilClient : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;

        public BtnRedagInfoClient ButtonRedagInfoCl { get; set; }

        public ProfilClient(PersonDTO pers)
        {
            proxy = new AgensyServiceClient();
            Person = pers;
            LastName = pers.LastName;
            FirstName = pers.FirstName;
            SurName = pers.SurName;
            Email = pers.Email;
            BirtDay = pers.DateOfBirth;
            Phone = pers.PhoneNumber;

            

            ButtonRedagInfoCl = new BtnRedagInfoClient(this);
        }

        private PersonDTO person;
        public PersonDTO Person
        {
            get { return person; }
            set { person = value; OnPropertyChanged("Person"); }
        }


        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }


        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }


        private string surName;
        public string SurName
        {
            get { return surName; }
            set { surName = value; OnPropertyChanged("SurName"); }
        }


        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }


        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }


        private DateTime birtDay;
        public DateTime BirtDay
        {
            get { return birtDay; }
            set { birtDay = value; OnPropertyChanged("BirtDay"); }
        }


        private string birtDaySTR;
        public string BirtDaySTR
        {
            get { return birtDay.ToShortDateString(); }
            set { birtDaySTR = value; OnPropertyChanged("BirtDay"); }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
