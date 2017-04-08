using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Pages;
using SyndicateMobApp.ViewModels;
using Xamarin.Forms;

namespace SyndicateMobApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Core.Startup();

            //UpdateCoordPage menuPage = new UpdateCoordPage();
            HomePage homePage = new HomePage();
            NavigationPage navPage = new NavigationPage(homePage);

            MenuPage menuPage = new MenuPage();
            RootPage masterPage = new RootPage
            {
                Detail = navPage,
                Master = menuPage
            };

            Core.InitializeNavigationService(navPage);
            Core.InitializeDialogService(navPage);

            
            MainPage = masterPage;
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await Ads.LoadAdsAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
