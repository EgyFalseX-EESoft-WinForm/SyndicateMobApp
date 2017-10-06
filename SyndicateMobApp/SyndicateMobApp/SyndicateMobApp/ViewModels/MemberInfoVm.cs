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
    public class MemberInfoVm : ViewModelBase
    {

        #region -  Variables  -
        private readonly INavigationService _navigationService;
        private MemberInfoContrect _data;
        private bool _isLoading = false;
        private string _title;
        private string _ads;
        string _inputString = "";
        private RelayCommand _getInfoCommand;
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
                    _getInfoCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();
                }
            }

            get { return _inputString; }
        }
        public string Icon => "info.png";
        public RelayCommand GetInfoCommand => _getInfoCommand ?? (_getInfoCommand = new RelayCommand(GetInfo, ValidInput));
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
        public MemberInfoContrect Data
        {
            set
            {
                _data = value;
                RaisePropertyChanged();
            }

            get { return _data; }
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
        public MemberInfoVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "بيـانـات اعضــاء";
            _data = new MemberInfoContrect(".", ".", ".", "", "", "", "");
            Ads = Helpers.Ads.GetAdsPath();
        }
        public async void GetInfo()
        {
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            MemberInfoContrect result = await srv.GetMemberInfoAsync(_inputString.NumericNormalize());
            if (result != null)
            {
                Data = new MemberInfoContrect(result.Name, result.Syndicate, result.Subcommitte, result.Hafzano, result.Hafzadate, result.Activate, result.ActivateDate);
            }
            else
            {
                Data = new MemberInfoContrect();
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError("لا يوجد بيانات لهذا الرقم", "خطــــاء", "موافق", null);
            }
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
