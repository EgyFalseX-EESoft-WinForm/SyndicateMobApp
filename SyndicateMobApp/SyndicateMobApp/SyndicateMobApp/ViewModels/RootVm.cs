using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Helpers;

namespace SyndicateMobApp.ViewModels
{
    public class RootVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _title;

        public RootVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "نقابة المهن التعليمية";
        }
        // Public properties
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
