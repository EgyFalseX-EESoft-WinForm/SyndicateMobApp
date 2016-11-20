using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Helpers;

namespace SyndicateMobApp.ViewModels
{
    public class NewsVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _title;

        public NewsVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "الاخبـــــار";
        }
        // Public properties
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

    }
}
