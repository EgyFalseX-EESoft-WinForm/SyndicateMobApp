using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SyndicateMobApp.Pages
{
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();

            // For Android & Windows Phone, provide a way to get back to the master page.
            //if (Device.OS != TargetPlatform.iOS)
            //{
            //    TapGestureRecognizer tap = new TapGestureRecognizer();
            //    tap.Tapped += (sender, args) =>
            //    {
            //        ((MasterDetailPage)this.Parent).IsPresented = true;
            //    };
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        this.Content.BackgroundColor = Color.Transparent;
            //        this.Content.GestureRecognizers.Add(tap);
            //    });
                
            //}
        }
    }
}
