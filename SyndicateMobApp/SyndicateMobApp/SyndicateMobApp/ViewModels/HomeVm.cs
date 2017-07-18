using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Helpers;
using Microsoft.Practices.ServiceLocation;
using System.Threading.Tasks;

namespace SyndicateMobApp.ViewModels
{
    public class HomeVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _title;
        private string _icon;
        private RelayCommand _navCommand;
        private MasterPageItem _selectedItem;
        
        public HomeVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "الرئيسيـة";
            Icon = "home32.png";
            CheckForUpdate();
        }
        private async void CheckForUpdate()
        {
            await Task.Delay(2000);
            double localVersion = Xamarin.Forms.DependencyService.Get<Interfaces.IDependencySrv>().GetAppVersion();
            string serverVersion = string.Empty;
            //App.Current.Properties[""]
            switch (Xamarin.Forms.Device.OS)
            {
                case Xamarin.Forms.TargetPlatform.iOS:
                    Core.AppOption.TryGetValue(Types.AppOption.IOSVersion.ToString(), out serverVersion);
                    break;
                case Xamarin.Forms.TargetPlatform.Android:
                    Core.AppOption.TryGetValue(Types.AppOption.AndoirdVersion.ToString(), out serverVersion);
                    break;
                case Xamarin.Forms.TargetPlatform.WinPhone:
                    Core.AppOption.TryGetValue(Types.AppOption.WindowsVersion.ToString(), out serverVersion);
                    break;
                case Xamarin.Forms.TargetPlatform.Windows:
                    Core.AppOption.TryGetValue(Types.AppOption.WindowsVersion.ToString(), out serverVersion);
                    break;
                default:
                    break;
            }
            if (Convert.ToDouble(serverVersion) >  localVersion)
            {
                IDialogService dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowError("يرجي تحديث التطبيق من متجر جوجل", "التحديثــات", "موافق", null);
            }
//#if __IOS__
//  // Do iOS code here
//#elif __ANDROID__
//  // Do Android code here
//#endif
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
            //if (_selectedItem == typeof(string))
            //    _navigationService.NavigateTo(ViewModelLocator.BankMemberPageKey);
            //this.Detail = new NavigationPage((Page)Activator.CreateInstance(((MasterPageItem)args.SelectedItem).TargetType));
            Master.IsPresented = false;
            _navigationService.NavigateTo(_selectedItem.PageKey);


        }
    }
}
