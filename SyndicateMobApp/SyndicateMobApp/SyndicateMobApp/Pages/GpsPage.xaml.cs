using System;
using SyndicateMobApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SyndicateMobApp.Pages
{
    public partial class GpsPage : ContentPage
    {  
        private GpsVm CurrentViewModel => BindingContext as GpsVm;
        public GpsPage()
        {
            InitializeComponent();
        }
        private void SubCommittePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentViewModel.Pins.Count == 0 || MainMap?.Pins == null)
                return;
            MainMap.Pins.Clear();
            Pin pin = CurrentViewModel.Pins[0];
            MainMap.Pins.Add(pin);
            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.3)));

        }
    }
}
