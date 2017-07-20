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
            try
            {
                ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
                DataList = await srv.GetAdsAsync();
            }
            catch (System.Exception)
            { }
        }

        public static string GetAdsPath()
        {
            if (DataList.Count == 0)
                return string.Empty;
            string outPut = string.Empty;
            if (_inx + 1 > DataList.Count)
            {
                _inx = 0;
                outPut = DataList[_inx].ImagePath;
            }
            else
            {
                outPut = DataList[_inx].ImagePath;
                _inx++;
            }
            return outPut;
        }

        
    }
}
