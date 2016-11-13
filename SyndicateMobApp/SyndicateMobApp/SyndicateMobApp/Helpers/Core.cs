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
            MainNavigationService.Configure(ViewModelLocator.BankMemberPageKey, typeof(BankMemberPage));
            MainNavigationService.Configure(ViewModelLocator.BankWarasaPageKey, typeof(RootPage));
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
