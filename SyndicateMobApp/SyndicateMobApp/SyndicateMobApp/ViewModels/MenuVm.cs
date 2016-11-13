﻿using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Helpers;

namespace SyndicateMobApp.ViewModels
{
    public class MenuVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<MasterPageItem> _dataList;
        private string _title;
        private RelayCommand _navCommand;
        private MasterPageItem _selectedItem;
        
        public MenuVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "نقابة المهن التعليمية";
            LoadItems();
            
        }
        private void LoadItems()
        {
            _dataList = new ObservableCollection<MasterPageItem>()
            {
                 new MasterPageItem
                {
                     Title = "الاخبـار",
                     //IconSource = "SyndicateMobApp.Resources.Bank32.png",
                     IconSource = "bank32.png",
                     PageKey = ViewModelLocator.NewsPageKey
                },
                new MasterPageItem
                {
                    Title = "بيانات البنك",
                    //IconSource = "http://falsex-001-site2.atempurl.com/MobileAppAssets/Images/GPSValidationPage32.png",
                    IconSource = "bank32.png",
                    PageKey = UserManager.Type == Types.UserType.Member ? ViewModelLocator.BankMemberPageKey : ViewModelLocator.BankWarasaPageKey
                },
            };
        }

        // Public properties
        public ObservableCollection<MasterPageItem> DataList
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
        public MasterPageItem SelectedItem
        {
            set
            {
                _selectedItem = value;
                if (_selectedItem == null)
                    return;
                NavigateCommand.Execute(_selectedItem);
                SelectedItem = null;
                RaisePropertyChanged();

            }

            get { return _selectedItem; }
        }
        public RelayCommand NavigateCommand => _navCommand ?? (_navCommand = new RelayCommand(GoTo));

        public void GoTo()
        {
            if (_selectedItem == null)
            {
                return;
            }
            //if (_selectedItem == typeof(string))
            //    _navigationService.NavigateTo(ViewModelLocator.BankMemberPageKey);
            //this.Detail = new NavigationPage((Page)Activator.CreateInstance(((MasterPageItem)args.SelectedItem).TargetType));
            _navigationService.NavigateTo(_selectedItem.PageKey);
        }
    }
}