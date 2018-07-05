using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;


namespace SyndicateMobApp.Services
{
    public class SyndicateService : ISyndicateService
    {
        //public string SyndicateServiceUrl => "http://falsex-001-site3.atempurl.com/SyndicateService.svc/rest/";
        public string SyndicateServiceUrl => "http://egycstest.com/SyndicateService.svc/rest/";
        //public string SyndicateServiceUrl => "http://10.0.0.99/SyndicateService/SyndicateService.svc/rest/";

        public string LoginMemberUri  => SyndicateServiceUrl + "LoginMember/";
        public string LoginWarasaUri => SyndicateServiceUrl + "LoginWarasa/";
        public string LoginUri => SyndicateServiceUrl + "Login?user={0}&pass={1}";//xxx&yyy
        public string BankMemberUri => SyndicateServiceUrl + "BankMember/";
        public string BankWarasaUri => SyndicateServiceUrl + "BankWarasa/";
        public string GetSyndicateUri => SyndicateServiceUrl + "GetSyndicate";
        public string GetSubCommitteUri => SyndicateServiceUrl + "GetSubCommitte/";
        public string PostSubCommitteUri => SyndicateServiceUrl + "PostSubCommitte?";//subCommitteId={subCommitteId}&lat={lat}&Long={Long}
        public string GetNewsFrontPageUri => SyndicateServiceUrl + "GetNewsFrontPage";
        public string GetNewsItemUri => SyndicateServiceUrl + "GetNewsItem/";
        public string GetMemberInfoUri => SyndicateServiceUrl + "GetMemberInfo/";
        public string GetWarasaInfoUri => SyndicateServiceUrl + "GetWarasaInfo/";
        public string GetAdsUri => SyndicateServiceUrl + "GetAds";
        public string GetAppOptionUri => SyndicateServiceUrl + "GetAppOption";
        public string GetInsertMemberAmanatUri => SyndicateServiceUrl + "GetInsertMemberAmanat?MMashatId={0}&UserId={1}";

        public string ActivateMemberVisaUri => SyndicateServiceUrl + "ActivateMemberVisa?visa={0}&user={1}";
        public string ActivateWarasaVisaUri => SyndicateServiceUrl + "ActivateWarasaVisa?visa={0}&user={1}";
        public string GetMemberVisaByHafzaUri => SyndicateServiceUrl + "GetMemberVisaByHafza?hafza={0}&user={1}";
        public string GetWarasaVisaByHafzaUri => SyndicateServiceUrl + "GetWarasaVisaByHafza?hafza={0}&user={1}";
        public string PostActiveMemberVisaUri => SyndicateServiceUrl + "PostActiveMemberVisa?visa={0}&user={1}";
        public string PostActiveWarasaVisaUri => SyndicateServiceUrl + "PostActiveWarasaVisa?visa={0}&user={1}";
        public string GetStopVisaMemberUri => SyndicateServiceUrl + "GetStopVisaMember?visa={0}&user={1}";
        public string GetStopVisaWarasaUri => SyndicateServiceUrl + "GetStopVisaWarasa?visa={0}&user={1}";
        public string GetActiveMemberVisaUri => SyndicateServiceUrl + "GetStopVisaMember?visa={0}&user={1}";
        public string GetActiveWarasaVisaUri => SyndicateServiceUrl + "GetStopVisaMember?visa={0}&user={1}";
        public string GetStopMemberVisaUri => SyndicateServiceUrl + "GetStopVisaMember?visa={0}&user={1}";
        public string GetStopWarasaVisaUri => SyndicateServiceUrl + "GetStopVisaMember?visa={0}&user={1}";

