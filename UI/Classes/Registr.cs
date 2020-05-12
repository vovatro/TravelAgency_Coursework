using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Registration.Commands;
using UI.ServiceReference1;

namespace UI.Classes
{
    public class Registr : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;

        public BtnOk ButtonOk { get; set; }
        public BtnCencel ButtonCencel { get; set; }

        public Registr()
        {
            proxy = new AgensyServiceClient();
            PersonStatus = "client";
            birtDay = new DateTime();
            birtDay = DateTime.Now;
            Login = "";
            LastName = "";
            FirstName = "";
            SurName = "";
            Email = "";
            Phone = "";
            Password = "";


            ButtonOk = new BtnOk(this);
            ButtonCencel = new BtnCencel(this);
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


        private string personStatus;
        public string PersonStatus
        {
            get { return personStatus; }
            set { personStatus = value; OnPropertyChanged("PersonStatus"); }
        }


        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged("Login"); }
        }


        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



        public async void Ok()
        {
            try
            {
                if (Login != "")
                {
                    if (await proxy.IsUniqueLoginAsync(Login))
                    {
                        if (LastName != "" && FirstName != "" && SurName != "" && Email != "" && Phone != "" && BirtDay != null)
                        {
                            PersonDTO temp = new PersonDTO();
                            temp.LastName = LastName;
                            temp.FirstName = FirstName;
                            temp.SurName = SurName;
                            temp.Email = Email;
                            temp.PhoneNumber = Phone;
                            temp.PersonStatus = PersonStatus;
                            temp.DateOfBirth = BirtDay;
                            temp.DateOfCreateAccount = DateTime.Now;
                            temp.Login = Login;
                            temp.Password = Password;
                            await proxy.RegistrationAsync(temp);
                            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();

                        }
                        else
                            MessageBox.Show("Заповніть всі пусті поля!!!");
                    }
                    else
                        MessageBox.Show("Користувач з таким логіном вже існує!!!");
                }
                else
                    MessageBox.Show("Заповніть всі пусті поля!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }




        public void Cencel()
        {
            try
            {
                Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
