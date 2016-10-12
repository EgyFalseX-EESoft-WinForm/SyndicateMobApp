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

using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Pages;
using SyndicateMobApp.ViewModels;


namespace SyndicateMobApp.Helpers
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public const string LoginPageKey = "Login";
        public const string BankMemberPageKey = "BankMember";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            NavigationService navSrv = new NavigationService();
            navSrv.Configure(LoginPageKey, typeof(LoginPage));
            navSrv.Configure(BankMemberPageKey, typeof(BankMemberPage));

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            //Register your services used here
            SimpleIoc.Default.Register<INavigationService>(() => navSrv);
            SimpleIoc.Default.Register<LoginVm>();
            SimpleIoc.Default.Register<BankMemberVm>();
        }

        public LoginVm LoginInstance => ServiceLocator.Current.GetInstance<LoginVm>();
        public BankMemberVm BankMemberInstance => ServiceLocator.Current.GetInstance<BankMemberVm>();


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

    }
}
