﻿using System;
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
        public string LoginUri => SyndicateServiceUrl + "test/";
        public string BankMemberUri => SyndicateServiceUrl + "test/";
        public string BankWarasaUri => SyndicateServiceUrl + "BantestkWarasa/";
        public string GetSyndicateUri => SyndicateServiceUrl + "test";
        public string GetSubCommitteUri => SyndicateServiceUrl + "test/";
        public string PostSubCommitteUri => SyndicateServiceUrl + "test?";//subCommitteId={subCommitteId}&lat={lat}&Long={Long}
        public string GetNewsFrontPageUri => SyndicateServiceUrl + "test";
        public string GetNewsItemUri => SyndicateServiceUrl + "test/";
        public string GetMemberInfoUri => SyndicateServiceUrl + "test/";
        public string GetWarasaInfoUri => SyndicateServiceUrl + "test/";
        public string GetAppOptionUri => SyndicateServiceUrl + "test/";
        public string GetInsertMemberAmanatUri => SyndicateServiceUrl + "test/";
        public string ActivateMemberVisaUri => SyndicateServiceUrl + "test/";
        public string ActivateWarasaVisaUri => SyndicateServiceUrl + "test/";
        public string GetMemberVisaByHafzaUri => SyndicateServiceUrl + "test/";
        public string GetWarasaVisaByHafzaUri => SyndicateServiceUrl + "test/";
        public string PostActiveMemberVisaUri => SyndicateServiceUrl + "test?";
        public string PostActiveWarasaVisaUri => SyndicateServiceUrl + "test?";
        public string GetStopVisaMemberUri => SyndicateServiceUrl + "test?";
        public string GetStopVisaWarasaUri => SyndicateServiceUrl + "test?";
        public string GetActiveMemberVisaUri => SyndicateServiceUrl + "test?";
        public string GetActiveWarasaVisaUri => SyndicateServiceUrl + "test?";
        public string GetStopMemberVisaUri => SyndicateServiceUrl + "test?";
        public string GetStopWarasaVisaUri => SyndicateServiceUrl + "test?";

        public string GetRePrintResonUri => SyndicateServiceUrl + "test?";
        public string GetReprintMemberUri => SyndicateServiceUrl + "test?";
        public string GetReprintWarasaUri => SyndicateServiceUrl + "test?";

        public async Task<LoginMemberContrect> LoginMemberAsync(string value)
        {
            return await new Task<LoginMemberContrect>(
                () =>
                {
                    LoginMemberContrect result = new LoginMemberContrect(1, "test", 1, 1, DateTime.Now, "test", "test", "test", "test");
                    return result;
                });
        }
        public async Task<LoginWarasaContrect> LoginWarasaAsync(string value)
        {
            return await new Task<LoginWarasaContrect>(
                () =>
                {
                    LoginWarasaContrect result = new LoginWarasaContrect(1, 1, "test", true, true, 1, "test", "test",
                        "test", "test", "test", "test","test", "test");
                    return result;
                });
        }
        public async Task<LoginContrect> LoginAsync(string user, string pass)
        {
            return await new Task<LoginContrect>(
                () =>
                {
                    LoginContrect result = new LoginContrect(1, "test", "test", 1, 1);
                    return result;
                });
        }
        public async Task<ObservableCollection<BankMemberContrect>> BankMemberAsync(string value)
        {
            return await new Task<ObservableCollection<BankMemberContrect>>(
                () =>
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
                });
        }
        public async Task<ObservableCollection<BankWarasaContrect>> BankWarasaAsync(string value)
        {
            return await new Task<ObservableCollection<BankWarasaContrect>>(
                () =>
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
                });
        }
        public async Task<ObservableCollection<SyndicateContrect>> GetSyndicateAsync()
        {
            return await new Task<ObservableCollection<SyndicateContrect>>(
                () =>
                {
                    ObservableCollection<SyndicateContrect> lst = new ObservableCollection<SyndicateContrect>
                    {
                        new SyndicateContrect(1, "test1"),
                        new SyndicateContrect(2, "test2"),
                        new SyndicateContrect(3, "test3"),
                        new SyndicateContrect(4, "test4"),
                        new SyndicateContrect(5, "test5")
                    };
                    return lst;
                });
        }
        public async Task<ObservableCollection<SubCommitteContrect>> GetSubCommitteUriAsync(string value)
        {
            return await new Task<ObservableCollection<SubCommitteContrect>>(
                () =>
                {
                    ObservableCollection<SubCommitteContrect> lst = new ObservableCollection<SubCommitteContrect>
                    {
                        new SubCommitteContrect(1, "test1", 1, 1, 1),
                        new SubCommitteContrect(2, "test2", 1, 1, 1),
                        new SubCommitteContrect(3, "test3", 2, 1, 1),
                        new SubCommitteContrect(4, "test4", 2, 1, 1),
                        new SubCommitteContrect(5, "test5", 3, 1, 1),
                    };
                    return lst;
                });
        }
        public async void PostSubCommitteUriAsync(int subCommitteId, double lat, double Long)
        {
            await Task.Run(() => { });
        }
        public async Task<ObservableCollection<NewsFrontPageContrect>> GetNewsFrontPageAsync()
        {
            return await new Task<ObservableCollection<NewsFrontPageContrect>>(
                () =>
                {
                    ObservableCollection<NewsFrontPageContrect> lst = new ObservableCollection<NewsFrontPageContrect>
                    {
                        new NewsFrontPageContrect(1, "test1", "test1"),
                        new NewsFrontPageContrect(2, "test2", "test1"),
                        new NewsFrontPageContrect(3, "test3", "test1"),
                        new NewsFrontPageContrect(4, "test4", "test1"),
                        new NewsFrontPageContrect(5, "test5", "test1")
                    };
                    return lst;
                });
        }
        public async Task<NewsItemContrect> GetNewsItemAsync(string value)
        {
            return await new Task<NewsItemContrect>(
                () =>
                {
                    return new NewsItemContrect(1, "test", "test", "test"); 
                });
        }
        public async Task<MemberInfoContrect> GetMemberInfoAsync(string value)
        {
            return await new Task<MemberInfoContrect>(() => new MemberInfoContrect("test", "test", "test", "test", "test", "test", "test"));
        }
        public async Task<WarasaInfoContrect> GetWarasaInfoAsync(string value)
        {
            return await new Task<WarasaInfoContrect>(() => new WarasaInfoContrect("test", "test", "test", "test", "test", "test", "test"));
        }
        public async Task<ObservableCollection<AdsContrect>> GetAdsAsync()
        {
            return await new Task<ObservableCollection<AdsContrect>>(
                () =>
                {
                    ObservableCollection<AdsContrect> lst = new ObservableCollection<AdsContrect>
                    {
                        new AdsContrect(1, "test1"),
                        new AdsContrect(2, "test2"),
                        new AdsContrect(3, "test3"),
                        new AdsContrect(4, "test4"),
                        new AdsContrect(5, "test5")
                    };
                    return lst;
                });
        }
        public async Task<ObservableCollection<AppOptionContrect>> GetAppOptionAsync()
        {
            return await new Task<ObservableCollection<AppOptionContrect>>(
                () =>
                {
                    ObservableCollection<AppOptionContrect> lst = new ObservableCollection<AppOptionContrect>
                    {
                        new AppOptionContrect("1", "test1"),
                        new AppOptionContrect("2", "test2"),
                        new AppOptionContrect("3", "test3"),
                        new AppOptionContrect("4", "test4"),
                        new AppOptionContrect("5", "test5")
                    };
                    return lst;
                });
        }
        public async Task<string> GetInsertMemberAmanatAsync(string MMashatId)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }

        public async Task<string> ActivateMemberVisaAsync(string visa)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }
        public async Task<string> ActivateWarasaVisaAsync(string visa)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }
        public async Task<ObservableCollection<ActivateVisaContrect>> GetMemberVisaByHafzaAsync(string value)
        {
            return await new Task<ObservableCollection<ActivateVisaContrect>>(
                () =>
                {
                    ObservableCollection<ActivateVisaContrect> lst = new ObservableCollection<ActivateVisaContrect>
                    {
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true)
                    };
                    return lst;
                });
        }
        public async Task<ObservableCollection<ActivateVisaContrect>> GetWarasaVisaByHafzaAsync(string value)
        {
            return await new Task<ObservableCollection<ActivateVisaContrect>>(
                () =>
                {
                    ObservableCollection<ActivateVisaContrect> lst = new ObservableCollection<ActivateVisaContrect>
                    {
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true),
                        new ActivateVisaContrect("test1", true)
                    };
                    return lst;
                });
        }
        public async void PostActiveMemberVisaAsync(string visa)
        {
            await Task.Run(() => { });
        }
        public async void PostActiveWarasaVisaAsync(string visa)
        {
            await Task.Run(() => { });
        }
        public async Task<string> GetStopVisaMemberAsync(string visa, string user)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }
        public async Task<string> GetStopVisaWarasaAsync(string visa, string user)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }

        public async Task<ObservableCollection<RePrintResonContrect>> GetRePrintResonAsync()
        {
            return await new Task<ObservableCollection<RePrintResonContrect>>(
                () =>
                {
                    ObservableCollection<RePrintResonContrect> lst = new ObservableCollection<RePrintResonContrect>
                    {
                        new RePrintResonContrect(1, "test1"),
                        new RePrintResonContrect(2, "test2"),
                        new RePrintResonContrect(3, "test3"),
                        new RePrintResonContrect(4, "test4"),
                        new RePrintResonContrect(5, "test5")
                    };
                    return lst;
                });
        }
        public async Task<string> GetReprintMemberAsync(string visa, string user, string type)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }
        public async Task<string> GetReprintWarasaAsync(string visa, string user, string type)
        {
            return await new Task<string>(
                () =>
                {
                    return "test";
                });
        }

    }
}
