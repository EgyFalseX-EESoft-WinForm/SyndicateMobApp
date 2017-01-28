using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SyndicateMobApp.Controls;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Plugin.Geolocator.Abstractions.Position;


namespace SyndicateMobApp.ViewModels
{
    public class GpsVm : ViewModelBase
    {

        #region -  Variables  -
        private readonly INavigationService _navigationService;
        int _syndicateInx;
        int _subCommitteInx;
        //SyndicateContrect _selectedSyndicate;
        //SubCommitteContrect _selectedSubCommitte;
        private IGeolocator _geolocator;
        double _lat;
        double _long;
        private bool _isLoading;
        private ObservableCollection<SyndicateContrect> _syndicateDataList;
        private ObservableCollection<SubCommitteContrect> _subCommitteDataList;
        private ObservableCollection<Pin> _pinsList;
        
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
                if (value == -1)
                    return;
                if (_subCommitteInx != value)
                {
                    Pins.Clear();
                    Pins.Add(new Pin
                    {
                        Label = SubCommitteDataList[value].SubCommitte,
                        Position =
                                new Xamarin.Forms.Maps.Position(SubCommitteDataList[value].Lat,
                                    SubCommitteDataList[value].Long)
                    });

                    _subCommitteInx = value;
                    RaisePropertyChanged();

                }
            }

            get { return _subCommitteInx; }
        }

        public double Lat
        {
            set
            {
                if (Equals(_lat, value)) return;
                _lat = value;
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
                RaisePropertyChanged();
            }
            get { return _long; }
        }
        public string Icon => "map.png";
        public string Title => "خريطة الفرعيات و اللجان";
        
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
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
        public ObservableCollection<Pin> Pins
        {
            set
            {
                _pinsList = value;
                RaisePropertyChanged();
            }
            get { return _pinsList; }
        }
        #endregion
        #region -  Functions  -
        public GpsVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _pinsList = new ObservableCollection<Pin>();
            _syndicateInx = -1;
            _subCommitteInx = -1;
            _geolocator = CrossGeolocator.Current;
            _geolocator.DesiredAccuracy = 50;
            LoadSyndicateDataList();
            //GetDeviceLocation();
        }
        public bool ValidInput()
        {
            return true;
            //if (IsLoading)
            //    return false;
            //if (SyndicateInx == -1 || SubCommitteInx == -1 || Lat.Equals(0) || Long.Equals(0))
            //    return false;
            //return true;
        }
        public async void ShowCoord()
        {
            IsLoading = true;
            await Task.Run(() =>
            {
                // Get current location before saving.
                GetDeviceLocation();
            });
            //ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            //srv.PostSubCommitteUriAsync(SubCommitteDataList[SubCommitteInx].SubCommitteId, _lat, _long);
            //IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            //await dialog.ShowError("تم حفـظ الاحداثيات", "تم الحفـــظ", "موافق", null);

            IsLoading = false;
        }
        private async void GetDeviceLocation()
        {
            try
            {
                Position position = await _geolocator.GetPositionAsync(20000);
                Lat = position.Latitude;
                Long = position.Longitude;
            }
            catch (GeolocationException ex)
            {
                // Handle error when getting location
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
        }
        private async void LoadSyndicateDataList()
        {
            IsLoading = true;
            try
            {
                ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
                SyndicateDataList = await srv.GetSyndicateAsync();
            }
            catch (GeolocationException ex)
            {
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
            IsLoading = false;
        }
        private async void LoadSubCommitteDataList()
        {
            if (SyndicateInx == -1) return;
            IsLoading = true;
            try
            {
                ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
                SubCommitteDataList = await srv.GetSubCommitteUriAsync(SyndicateDataList[SyndicateInx].SyndicateId.ToString());
            }
            catch (GeolocationException ex)
            {
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
            IsLoading = false;
        }

        #endregion

    }
}
