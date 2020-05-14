using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UI.ServiceReference1;
using UI.WorkerWindow.Commands;

namespace UI.Classes
{
    public class ProfilWorker : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;

        public BtnRedagInfoWorker ButtonRedagInfoW { get; set; }

        public ProfilWorker(PersonDTO pers)
        {
            proxy = new AgensyServiceClient();
            Person = pers;
            LastName = pers.LastName;
            FirstName = pers.FirstName;
            SurName = pers.SurName;
            Email = pers.Email;
            BirtDay = pers.DateOfBirth;
            Phone = pers.PhoneNumber;
            PersonStatus = pers.PersonStatus;
            DateOfRec = pers.DateOfCreateAccount;


            ButtonRedagInfoW = new BtnRedagInfoWorker(this);
        }

        private PersonDTO person;
        public PersonDTO Person
        {
            get { return person; }
            set { person = value; OnPropertyChanged("Person"); }
        }


        private string personStatus;
        public string PersonStatus
        {
            get { return personStatus; }
            set { personStatus = value; OnPropertyChanged("PersonStatus"); }
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

        private DateTime dateOfRec;
        public DateTime DateOfRec
        {
            get { return dateOfRec; }
            set { dateOfRec = value; OnPropertyChanged("DateOfRec"); }
        }


        private string birtDaySTR;
        public string BirtDaySTR
        {
            get { return birtDay.ToShortDateString(); }
            set { birtDaySTR = value; OnPropertyChanged("BirtDay"); }
        }


        private string dayRecSTR;
        public string DayRecSTR
        {
            get { return dateOfRec.ToShortDateString(); }
            set { dayRecSTR = value; OnPropertyChanged("DayRecSTR"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
