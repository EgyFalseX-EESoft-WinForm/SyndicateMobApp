using SyndicateServiceLib.DataContracts;
using SyndicateServiceLib.Datasource;
using SyndicateServiceLib.Datasource.dsETSMobileTableAdapters;

namespace SyndicateServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Retirement : IRetirement
    {
        public LoginMemberContrect LoginMember(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            LoginMemberTableAdapter adp = new LoginMemberTableAdapter();
            dsETSMobile.LoginMemberDataTable tbl = adp.GetData(id);
            if (tbl.Count > 0)
            {
                dsETSMobile.LoginMemberRow row = tbl[0];
                return new LoginMemberContrect(row.MMashatId, row.MMashatName, row.sarfnumber, row.hafzano, row.hafzadate, row.Syndicate, row.SubCommitte);
            }
            return null;
        }
        public LoginWarasaContrect LoginWarasa(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            LoginWarasaTableAdapter adp = new LoginWarasaTableAdapter();
            dsETSMobile.LoginWarasaDataTable tbl = adp.GetData(id);
            if (tbl.Count > 0)
            {
                dsETSMobile.LoginWarasaRow row = tbl[0];
                return new LoginWarasaContrect(row.PersonId, row.MMashatId, row.personName, row.yasref, row.responsiblesarf, row.code60, row.MMashatName, row.Syndicate, row.SubCommitte, row.ResPersonName);
            }
            return null;
        }
        public BankMemberContrect BankMember(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            BankMemberTableAdapter adp = new BankMemberTableAdapter();
            dsETSMobile.BankMemberDataTable tbl = adp.GetData(id);
            if (tbl.Count > 0)
            {
                dsETSMobile.BankMemberRow row = tbl[0];
                return new BankMemberContrect(row.AutoId, row.MMashatId, row.summony, row.sendbankdate, row.amanatmony, row.amanatwareddate, row.DofatSarf);
            }
            return null;
        }
        public BankWarasaContrect BankWarasa(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            BankWarasaTableAdapter adp = new BankWarasaTableAdapter();
            dsETSMobile.BankWarasaDataTable tbl = adp.GetData(id);
            if (tbl.Count > 0)
            {
                dsETSMobile.BankWarasaRow row = tbl[0];
                return new BankWarasaContrect(row.AutoId, row.MMashatId, row.PersonId, row.visanumber, row.summony, row.sendbankdate, row.amanatmony, row.amanatwareddate, row.newid);
            }
            return null;
        }

    }
}
