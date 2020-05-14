using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.Classes;
using UI.ServiceReference1;

namespace UI.WorkerWindow
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public PersonDTO personOWNER { get; set; }
        public ProfilWorker profilWork { get; set; }


        public WorkerWindow()
        {
            InitializeComponent();
        }
        

        public WorkerWindow(PersonDTO person)
        {
            InitializeComponent();
            personOWNER = person;
            profilWork = new ProfilWorker(personOWNER);
            ti_ProfilWorker.DataContext = profilWork;
        }


        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
