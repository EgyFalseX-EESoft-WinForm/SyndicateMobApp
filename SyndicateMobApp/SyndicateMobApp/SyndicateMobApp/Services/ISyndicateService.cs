using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SyndicateMobApp.Services
{
    public interface ISyndicateService
    {
        string SyndicateServiceUrl { get; }
        string LoginMemberUri { get; }
        string LoginWarasaUri { get; }
        string BankMemberUri { get; }
        string BankWarasaUri { get; }
        string GetSyndicateUri { get; }
        string GetSubCommitteUri { get; }
        string PostSubCommitteUri { get; }//subCommitteId={subCommitteId}&lat={lat}&Long={Long}
        string GetNewsFrontPageUri { get; }
        string GetNewsItemUri { get; }
        string GetMemberInfoUri { get; }
        string GetWarasaInfoUri { get; }

        Task<LoginMemberContrect> LoginMemberAsync(string value);
        Task<LoginWarasaContrect> LoginWarasaAsync(string value);
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

    }
}
