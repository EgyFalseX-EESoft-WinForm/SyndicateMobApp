using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyndicateMobApp.Helpers;
using Xamarin.Forms;

namespace SyndicateMobApp.Pages
{
    public partial class MenuSubAdminPage : ContentPage
    {
        public ListView Menu => GroupedView;
        
        public MenuSubAdminPage()
        {
            InitializeComponent();

            //TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += (s, e) => {
            //    Device.OpenUri(new Uri("http://ets.eg"));
            //};
            //WebsiteLabel.GestureRecognizers.Add(tapGestureRecognizer);
            //var ibj = this.Parent;

        }
    }
}
