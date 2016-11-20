using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SyndicateMobApp.Services
{
    public class SyndicateService : ISyndicateService
    {
        public string SyndicateServiceUrl => "http://falsex-001-site3.atempurl.com/SyndicateService.svc/rest/";

        public string LoginMemberUri  => SyndicateServiceUrl + "LoginMember/";
        public string LoginWarasaUri => SyndicateServiceUrl + "LoginWarasa/";
        public string BankMemberUri => SyndicateServiceUrl + "BankMember/";
        public string BankWarasaUri => SyndicateServiceUrl + "BankWarasa/";
        public string GetSyndicateUri => SyndicateServiceUrl + "GetSyndicate";
        public string GetSubCommitteUri => SyndicateServiceUrl + "GetSubCommitte/";
        public string PostSubCommitteUri => SyndicateServiceUrl + "PostSubCommitte?";//subCommitteId={subCommitteId}&lat={lat}&Long={Long}

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
        public async Task<ObservableCollection<BankMemberContrect>> BankMemberAsync(string value)
        {
            HttpClient client = new HttpClient();
            string a = BankMemberUri + value;
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


    }
}
