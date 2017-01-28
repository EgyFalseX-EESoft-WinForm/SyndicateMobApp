using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace SyndicateMobApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (Device.OS == TargetPlatform.Windows)
            {
                ViewModels.MenuVm menuVm = ServiceLocator.Current.GetInstance<ViewModels.MenuVm>();
                menuVm.Master.IsPresented = true;
            }
        }
    }
}
