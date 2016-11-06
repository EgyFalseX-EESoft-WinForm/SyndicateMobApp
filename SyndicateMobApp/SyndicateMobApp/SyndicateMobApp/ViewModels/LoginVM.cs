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
        string _inputString = "";
        private RelayCommand _loginCommand;
        private bool _isLoading;

        public LoginVm(INavigationService navigationService)
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
                    _loginCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();

                }
            }

            get { return _inputString; }
        }
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
            if (InputString == string.Empty)
                return false;
            int idValue;
            if (!int.TryParse(InputString, out idValue)) return false;
            if (idValue > 0) { return true; }
            return false;
        }
        public async void Login()
        {
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            LoginMemberContrect mem = await srv.LoginMemberAsync(_inputString);
            if (mem != null)
            {
                UserManager.Id = mem.MMashatId;
                UserManager.Type = Types.UserType.Member;
                UserManager.Member = mem;
                ServiceLocator.Current.GetInstance<BankMemberVm>().RefreshAsync();
                IsLoading = false;
                _navigationService.NavigateTo(ViewModelLocator.BankMemberPageKey);
                return;
            }
            LoginWarasaContrect wsa = await srv.LoginWarasaAsync(_inputString);
            if (wsa != null)
            {
                UserManager.Id = wsa.Code60;
                UserManager.Type = Types.UserType.Warasa;
                UserManager.Warasa = wsa;
                ServiceLocator.Current.GetInstance<BankWarasaVm>().RefreshAsync();
                IsLoading = false;
                _navigationService.NavigateTo(ViewModelLocator.BankWarasaPageKey);
                return;
            }
            // Handle error when login
            IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            await dialog.ShowError("لا يوجد بيانات لهذا الرقم", "خطــــاء", "موافق", null);

            IsLoading = false;
        }


    }
}
