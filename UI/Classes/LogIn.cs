using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.CommandsForLogIn;
using UI.Registration;
using UI.ServiceReference1;
using UI.ClientWindow;
using UI.WorkerWindow;

namespace UI.Classes
{
    public class LogIn : INotifyPropertyChanged
    {
        AgensyServiceClient proxy;

        public BtnLogIn ButtonLogin { get; set; }
        public BtnRegistration ButtonRegistr { get; set; }

        public LogIn()
        {
            proxy = new AgensyServiceClient();

            ButtonLogin = new BtnLogIn(this);
            ButtonRegistr = new BtnRegistration(this);
        }

        public LogIn(string log)
        {
            proxy = new AgensyServiceClient();
            Login = log;

            ButtonLogin = new BtnLogIn(this);
            ButtonRegistr = new BtnRegistration(this);
        }

        private RegistrationWindow registrWind = null;
        public RegistrationWindow RegistrWind { get => registrWind; set => registrWind = value; }

        private ClientWindow.ClientWindow clientWind = null;
        public ClientWindow.ClientWindow ClientWind { get => clientWind; set => clientWind = value; }

        private WorkerWindow.WorkerWindow workerWind = null;
        public WorkerWindow.WorkerWindow WorkerWind { get => workerWind; set => workerWind = value; }


        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }


        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



        public async void OpenNewWindow()
        {
            try
            {
                if (!await proxy.IsUniqueLoginAsync(Login))
                {
                    PersonDTO temp = null;
                    temp = await proxy.LoginAsync(Login, Password);

                    if (temp != null)
                    {
                        if (temp.PersonStatus == "client")
                        {
                            clientWind = new ClientWindow.ClientWindow(temp);
                            clientWind.Show();
                            Application.Current.MainWindow.Hide();
                        }
                        else
                        {
                            workerWind = new WorkerWindow.WorkerWindow(temp);
                            workerWind.Show();
                            Application.Current.MainWindow.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль введено невірно!!!");
                    }
                }
                else
                MessageBox.Show("Користувача з таким логіно неіснує!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }



        public void OpenRegistrWindow()
        {
            try
            {
                registrWind = new RegistrationWindow();
                registrWind.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
