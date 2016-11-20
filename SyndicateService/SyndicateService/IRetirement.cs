using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using SyndicateServiceLib.DataContracts;


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
        
    }
   
}
