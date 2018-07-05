using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public interface ISyndicateService
    {
        string SyndicateServiceUrl { get; }
        string LoginMemberUri { get; }
        string LoginWarasaUri { get; }
        string LoginUri { get; }
        string BankMemberUri { get; }
        string BankWarasaUri { get; }
        string GetSyndicateUri { get; }
        string GetSubCommitteUri { get; }
        string PostSubCommitteUri { get; }//subCommitteId={subCommitteId}&lat={lat}&Long={Long}
        string GetNewsFrontPageUri { get; }
        string GetNewsItemUri { get; }
        string GetMemberInfoUri { get; }
        string GetWarasaInfoUri { get; }
        string GetInsertMemberAmanatUri { get; }

        string ActivateMemberVisaUri { get; }
        string ActivateWarasaVisaUri { get; }
        string GetMemberVisaByHafzaUri { get; }
        string GetWarasaVisaByHafzaUri { get; }
        string PostActiveMemberVisaUri { get; }
        string PostActiveWarasaVisaUri { get; }

        string GetActiveMemberVisaUri { get; }
        string GetActiveWarasaVisaUri { get; }

        string GetStopMemberVisaUri { get; }
        string GetStopWarasaVisaUri { get; }

        Task<LoginMemberContrect> LoginMemberAsync(string value);
        Task<LoginWarasaContrect> LoginWarasaAsync(string value);
        Task<LoginContrect> LoginAsync(string user, string pass);
        Task<ObservableCollection<BankMemberContrect>> BankMemberAsync(string value);
        Task<ObservableCollection<BankWarasaContrect>> BankWarasaAsync(string value);
        Task<ObservableCollection<SyndicateContrect>> GetSyndicateAsync();
        Task<ObservableCollection<SubCommitteContrect>> GetSubCommitteUriAsync(string value);
        void PostSubCommitteUriAsync(int subCommitteId, double lat, double Long);
        Task<ObservableCollection<NewsFrontPageContrect>> GetNewsFrontPageAsync();
        Task<NewsItemContrect> GetNewsItemAsync(string value);
        Task<MemberInfoContrect> GetMemberInfoAsync(string value);
        Task<WarasaInfoContrect> GetWarasaInfoAsync(string value);
        Task<ObservableCollection<AdsContrect>> GetAdsAsync();
        Task<ObservableCollection<AppOptionContrect>> GetAppOptionAsync();
        Task<string> GetInsertMemberAmanatAsync(string Id);

        Task<string> ActivateMemberVisaAsync(string visa);
        Task<string> ActivateWarasaVisaAsync(string visa);
        Task<ObservableCollection<ActivateVisaContrect>> GetMemberVisaByHafzaAsync(string value);
        Task<ObservableCollection<ActivateVisaContrect>> GetWarasaVisaByHafzaAsync(string value);
        void PostActiveMemberVisaAsync(string visa);
        void PostActiveWarasaVisaAsync(string visa);
        Task<string> GetStopVisaMemberAsync(string visa, string user);
        Task<string> GetStopVisaWarasaAsync(string visa, string user);

    }
}
