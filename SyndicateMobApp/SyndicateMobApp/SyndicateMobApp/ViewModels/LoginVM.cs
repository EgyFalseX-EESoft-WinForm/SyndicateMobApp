using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class LoginVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        string _username = "";
        string _password = "";
        private RelayCommand _loginCommand;
        private bool _isLoading;

        public LoginVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
        }
        // Public properties
        public string Username
        {
            set
            {
                if (_username != value)
                {
                    _username = value;
                    // Perhaps the login button must be enabled/disabled.
                    _loginCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();

                }
            }

            get { return _username; }
        }
        public string Password
        {
            set
            {
                if (_password != value)
                {
                    _password = value;
                    // Perhaps the login button must be enabled/disabled.
                    _loginCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();

                }
            }

            get { return _password; }
        }

        public string Logo => "logo.png";
        public RelayCommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(Login, ValidInput));

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                _loginCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();

            }
        }
        // Functions
        public bool ValidInput()
        {
            if (IsLoading)
                return false;
            if (_username == string.Empty || _password == string.Empty)
                return false;
            return true;
        }
        public async void Login()
        {
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            try
            {
                LoginContrect loginCon = await srv.LoginAsync(Username, Password);
                if (loginCon == null)
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowError("خطـاء في اسم المستخدم او كلمة المرور", "خطــــاء", "موافق", null);
                else
                {
                    ((NavigationService)_navigationService).NavigateToclearPageStack(ViewModelLocator.HomePageKey, true);
                    UserManager.CurrentUser = loginCon;
                    UserManager.Authenticated = true;
                }
            }
            catch (System.Exception ex)
            {
                // Handle error when login
                await ServiceLocator.Current.GetInstance<IDialogService>().ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
            IsLoading = false;
        }


    }
}
