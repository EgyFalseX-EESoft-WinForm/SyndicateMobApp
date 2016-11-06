﻿using System;
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
    public class BankMemberVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        private ObservableCollection<BankMemberContrect> _dataList;

        private bool _isLoading = false;
        private string _title;

        public BankMemberVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "بيــانــات البنــــك";
            _dataList = new ObservableCollection<BankMemberContrect>();
        }
        public async void RefreshAsync()
        {
            IsLoading = true;
            DataList.Clear();
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            DataList = await srv.BankMemberAsync(UserManager.Id.ToString());
            IsLoading = false;
        }

        // Public properties
        public ObservableCollection<BankMemberContrect> DataList
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

    }
}
