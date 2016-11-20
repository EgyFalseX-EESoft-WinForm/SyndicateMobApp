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

            //MenuPage menuPage = new MenuPage();
            UpdateCoordPage menuPage = new UpdateCoordPage();
            NavigationPage navPage = new NavigationPage(menuPage);

            Core.InitializeNavigationService(navPage);
            Core.InitializeDialogService(navPage);

            MainPage = navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
