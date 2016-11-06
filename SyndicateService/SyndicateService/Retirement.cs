using System;
using System.Collections.ObjectModel;
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
                int hafzano = 0;
                if (!row.IshafzanoNull())
                    hafzano = row.hafzano;
                DateTime? hafzadate = null;
                if (!row.IshafzadateNull())
                    hafzadate = row.hafzadate;

                return new LoginMemberContrect(row.MMashatId, row.MMashatName, row.sarfnumber, hafzano, hafzadate, row.Syndicate, row.SubCommitte);
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
        public ObservableCollection<BankMemberContrect> BankMember(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            ObservableCollection<BankMemberContrect> lst = new ObservableCollection<BankMemberContrect>();
            BankMemberTableAdapter adp = new BankMemberTableAdapter();
            dsETSMobile.BankMemberDataTable tbl = adp.GetData(id);
            foreach (dsETSMobile.BankMemberRow bankMemberRow in tbl)
            {
                DateTime? amanatwareddate = null;
                if (!bankMemberRow.IsamanatwareddateNull())
                    amanatwareddate = bankMemberRow.amanatwareddate;
                
                lst.Add(new BankMemberContrect(bankMemberRow.AutoId, bankMemberRow.MMashatId, bankMemberRow.summony,
                    bankMemberRow.sendbankdate, bankMemberRow.amanatmony, amanatwareddate,
                    bankMemberRow.DofatSarf));
            }

            return lst;
        }
        public ObservableCollection<BankWarasaContrect> BankWarasa(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            ObservableCollection<BankWarasaContrect> lst = new ObservableCollection<BankWarasaContrect>();
            BankWarasaTableAdapter adp = new BankWarasaTableAdapter();
            dsETSMobile.BankWarasaDataTable tbl = adp.GetData(id);
            foreach (dsETSMobile.BankWarasaRow bankWarasaRow in tbl)
            {
                DateTime? amanatwareddate = null;
                if (!bankWarasaRow.IsamanatwareddateNull())
                    amanatwareddate = bankWarasaRow.amanatwareddate;

                lst.Add(new BankWarasaContrect(bankWarasaRow.AutoId, bankWarasaRow.MMashatId, bankWarasaRow.PersonId,
                    bankWarasaRow.visanumber, bankWarasaRow.summony, bankWarasaRow.sendbankdate,
                    bankWarasaRow.amanatmony, amanatwareddate, bankWarasaRow.newid));
            }
            return lst;
        }

    }
}
