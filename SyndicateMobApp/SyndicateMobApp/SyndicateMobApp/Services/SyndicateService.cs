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

    }
}
