using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class NewsDetailsVm : ViewModelBase
    {
        #region -  Variables  -
        private readonly INavigationService _navigationService;
        private string _title;
        private bool _isLoading;
        private NewsItemContrect _selectedItem;
        #endregion
        #region -  Properties  -
        public string Icon => "news.png";
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
                RaisePropertyChanged();
            }
        }
        
        public NewsItemContrect SelectedItem
        {
            set
            {
                _selectedItem = value;
                if (_selectedItem == null)
                    return;
                RaisePropertyChanged();
            }

            get { return _selectedItem; }
        }
        #endregion
        #region -  Functions  -
        public NewsDetailsVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "تفاصيل الخبر";
        }
        public async void LoadDetailsAsync(int id)
        {
            SelectedItem = null;
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            SelectedItem = await srv.GetNewsItemAsync(id.ToString());
            IsLoading = false;
        }

        #endregion

    }
}
