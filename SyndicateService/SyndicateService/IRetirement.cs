using System.ServiceModel;
using System.ServiceModel.Web;
using SyndicateServiceLib.DataContracts;


namespace SyndicateServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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
        BankMemberContrect BankMember(string value);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "BankWarasa/{value}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BankWarasaContrect BankWarasa(string value);
    }

   
}
