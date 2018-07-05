/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:App3"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Pages;
using SyndicateMobApp.Services;
using SyndicateMobApp.ViewModels;
using Xamarin.Forms;


namespace SyndicateMobApp.Helpers
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public const string LoginPageKey = "Login";
        public const string MenuPageKey = "Menu";
        public const string MenuSubAdminPageKey = "MenuSubAdmin";
        public const string RootPageKey = "Root";
        public const string HomePageKey = "Home";
        public const string BankMemberPageKey = "BankMember";
        public const string BankWarasaPageKey = "BankWarasa";
        public const string NewsPageKey = "News";
        public const string NewsDetailsPageKey = "NewsDetails";
        public const string UpdateCoordPageKey = "UpdateCoord";
        public const string GpsPageKey = "Gps";
        public const string MemberInfoPageKey = "MemberInfo";
        public const string WarasaInfoPageKey = "WarasaInfo";
        public const string MemberAmanatPageKey = "MemberAmanat";
        public const string ActivateMemberVisaPageKey = "ActivateMemberVisa";
        public const string ActivateWarasaVisaPageKey = "ActivateWarasaVisa";
        public const string MemberActivateVisaByHafzaPageKey = "MemberActivateVisaByHafza";
        public const string WarasaActivateVisaByHafzaPageKey = "WarasaActivateVisaByHafza";

        public const string StopMemberVisaPageKey = "StopMemberVisa";
        public const string StopWarasaVisaPageKey = "StopWarasaVisa";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<ISyndicateService, SyndicateServiceOffline>();
            }
            else
            {
                SimpleIoc.Default.Register<ISyndicateService, SyndicateService>();
            }

            SimpleIoc.Default.Register<LoginVm>();
            SimpleIoc.Default.Register<RootVm>();
            SimpleIoc.Default.Register<MenuVm>();
            SimpleIoc.Default.Register<MenuSubAdminVm>();
            SimpleIoc.Default.Register<HomeVm>();
            SimpleIoc.Default.Register<BankMemberVm>();
            SimpleIoc.Default.Register<BankWarasaVm>();
            SimpleIoc.Default.Register<NewsVm>();
            SimpleIoc.Default.Register<NewsDetailsVm>();
            SimpleIoc.Default.Register<UpdateCoordVm>();
            SimpleIoc.Default.Register<GpsVm>();
            SimpleIoc.Default.Register<MemberInfoVm>();
            SimpleIoc.Default.Register<WarasaInfoVm>();
            SimpleIoc.Default.Register<MemberAmanatVm>();
            SimpleIoc.Default.Register<MemberActivateVisaVm>();
            SimpleIoc.Default.Register<WarasaActivateVisaVm>();
            SimpleIoc.Default.Register<MemberActivateVisaByHafzaVm>();
            SimpleIoc.Default.Register<WarasaActivateVisaByHafzaVm>();

            SimpleIoc.Default.Register<StopVisaMemberVm>();
            SimpleIoc.Default.Register<StopVisaWarasaVm>();
        }
        public static ViewModelLocator Instance => Application.Current.Resources["Locator"] as ViewModelLocator;

        public LoginVm LoginInstance => ServiceLocator.Current.GetInstance<LoginVm>();
        public RootVm RootInstance => ServiceLocator.Current.GetInstance<RootVm>();
        public MenuVm MenuInstance => ServiceLocator.Current.GetInstance<MenuVm>();
        public MenuSubAdminVm MenuSubAmdinInstance => ServiceLocator.Current.GetInstance<MenuSubAdminVm>();
        public HomeVm HomeInstance => ServiceLocator.Current.GetInstance<HomeVm>();
        public NewsVm NewsInstance => ServiceLocator.Current.GetInstance<NewsVm>();
        public NewsDetailsVm NewsDetailsInstance => ServiceLocator.Current.GetInstance<NewsDetailsVm>();
        public BankMemberVm BankMemberInstance => ServiceLocator.Current.GetInstance<BankMemberVm>();
        public BankWarasaVm BankWarasaInstance => ServiceLocator.Current.GetInstance<BankWarasaVm>();
        public UpdateCoordVm UpdateCoordInstance => ServiceLocator.Current.GetInstance<UpdateCoordVm>();
        public GpsVm GpsInstance => ServiceLocator.Current.GetInstance<GpsVm>();
        public MemberInfoVm MemberInfoInstance => ServiceLocator.Current.GetInstance<MemberInfoVm>();
        public WarasaInfoVm WarasaInfoInstance => ServiceLocator.Current.GetInstance<WarasaInfoVm>();
        public MemberAmanatVm MemberAmanatInstance => ServiceLocator.Current.GetInstance<MemberAmanatVm>();
        public MemberActivateVisaVm ActivateMemberVisaInstance => ServiceLocator.Current.GetInstance<MemberActivateVisaVm>();
        public WarasaActivateVisaVm ActivateWarasaVisaInstance => ServiceLocator.Current.GetInstance<WarasaActivateVisaVm>();
        public MemberActivateVisaByHafzaVm MemberActivateVisaByHafzaInstance => ServiceLocator.Current.GetInstance<MemberActivateVisaByHafzaVm>();
        public WarasaActivateVisaByHafzaVm WarasaActivateVisaByHafzaInstance => ServiceLocator.Current.GetInstance<WarasaActivateVisaByHafzaVm>();

        public StopVisaMemberVm StopMemberVisaInstance => ServiceLocator.Current.GetInstance<StopVisaMemberVm>();
        public StopVisaWarasaVm StopWarasaVisaInstance => ServiceLocator.Current.GetInstance<StopVisaWarasaVm>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

    }
}
