using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using SyndicateServiceLib.DataContracts;
using System;

namespace SyndicateServiceLib
{
    [ServiceContract]
    public interface IRetirement
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "LoginMember/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LoginMemberContrect LoginMember(string value);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "LoginWarasa/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LoginWarasaContrect LoginWarasa(string value);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Login?user={user}&pass={pass}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        LoginContrect Login(string user, string pass);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "BankMember/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<BankMemberContrect> BankMember(string value);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "BankWarasa/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<BankWarasaContrect> BankWarasa(string value);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSyndicate", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<SyndicateContrect> GetSyndicate();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSubCommitte/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<SubCommitteContrect> GetSubCommitte(string value);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "PostSubCommitte?subCommitteId={subCommitteId}&lat={lat}&Long={Long}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void PostSubCommitte(int subCommitteId, double lat, double Long);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetNewsFrontPage", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<NewsFrontPageContrect> GetNewsFrontPage();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetNewsItem/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NewsItemContrect GetNewsItem(string value);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetMemberInfo/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MemberInfoContrect GetMemberInfo(string value);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetWarasaInfo/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        WarasaInfoContrect GetWarasaInfo(string value);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAds", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<AdsContrect> GetAds();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAppOption", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ObservableCollection<AppOptionContrect> GetAppOption();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetInsertMemberAmanat?MMashatId={MMashatId}&UserId={UserId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetInsertMemberAmanat(int MMashatId, int UserId);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "ActivateMemberVisa?visa={visa}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //bool PostActivateMemberVisa(int subCommitteId, double lat, double Long);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ActivateMemberVisa?visa={visa}&user={user}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ActivateMemberVisa(string visa, string user);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ActivateWarasaVisa?visa={visa}&user={user}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ActivateWarasaVisa(string visa, string user);


    }
   
}
