using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SyndicateMobApp.Services;
using Xamarin.Forms;

namespace SyndicateMobApp.ViewModels
{
    public class LoginVm : INotifyPropertyChanged
    {
        string _inputString = "";
        ICommand _loginCommand { set; get; }

        public LoginVm()
        {

        }
        // Public properties
        public string InputString
        {
            set
            {
                if (_inputString != value)
                {
                    _inputString = value;
                    // Perhaps the login button must be enabled/disabled.
                    _loginCommand.CanExecute(_inputString != string.Empty);
                    OnPropertyChanged("InputString");
                }
            }

            get { return _inputString; }
        }
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(Login));
            }

        }

        // Functions
        public async void Login()
        {
            LoginMemberContrect mem = await SyndicateService.LoginMemberAsync(_inputString);
            if (mem != null)
            {
                
                // To Do
                return;
            }
            LoginWarasaContrect wsa = await SyndicateService.LoginWarasaAsync(_inputString);
            if (wsa != null)
            {
                // To Do
                return;
            }
            // To Do
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