        public async Task<LoginMemberContrect> LoginMemberAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(LoginMemberUri + value);
            LoginMemberContrect result = JsonConvert.DeserializeObject<LoginMemberContrect>(jesonString);
            return result;
        }
        public async Task<LoginWarasaContrect> LoginWarasaAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(LoginWarasaUri + value);
            LoginWarasaContrect result = JsonConvert.DeserializeObject<LoginWarasaContrect>(jesonString);
            return result;
        }
        public async Task<LoginContrect> LoginAsync(string user, string pass)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(LoginUri, user, pass));
            LoginContrect result = JsonConvert.DeserializeObject<LoginContrect>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<BankMemberContrect>> BankMemberAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(BankMemberUri + value);
            ObservableCollection<BankMemberContrect> result = JsonConvert.DeserializeObject<ObservableCollection<BankMemberContrect>>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<BankWarasaContrect>> BankWarasaAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(BankWarasaUri + value);
            ObservableCollection<BankWarasaContrect> result = JsonConvert.DeserializeObject<ObservableCollection<BankWarasaContrect>>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<SyndicateContrect>> GetSyndicateAsync()
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetSyndicateUri);
            ObservableCollection<SyndicateContrect> result = JsonConvert.DeserializeObject<ObservableCollection<SyndicateContrect>>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<SubCommitteContrect>> GetSubCommitteUriAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetSubCommitteUri + value);
            ObservableCollection<SubCommitteContrect> result = JsonConvert.DeserializeObject<ObservableCollection<SubCommitteContrect>>(jesonString);
            return result;
        }
        public async void PostSubCommitteUriAsync(int subCommitteId, double lat, double Long)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await client.PostAsync(PostSubCommitteUri + $"subCommitteId={subCommitteId}&lat={lat}&Long={Long}", content);
        }
        public async Task<ObservableCollection<NewsFrontPageContrect>> GetNewsFrontPageAsync()
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetNewsFrontPageUri);
            ObservableCollection<NewsFrontPageContrect> result = JsonConvert.DeserializeObject<ObservableCollection<NewsFrontPageContrect>>(jesonString);
            return result;
        }
        public async Task<NewsItemContrect> GetNewsItemAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetNewsItemUri + value);
            NewsItemContrect result = JsonConvert.DeserializeObject<NewsItemContrect>(jesonString);
            return result;
        }
        public async Task<MemberInfoContrect> GetMemberInfoAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetMemberInfoUri + value);
            MemberInfoContrect result = JsonConvert.DeserializeObject<MemberInfoContrect>(jesonString);
            return result;
        }
        public async Task<WarasaInfoContrect> GetWarasaInfoAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetWarasaInfoUri + value);
            WarasaInfoContrect result = JsonConvert.DeserializeObject<WarasaInfoContrect>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<AdsContrect>> GetAdsAsync()
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetAdsUri);
            ObservableCollection<AdsContrect> result = JsonConvert.DeserializeObject<ObservableCollection<AdsContrect>>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<AppOptionContrect>> GetAppOptionAsync()
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(GetAppOptionUri);
            ObservableCollection<AppOptionContrect> result = JsonConvert.DeserializeObject<ObservableCollection<AppOptionContrect>>(jesonString);
            return result;
        }
        public async Task<string> GetInsertMemberAmanatAsync(string MMashatId)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(GetInsertMemberAmanatUri, MMashatId, Helpers.UserManager.CurrentUser.user_id));
            string result = JsonConvert.DeserializeObject<string>(jesonString);
            return result;
        }

        public async Task<string> ActivateMemberVisaAsync(string visa)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(ActivateMemberVisaUri, visa, Helpers.UserManager.CurrentUser.user_id));
            string result = JsonConvert.DeserializeObject<string>(jesonString);
            return result;
        }
        public async Task<string> ActivateWarasaVisaAsync(string visa)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(ActivateWarasaVisaUri, visa, Helpers.UserManager.CurrentUser.user_id));
            string result = JsonConvert.DeserializeObject<string>(jesonString);
            return result;
        }

        public async Task<ObservableCollection<ActivateVisaContrect>> GetMemberVisaByHafzaAsync(string hafza)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(GetMemberVisaByHafzaUri, hafza, Helpers.UserManager.CurrentUser.user_id));
            ObservableCollection<ActivateVisaContrect> result = JsonConvert.DeserializeObject<ObservableCollection<ActivateVisaContrect>>(jesonString);
            return result;
        }
        public async Task<ObservableCollection<ActivateVisaContrect>> GetWarasaVisaByHafzaAsync(string hafza)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(GetWarasaVisaByHafzaUri, hafza, Helpers.UserManager.CurrentUser.user_id));
            ObservableCollection<ActivateVisaContrect> result = JsonConvert.DeserializeObject<ObservableCollection<ActivateVisaContrect>>(jesonString);
            return result;
        }

        public async void PostActiveMemberVisaAsync(string visa)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await client.PostAsync(string.Format(PostActiveMemberVisaUri, visa, Helpers.UserManager.CurrentUser.user_id), content);
        }
        public async void PostActiveWarasaVisaAsync(string visa)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await client.PostAsync(string.Format(PostActiveWarasaVisaUri, visa, Helpers.UserManager.CurrentUser.user_id), content);
            
        }

        public async Task<string> GetStopVisaMemberAsync(string visa, string user)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(GetStopVisaMemberUri, visa, Helpers.UserManager.CurrentUser.user_id));
            string result = JsonConvert.DeserializeObject<string>(jesonString);
            return result;
        }
        public async Task<string> GetStopVisaWarasaAsync(string visa, string user)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(string.Format(GetStopVisaWarasaUri, visa, Helpers.UserManager.CurrentUser.user_id));
            string result = JsonConvert.DeserializeObject<string>(jesonString);
            return result;
        }
    }
}
