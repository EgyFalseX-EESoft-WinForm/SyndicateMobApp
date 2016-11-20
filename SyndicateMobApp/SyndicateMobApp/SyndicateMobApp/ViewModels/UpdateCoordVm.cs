using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class UpdateCoordVm : ViewModelBase
    {

        #region -  Variables  -
        private readonly INavigationService _navigationService;
        int _syndicateInx;
        int _subCommitteInx;
        //SyndicateContrect _selectedSyndicate;
        //SubCommitteContrect _selectedSubCommitte;
        double _lat;
        double _long;
        private RelayCommand _updateCoordCommand;
        private bool _isLoading;
        private ObservableCollection<SyndicateContrect> _syndicateDataList;
        private ObservableCollection<SubCommitteContrect> _subCommitteDataList;
        #endregion
        #region -  Properties -
        public int SyndicateInx
        {
            set
            {
                if (value == -1)
                    return;
                if (_syndicateInx != value)
                {
                    _syndicateInx = value;
                    SubCommitteInx = -1;
                    // enabled/disabled command button.
                    _updateCoordCommand.RaiseCanExecuteChanged();
                    LoadSubCommitteDataList();
                    RaisePropertyChanged();
                }
            }

            get { return _syndicateInx; }
        }
        public int SubCommitteInx
        {
            set
            {
                if (_subCommitteInx != value)
                {
                    _subCommitteInx = value;
                    //enabled/disabled command button.
                    _updateCoordCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();

                }
            }

            get { return _subCommitteInx; }
        }

        //public SyndicateContrect SelectedSyndicate
        //{
        //    set
        //    {
                
        //        if (value != null && _selectedSyndicate.SyndicateInx != value.SyndicateInx)
        //        {
        //            _selectedSyndicate = value;
        //            // enabled/disabled command button.
        //            _updateCoordCommand.RaiseCanExecuteChanged();
        //            LoadSubCommitteDataList();
        //            RaisePropertyChanged();
        //        }
        //    }

        //    get { return _selectedSyndicate; }
        //}
        //public SubCommitteContrect SelectedSubCommitte
        //{
        //    set
        //    {

        //        if (value != null && _selectedSubCommitte.SubCommitteInx != value.SubCommitteInx)
        //        {
        //            _selectedSubCommitte = value;
        //            // enabled/disabled command button.
        //            _updateCoordCommand.RaiseCanExecuteChanged();
        //            RaisePropertyChanged();
        //        }
        //    }

        //    get { return _selectedSubCommitte; }
        //}

        public double Lat
        {
            set
            {
                if (Equals(_lat, value)) return;
                _lat = value;
                //enabled/disabled command button.
                _updateCoordCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
            get { return _lat; }
        }
        public double Long
        {
            set
            {
                if (Equals(_long, value)) return;
                _long = value;
                //enabled/disabled command button.
                _updateCoordCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
            get { return _lat; }
        }
        public string Icon => "map.png";
        public string Title => "احداثيات الفرعيات و اللجان";
        public RelayCommand UpdateCoordCommand => _updateCoordCommand ?? (_updateCoordCommand = new RelayCommand(UpdateCoord, ValidInput));
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                _updateCoordCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();

            }
        }
        public ObservableCollection<SyndicateContrect> SyndicateDataList
        {
            set
            {
                _syndicateDataList = value;
                RaisePropertyChanged();
            }
            get { return _syndicateDataList; }
        }
        public ObservableCollection<SubCommitteContrect> SubCommitteDataList
        {
            set
            {
                _subCommitteDataList = value;
                RaisePropertyChanged();
            }
            get { return _subCommitteDataList; }
        }
        #endregion
        #region -  Functions  -
        public UpdateCoordVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _syndicateInx = -1;
            _subCommitteInx = -1;
            LoadSyndicateDataList();
            GetDeviceLocation();
        }
        public bool ValidInput()
        {
            if (IsLoading)
                return false;
            if (SyndicateInx == -1 || SubCommitteInx == -1 || Lat.Equals(0) || Long.Equals(0))
                return false;
            return true;
        }
        public async void UpdateCoord()
        {
            IsLoading = true;
            // Get current location before saving.
            GetDeviceLocation();
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            srv.PostSubCommitteUriAsync(SubCommitteDataList[SubCommitteInx].SubCommitteId, _lat, _long);
            IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            await dialog.ShowError("تم حفـظ الاحداثيات", "تم الحفـــظ", "موافق", null);

            IsLoading = false;
        }
        private async void GetDeviceLocation()
        {
            //IsLoading = true;
            IGeolocator locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            try
            {
                Position position = await locator.GetPositionAsync(20000);
                Lat = position.Latitude;
                Long = position.Longitude;
            }
            catch (GeolocationException ex)
            {
                // Handle error when getting location
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
            //IsLoading = false;
        }
        private async void LoadSyndicateDataList()
        {
            //IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            SyndicateDataList = await srv.GetSyndicateAsync();
            //IsLoading = false;
        }
        private async void LoadSubCommitteDataList()
        {
            if (SyndicateInx == -1) return;
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            SubCommitteDataList = await srv.GetSubCommitteUriAsync(SyndicateDataList[SyndicateInx].SyndicateId.ToString());
            IsLoading = false;
        }

        #endregion

    }
}
