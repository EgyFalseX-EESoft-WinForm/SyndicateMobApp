using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Helpers;

namespace SyndicateMobApp.ViewModels
{
    public class MenuSubAdminVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<MasterPageItem> _dataList;
        private string _title;
        private string _icon;
        private RelayCommand _navCommand;
        private MasterPageItem _selectedItem;
        
        public MenuSubAdminVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "نقابة المهن التعليمية";
            Icon = "home32.png";
            LoadItems();
            
        }
        private void LoadItems()
        {
            _dataList = new ObservableCollection<MasterPageItem>()
            {
                new MasterPageItem
                {
                    Id = 6,
                    Title = "طلب امانات اعضاء",
                    IconSource = "info.png",
                    PageKey = ViewModelLocator.MemberAmanatPageKey,
                    Visible = true,
                },

                new MasterPageItem
                {
                    Id = 7,
                    Title = "تفعيل فيزا اعضاء",
                    IconSource = "info.png",
                    PageKey = ViewModelLocator.ActivateMemberVisaPageKey,
                    Visible = true,
                },
                new MasterPageItem
                {
                    Id = 8,
                    Title = "تفعيل فيزا ورثة",
                    IconSource = "info.png",
                    PageKey = ViewModelLocator.ActivateWarasaVisaPageKey,
                    Visible = true,
                },
                new MasterPageItem
                {
                    Id = 9,
                    Title = "تفعيل فيزا حافظة اعضاء",
                    IconSource = "info.png",
                    PageKey = ViewModelLocator.MemberActivateVisaByHafzaPageKey,
                    Visible = true,
                },
                new MasterPageItem
                {
                    Id = 10,
                    Title = "تفعيل فيزا حافظة ورثة",
                    IconSource = "info.png",
                    PageKey = ViewModelLocator.WarasaActivateVisaByHafzaPageKey,
                    Visible = true,
                },
                //new MasterPageItem
                //{
                //    Id = 11,
                //    Title = "ايقاف فيزا اعضاء",
                //    IconSource = "info.png",
                //    PageKey = ViewModelLocator.StopMemberVisaPageKey,
                //    Visible = true,
                //},
                //new MasterPageItem
                //{
                //    Id = 12,
                //    Title = "ايقاف فيزا ورثة",
                //    IconSource = "info.png",
                //    PageKey = ViewModelLocator.StopWarasaVisaPageKey,
                //    Visible = true,
                //},
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

        public Xamarin.Forms.MasterDetailPage Master { get; set; }

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
            //Master.IsPresented = false;
            switch (_selectedItem.PageKey)
            {
                //Authentication required
                case ViewModelLocator.MemberAmanatPageKey:
                case ViewModelLocator.ActivateMemberVisaPageKey:
                case ViewModelLocator.ActivateWarasaVisaPageKey:
                case ViewModelLocator.MemberActivateVisaByHafzaPageKey:
                case ViewModelLocator.WarasaActivateVisaByHafzaPageKey:
                case ViewModelLocator.StopMemberVisaPageKey:
                case ViewModelLocator.StopWarasaVisaPageKey:

                    if (UserManager.Authenticated)
                        _navigationService.NavigateTo(_selectedItem.PageKey);
                    else
                        _navigationService.NavigateTo(ViewModelLocator.LoginPageKey);
                    break;
                default://Authentication not required
                    _navigationService.NavigateTo(_selectedItem.PageKey);
                    break;
            }
            
        }
        public void ActiveMenu(bool activate)
        {
            return;
        }
    }
}
