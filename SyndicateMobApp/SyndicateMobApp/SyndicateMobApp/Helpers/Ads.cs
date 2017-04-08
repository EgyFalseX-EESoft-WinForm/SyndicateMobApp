using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.Helpers
{
    public static class Ads
    {
        private static ObservableCollection<AdsContrect> DataList { get; set; }
        private static int _inx;
        public static async Task LoadAdsAsync()
        {
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            DataList = await srv.GetAdsAsync();
        }

        public static string GetAdsPath()
        {
            string outPut = DataList[_inx].ImagePath;
            if (_inx++ >= DataList.Count)
                _inx = 0;
            else
                _inx++;
            return outPut;
        }

        
    }
}
