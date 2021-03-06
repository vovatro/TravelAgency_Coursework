﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Classes;

namespace UI.ClientWindow.Commands
{
    public class BtnAddMyTours: ICommand
    {
        private NextTours nextTours;

        public BtnAddMyTours(NextTours nextTours)
        {
            this.nextTours = nextTours;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.nextTours.AddingMyTour();
        }
    }
}
