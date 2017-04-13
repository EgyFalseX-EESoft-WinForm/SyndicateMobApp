using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;
using Xamarin.Forms;



namespace SyndicateMobApp.ViewModels
{
    public class BankMemberVm : ViewModelBase
    {
        
        #region -  Variables  -
        private readonly INavigationService _navigationService;
        private ObservableCollection<BankMemberContrect> _dataList;
        private bool _isLoading = false;
        private string _title;
        private string _ads;
        string _inputString = "";
        private RelayCommand _loginCommand;
        #endregion
        #region -  Properties -
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
        public string Icon => "bank32.png";
        public RelayCommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(Login, ValidInput));
        public bool ValidInput()
        {
            //String aaa = "";
            
            if (IsLoading)
                return false;
            if (InputString == string.Empty)
                return false;
            
            int idValue;
            if (!int.TryParse(InputString.NumericNormalize(), out idValue)) return false;
            if (idValue > 0) { return true; }
            return false;
        }
        public ObservableCollection<BankMemberContrect> DataList
        {
            set
            {
                _dataList = value;
                RaisePropertyChanged();
            }

            get { return _dataList; }
        }
        public string Title
        {
            set
            {
                _title = value;
                RaisePropertyChanged();
            }

            get { return _title; }
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
        #endregion
        #region -  Functions  -
        public BankMemberVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "بيـانـات البنــك اعضــاء";
            Ads = Helpers.Ads.GetAdsPath();
            _dataList = new ObservableCollection<BankMemberContrect>();
        }
        public async void Login()
        {
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            LoginMemberContrect mem = await srv.LoginMemberAsync(_inputString.NumericNormalize());
            if (mem != null)
            {
                UserManager.Id = mem.MMashatId;
                UserManager.Type = Types.UserType.Member;
                UserManager.Member = mem;
                RefreshAsync();
            }
            else
            {
                // Handle error when login
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError("لا يوجد بيانات لهذا الرقم", "خطــــاء", "موافق", null);
            }
            IsLoading = false;
        }
        public async void RefreshAsync()
        {
            IsLoading = true;
            //DataList.Clear();
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            DataList = await srv.BankMemberAsync(UserManager.Id.ToString());
            IsLoading = false;
        }
        public string Ads
        {
            set
            {
                _ads = value;
                RaisePropertyChanged();
            }

            get { return _ads; }
        }
        #endregion

    }
}
