using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SyndicateMobApp.Services
{
    public static class SyndicateService
    {
        private static string _syndicateService = "http://falsex-001-site3.atempurl.com/SyndicateService.svc/rest/";

        private static string LoginMemberUri { get; } = _syndicateService + "LoginMember/";
        private static string LoginWarasaUri { get; } = _syndicateService + "LoginWarasa/";
        private static string BankMemberUri { get; } = _syndicateService + "BankMember/";
        private static string BankWarasaUri { get; } = _syndicateService + "BankWarasa/";

        public static async Task<LoginMemberContrect> LoginMemberAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(LoginMemberUri + value);
            LoginMemberContrect result = JsonConvert.DeserializeObject<LoginMemberContrect>(jesonString);
            return result;
        }
        public static async Task<LoginWarasaContrect> LoginWarasaAsync(string value)
        {
            HttpClient client = new HttpClient();
            string jesonString = await client.GetStringAsync(LoginWarasaUri + value);
            LoginWarasaContrect result = JsonConvert.DeserializeObject<LoginWarasaContrect>(jesonString);
            return result;
        }

    }
}
