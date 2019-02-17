using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Pages;
using Xamarin.Forms;
using SyndicateMobApp.Services;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SyndicateMobApp.Helpers
{
    public static class Core
    {
        public static NavigationService MainNavigationService { get; set; }
        public static DialogService MainDialogService { get; set; }
        public static Dictionary<string, string> AppOption { get; set; }


        public static void Startup()
        {
            MainNavigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => MainNavigationService);
        }
        public static void InitializeNavigationService(NavigationPage navPage)
        {
            
            MainNavigationService.Configure(ViewModelLocator.LoginPageKey, typeof(LoginPage));
            MainNavigationService.Configure(ViewModelLocator.MenuPageKey, typeof(MenuPage));
            MainNavigationService.Configure(ViewModelLocator.MenuSubAdminPageKey, typeof(MenuSubAdminPage));
            MainNavigationService.Configure(ViewModelLocator.RootPageKey, typeof(RootPage));
            MainNavigationService.Configure(ViewModelLocator.NewsPageKey, typeof(NewsPage));
            MainNavigationService.Configure(ViewModelLocator.HomePageKey, typeof(HomePage));
            MainNavigationService.Configure(ViewModelLocator.NewsDetailsPageKey, typeof(NewsDetailsPage));
            MainNavigationService.Configure(ViewModelLocator.BankMemberPageKey, typeof(BankMemberPage));
            MainNavigationService.Configure(ViewModelLocator.BankWarasaPageKey, typeof(BankWarasaPage));
            MainNavigationService.Configure(ViewModelLocator.UpdateCoordPageKey, typeof(UpdateCoordPage));
            MainNavigationService.Configure(ViewModelLocator.GpsPageKey, typeof(GpsPage));
            MainNavigationService.Configure(ViewModelLocator.MemberInfoPageKey, typeof(MemberInfoPage));
            MainNavigationService.Configure(ViewModelLocator.WarasaInfoPageKey, typeof(WarasaInfoPage));
            MainNavigationService.Configure(ViewModelLocator.MemberAmanatPageKey, typeof(MemberAmanatPage));
            MainNavigationService.Configure(ViewModelLocator.ActivateMemberVisaPageKey, typeof(MemberActivateVisaPage));
            MainNavigationService.Configure(ViewModelLocator.ActivateWarasaVisaPageKey, typeof(WarasaActivateVisaPage));
            MainNavigationService.Configure(ViewModelLocator.MemberActivateVisaByHafzaPageKey, typeof(MemberActivateVisaByHafzaPage));
            MainNavigationService.Configure(ViewModelLocator.WarasaActivateVisaByHafzaPageKey, typeof(WarasaActivateVisaByHafzaPage));

            MainNavigationService.Configure(ViewModelLocator.StopMemberVisaPageKey, typeof(MemberStopVisaPage));
            MainNavigationService.Configure(ViewModelLocator.StopWarasaVisaPageKey, typeof(WarasaStopVisaPage));

            MainNavigationService.Configure(ViewModelLocator.ReprintMemberPageKey, typeof(ReprintMemberPage));
            MainNavigationService.Configure(ViewModelLocator.ReprintWarasaPageKey, typeof(ReprintWarasaPage));

            MainNavigationService.Initialize(navPage);
        }
        public static void InitializeDialogService(NavigationPage navPage)
        {
            MainDialogService = new DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => MainDialogService);
            MainDialogService.Initialize(navPage);
        }
        
        public static async Task LoadAppOptionAsync()
        {
            try
            {
                ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
                AppOption = new Dictionary<string, string>();
                foreach (AppOptionContrect option in await srv.GetAppOptionAsync())
                {
                    AppOption.Add(option.option_name, option.option_value);
                }
            }
            catch (System.Exception)
            { }
        }

    }
}
