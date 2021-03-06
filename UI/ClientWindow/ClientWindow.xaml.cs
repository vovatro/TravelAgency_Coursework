﻿using System;
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

namespace UI.ClientWindow
{
    
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public PersonDTO personOWNER;
        public ProfilClient profilClient { get; set; }
        public MyTours myTours { get; set; }
        public NextTours actualTours { get; set; }

        public ClientWindow()
        {
            InitializeComponent();

        }

        public ClientWindow(PersonDTO person)
        {
            InitializeComponent();
            personOWNER = person;
            profilClient = new ProfilClient(personOWNER);
            myTours = new MyTours(personOWNER);
            actualTours = new NextTours(personOWNER); 
            ti_ProfilClient.DataContext = profilClient;
            ti_myTours.DataContext = myTours;
            ti_actualT.DataContext = actualTours;
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        
    }
}
