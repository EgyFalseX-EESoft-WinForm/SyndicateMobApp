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
        public const string BankMemberPageKey = "BankMember";
        public const string BankWarasaPageKey = "BankWarasa";

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
            SimpleIoc.Default.Register<BankMemberVm>();
        }

        public LoginVm LoginInstance => ServiceLocator.Current.GetInstance<LoginVm>();
        public BankMemberVm BankMemberInstance => ServiceLocator.Current.GetInstance<BankMemberVm>();
        public BankWarasaVm BankWarasaInstance => ServiceLocator.Current.GetInstance<BankWarasaVm>();



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

    }
}
