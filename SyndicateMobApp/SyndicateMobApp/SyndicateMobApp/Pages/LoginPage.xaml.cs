using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SyndicateMobApp.Services;
using Xamarin.Forms;

namespace SyndicateMobApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            

            await DisplayAlert("خطــــــأ", "هذا الرقم غير موجود", "OK");
        }
    }
}
