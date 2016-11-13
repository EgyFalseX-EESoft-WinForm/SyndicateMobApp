using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NICS.Models;
using SyndicateMobApp.Helpers;
using Xamarin.Forms;

namespace SyndicateMobApp.Pages
{
    public class RootMasterPage : MasterDetailPage
    {
        public RootMasterPage()
        {
            Label header = new Label
            {
                Text = "Main Page",
                Font = Font.SystemFontOfSize(30, FontAttributes.Bold),
                HorizontalOptions = LayoutOptions.Center
            };
            List<MasterPageItem> ds = LoadMenu();
            // Create ListView for the master page.
            ListView listView = new ListView
            {
                ItemsSource = ds,
                ItemTemplate = new DataTemplate(() => {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };

            // Create the master page with the ListView.
            this.Master = new ContentPage
            {
                Title = "Main Menu",       // Title required!
                Content = new StackLayout
                {
                    Children =
                    {
                        header,
                        listView
                    }
                }
            };

            // Create the detail page using NamedColorPage
            GPSValidationPage detailPage = new GPSValidationPage();
            this.Detail = detailPage;

            // For Android & Windows Phone, provide a way to get back to the master page.
            if (Device.OS != TargetPlatform.iOS)
            {
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += (sender, args) =>
                {
                    this.IsPresented = true;
                };

                detailPage.Content.BackgroundColor = Color.Transparent;
                detailPage.Content.GestureRecognizers.Add(tap);
            }

            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) =>
            {
                if (listView.SelectedItem == null)
                    return;
                // Set the BindingContext of the detail page.
                this.Detail = new NavigationPage((Page)Activator.CreateInstance(((MasterPageItem)args.SelectedItem).TargetType));
                listView.SelectedItem = null;
                // Show the detail page.
                this.IsPresented = false;
            };

            // Initialize the ListView selection.
            listView.SelectedItem = ds[0];

        }
        private List<MasterPageItem> LoadMenu()
        {
            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "GPS Validation",
                    IconSource = "http://falsex-001-site2.atempurl.com/MobileAppAssets/Images/GPSValidationPage32.png",
                    //TargetType = typeof (GPSValidationPage)
                    //TargetType = typeof (CustomerUniverseMapPage)
                    TargetType = typeof (ViewModelLocator.BankMemberPageKey)
                },
                new MasterPageItem
                {
                    Title = "IC Customers Location",
                    IconSource = "http://falsex-001-site2.atempurl.com/MobileAppAssets/Images/ICCustomersGPS32.png",
                    TargetType = typeof (GPSPage)
                },
                
            };
            return masterPageItems;
        }
    }
}
