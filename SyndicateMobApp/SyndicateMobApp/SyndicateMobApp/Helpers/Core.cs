using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Pages;
using Xamarin.Forms;

namespace SyndicateMobApp.Helpers
{
    public static class Core
    {
        public static NavigationService MainNavigationService { get; set; }
        public static DialogService MainDialogService { get; set; }

        public static void Startup()
        {
            MainNavigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => MainNavigationService);
        }
        public static void InitializeNavigationService(NavigationPage navPage)
        {
            MainNavigationService.Configure(ViewModelLocator.LoginPageKey, typeof(LoginPage));
            MainNavigationService.Configure(ViewModelLocator.MenuPageKey, typeof(MenuPage));
            MainNavigationService.Configure(ViewModelLocator.RootPageKey, typeof(RootPage));
            MainNavigationService.Configure(ViewModelLocator.NewsPageKey, typeof(NewsPage));
            MainNavigationService.Configure(ViewModelLocator.NewsDetailsPageKey, typeof(NewsDetailsPage));
            MainNavigationService.Configure(ViewModelLocator.BankMemberPageKey, typeof(BankMemberPage));
            MainNavigationService.Configure(ViewModelLocator.BankWarasaPageKey, typeof(BankWarasaPage));
            MainNavigationService.Configure(ViewModelLocator.UpdateCoordPageKey, typeof(UpdateCoordPage));
            MainNavigationService.Configure(ViewModelLocator.GpsPageKey, typeof(GpsPage));
            MainNavigationService.Configure(ViewModelLocator.MemberInfoPageKey, typeof(MemberInfoPage));
            MainNavigationService.Configure(ViewModelLocator.WarasaInfoPageKey, typeof(WarasaInfoPage));
            MainNavigationService.Initialize(navPage);
        }
        public static void InitializeDialogService(NavigationPage navPage)
        {
            MainDialogService = new DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => MainDialogService);
            MainDialogService.Initialize(navPage);
        }
    }
}
