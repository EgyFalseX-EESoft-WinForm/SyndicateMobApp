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
            LoginPage loginPage = new LoginPage();
            NavigationPage navPage = new NavigationPage(loginPage);
            

            Core.InitializeNavigationService(navPage);
            Core.InitializeDialogService(navPage);

            MenuPage menuPage = new MenuPage();
            RootPage masterPage = new RootPage
            {
                Detail = navPage,
                Master = menuPage
            };
            // For Android & Windows Phone, provide a way to get back to the master page.
            if (Device.OS != TargetPlatform.iOS)
            {
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += (sender, args) =>
                {
                    masterPage.IsPresented = true;
                };
                ((ContentPage)navPage.CurrentPage).Content.BackgroundColor = Color.Transparent;
                ((ContentPage)navPage.CurrentPage).Content.GestureRecognizers.Add(tap);
            }

            MainPage = masterPage;
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
