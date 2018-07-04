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
    public class WarasaActivateVisaByHafzaVm : ViewModelBase
    {
        
        #region -  Variables  -
        private readonly INavigationService _navigationService;
        private ObservableCollection<ActivateVisaContrect> _dataList;
        private bool _isLoading = false;
        private string _title;
        string _inputString = "";
        private RelayCommand _searchCommand;
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
                    _searchCommand.RaiseCanExecuteChanged();
                    _executeCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();
                }
            }

            get { return _inputString; }
        }
        public string Icon => "bank32.png";
        public RelayCommand SearchCommand => _searchCommand ?? (_searchCommand = new RelayCommand(SearchAsync, ValidInput));
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
        public ObservableCollection<ActivateVisaContrect> DataList
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
        public int HafzaCount
        {
            set
            {
                RaisePropertyChanged();
            }
            get { return DataList.Count; }
        }
        #endregion
        #region -  Functions  -
        public WarasaActivateVisaByHafzaVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "تفعيــل الفيزا لحافظة ورثة";
            _dataList = new ObservableCollection<ActivateVisaContrect>();
        }
        public async void SearchAsync()
        {
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            DataList = await srv.GetWarasaVisaByHafzaAsync(_inputString);
            HafzaCount = DataList.Count;
            IsLoading = false;
        }
        public async void ExecuteAsync()
        {
            IsLoading = true;
            string visas = string.Join("|", from q in DataList where q.Active == true select q.Visa);
            if (visas.Trim() == string.Empty)
            {
                await ServiceLocator.Current.GetInstance<IDialogService>().ShowError("يجب اختيار فيزا علي الاقل للتفعيل", "خطــــاء", "موافق", null);
                return;
            }
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            srv.PostActiveWarasaVisaAsync(visas);
            await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage("تم التفعيـــل", "نتيجــة العمليــة", "موافق", null);
            SearchAsync();
            IsLoading = false;
        }
        #endregion

    }
}
