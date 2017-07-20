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
    public class BankWarasaVm : ViewModelBase
    {

        #region -  Variables  -
        private readonly INavigationService _navigationService;
        private ObservableCollection<BankWarasaContrect> _dataList;
        private bool _isLoading = false;
        private string _title;
        private string _ads;
        string _inputString = "";
        private RelayCommand _executeCommand;
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
                    _executeCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();
                }
            }

            get { return _inputString; }
        }
        public string Icon => "bank32.png";
        public RelayCommand ExecuteCommand => _executeCommand ?? (_executeCommand = new RelayCommand(ExecuteAsync, ValidInput));
        public bool ValidInput()
        {
            if (IsLoading)
                return false;
            if (InputString == string.Empty)
                return false;
            int idValue;
            if (!int.TryParse(InputString.NumericNormalize(), out idValue)) return false;
            if (idValue > 0) { return true; }
            return false;
        }
        public ObservableCollection<BankWarasaContrect> DataList
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
        public BankWarasaVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "بيـانـات البنــك ورثــة";
            _dataList = new ObservableCollection<BankWarasaContrect>();
            Ads = Helpers.Ads.GetAdsPath();

        }
        public async void Login()
        {
            //IsLoading = true;
            //ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            //LoginWarasaContrect wsa = await srv.LoginWarasaAsync(_inputString.NumericNormalize());
            //if (wsa != null)
            //{
            //    UserManager.Id = wsa.Code60;
            //    UserManager.Type = Types.UserType.Warasa;
            //    UserManager.Warasa = wsa;
            //    ExecuteAsync();
            //}
            //else
            //{
            //    // Handle error when login
            //    IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            //    await dialog.ShowError("لا يوجد بيانات لهذا الرقم", "خطــــاء", "موافق", null);
            //}
            //IsLoading = false;
        }
        public async void ExecuteAsync()
        {
            IsLoading = true;
            //DataList.Clear();
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            DataList = await srv.BankWarasaAsync(_inputString);
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
