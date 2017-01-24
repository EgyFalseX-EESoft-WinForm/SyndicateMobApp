using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.ViewModels;
using Xamarin.Forms;

namespace SyndicateMobApp.Pages
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            
            Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<MenuVm>().Master = this;
        }
    }
}
