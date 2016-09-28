using System.ServiceModel;
using SyndicateServiceLib.DataContracts;

namespace SyndicateServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRetirement
    {
        [OperationContract]
        LoginMemberContrect LoginMember(int number);
        [OperationContract]
        LoginWarasaContrect LoginWarasa(int number);
        [OperationContract]
        BankMemberContrect BankMember(int number);
        [OperationContract]
        BankWarasaContrect BankWarasa(int number);
    }

   
}
