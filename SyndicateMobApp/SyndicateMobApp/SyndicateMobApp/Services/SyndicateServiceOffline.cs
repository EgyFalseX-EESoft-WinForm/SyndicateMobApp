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
    public class SyndicateServiceOffline : ISyndicateService
    {
        public string SyndicateServiceUrl => "test";

        public string LoginMemberUri  => SyndicateServiceUrl + "test/";
        public string LoginWarasaUri => SyndicateServiceUrl + "test/";
        public string BankMemberUri => SyndicateServiceUrl + "test/";
        public string BankWarasaUri => SyndicateServiceUrl + "BantestkWarasa/";

        public async Task<LoginMemberContrect> LoginMemberAsync(string value)
        {
            LoginMemberContrect result = new LoginMemberContrect(1, "test", 1, 1, DateTime.Now, "test", "test");
            return result;
        }
        public async Task<LoginWarasaContrect> LoginWarasaAsync(string value)
        {
            LoginWarasaContrect result = new LoginWarasaContrect(1, 1, "test", true, true, 1, "test", "test", "test", "test");
            return result;
        }

        public async Task<ObservableCollection<BankMemberContrect>> BankMemberAsync(string value)
        {
            ObservableCollection<BankMemberContrect> lst = new ObservableCollection<BankMemberContrect>
            {
                new BankMemberContrect(1, 1, 1, DateTime.Now, 1, DateTime.Now, "test"),
                new BankMemberContrect(1, 1, 1, DateTime.Now, 1, DateTime.Now, "test"),
                new BankMemberContrect(1, 1, 1, DateTime.Now, 1, DateTime.Now, "test"),
                new BankMemberContrect(1, 1, 1, DateTime.Now, 1, DateTime.Now, "test"),
                new BankMemberContrect(1, 1, 1, DateTime.Now, 1, DateTime.Now, "test")
            };
            return lst;
        }
        public async Task<ObservableCollection<BankWarasaContrect>> BankWarasaAsync(string value)
        {
            ObservableCollection<BankWarasaContrect> lst = new ObservableCollection<BankWarasaContrect>
            {
                new BankWarasaContrect(1, 1, 1, "test", 1, DateTime.Now, 1, DateTime.Now, 1),
                new BankWarasaContrect(1, 1, 1, "test", 1, DateTime.Now, 1, DateTime.Now, 1),
                new BankWarasaContrect(1, 1, 1, "test", 1, DateTime.Now, 1, DateTime.Now, 1),
                new BankWarasaContrect(1, 1, 1, "test", 1, DateTime.Now, 1, DateTime.Now, 1),
                new BankWarasaContrect(1, 1, 1, "test", 1, DateTime.Now, 1, DateTime.Now, 1),
            };
            return lst;
        }

    }
}
