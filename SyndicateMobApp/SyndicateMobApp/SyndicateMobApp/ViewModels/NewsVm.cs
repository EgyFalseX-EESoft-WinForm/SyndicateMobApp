﻿using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class NewsVm : ViewModelBase
    {
        #region -  Variables  -
        private readonly INavigationService _navigationService;
        private string _title;
        private bool _isLoading;
        private ObservableCollection<NewsFrontPageContrect> _newsFrontPageListList;
        private NewsFrontPageContrect _selectedItem;
        private RelayCommand _viewItemCommand;
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
                _viewItemCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();

            }
        }
        
        public ObservableCollection<NewsFrontPageContrect> NewsFrontPageList
        {
            set
            {
                _newsFrontPageListList = value;
                RaisePropertyChanged();
            }
            get { return _newsFrontPageListList; }
        }
        public NewsFrontPageContrect SelectedItem
        {
            set
            {
                _selectedItem = value;
                if (_selectedItem == null)
                    return;
                ViewItemCommand.Execute(_selectedItem);
                SelectedItem = null;
                RaisePropertyChanged();
            }

            get { return _selectedItem; }
        }
        public RelayCommand ViewItemCommand => _viewItemCommand ?? (_viewItemCommand = new RelayCommand(ViewItem, ()=> true));
        #endregion
        #region -  Functions  -
        public NewsVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "الاخبـــــار";
            LoadNewsFrontPageDataList();
        }
        private async void LoadNewsFrontPageDataList()
        {
            //IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            NewsFrontPageList = await srv.GetNewsFrontPageAsync();
            //IsLoading = false;
        }
        public void ViewItem()
        {
            _navigationService.NavigateTo(ViewModelLocator.NewsDetailsPageKey);
            ServiceLocator.Current.GetInstance<NewsDetailsVm>().LoadDetailsAsync(_selectedItem.news_id);
        }
        #endregion

    }
}
