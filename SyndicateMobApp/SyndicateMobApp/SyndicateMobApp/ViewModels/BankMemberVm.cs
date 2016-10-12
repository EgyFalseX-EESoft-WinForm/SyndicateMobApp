using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Services;
using Xamarin.Forms;

namespace SyndicateMobApp.ViewModels
{
    public class BankMemberVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        string _inputString = "";
        RelayCommand _loginCommand { set; get; }
        private bool _isLoading = false;

        public BankMemberVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
                    RaisePropertyChanged("InputString");
                }
            }

            get { return _inputString; }
        }
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(Login));
            }

        }
        
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");

            }
        }

        // Functions
        public async void Login()
        {
            LoginMemberContrect mem = await SyndicateService.LoginMemberAsync(_inputString);
            if (mem != null)
            {
                Helpers.NavigationService nav = new Helpers.NavigationService();
                nav.NavigateTo("");

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


    }
}
