using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private string _icon;
        private RelayCommand _navCommand;
        private MasterPageItem _selectedItem;
        
        public MenuVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "نقابة المهن التعليمية";
            Icon = "logo.png";
            LoadItems();
            
        }
        private void LoadItems()
        {
            _dataList = new ObservableCollection<MasterPageItem>()
            {
                 new MasterPageItem
                {
                     Id = 1,
                     Title = "الاخبـار",
                     IconSource = "news.png",
                     PageKey = ViewModelLocator.NewsPageKey,
                     Visible = true,
                },
                new MasterPageItem
                {
                    Id = 2,
                    Title = "بيانات البنك اعضاء",
                    IconSource = "bankmember.png",
                    PageKey = ViewModelLocator.BankMemberPageKey,
                    Visible = true,
                },
                new MasterPageItem
                {
                    Id = 3,
                    Title = "بيانات البنك ورثة",
                    IconSource = "bankwarasa.png",
                    PageKey = ViewModelLocator.BankWarasaPageKey,
                    Visible = true,
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
        public string Icon
        {
            set
            {
                _icon = value;
                RaisePropertyChanged();
            }

            get { return _icon; }
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

        public void ActiveMenu(bool activate)
        {
            return;
            //foreach (MasterPageItem masterPageItem in _dataList.Where(masterPageItem => masterPageItem.Id != 1))
            //{
            //    masterPageItem.Visible = activate;
            //}
        }
    }
}
