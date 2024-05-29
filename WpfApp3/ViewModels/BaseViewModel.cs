using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Models;
using WpfApp3.Commands;
using WpfApp3.DataBase;
using WpfApp3.Migrations;
using WpfApp3.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfApp3.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
