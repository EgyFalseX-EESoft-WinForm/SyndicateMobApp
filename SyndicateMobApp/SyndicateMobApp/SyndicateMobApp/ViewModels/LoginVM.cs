using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyndicateMobApp.ViewModels
{
    public class LoginVm : INotifyPropertyChanged
    {
        string _inputString = "";

        public LoginVm()
        {
            LoginCommand = new Command(Login);
        }

        public void Login()
        {
            string aaaa;
        }

        // Public properties
        public string InputString
        {
            protected set
            {
                if (_inputString != value)
                {
                    _inputString = value;
                    OnPropertyChanged("InputString");
                    // Perhaps the delete button must be enabled/disabled.
                    ((Command)this.LoginCommand).ChangeCanExecute();
                }
            }

            get { return _inputString; }
        }

        // ICommand implementations
        public ICommand LoginCommand { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
        }

    }
}
