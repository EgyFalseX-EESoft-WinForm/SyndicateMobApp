using System;
using System.Collections.ObjectModel;
using SyndicateServiceLib.DataContracts;
using SyndicateServiceLib.Datasource;
using SyndicateServiceLib.Datasource.dsETSMobileTableAdapters;

namespace SyndicateServiceLib
{
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
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
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
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
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
        public ObservableCollection<SyndicateContrect> GetSyndicate()
        {
            ObservableCollection<SyndicateContrect> lst = new ObservableCollection<SyndicateContrect>();
            CDSyndicateTableAdapter adp = new CDSyndicateTableAdapter();
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
            dsETSMobile.CDSyndicateDataTable tbl = adp.GetData();
            foreach (dsETSMobile.CDSyndicateRow cdSyndicateRow in tbl)
                lst.Add(new SyndicateContrect(cdSyndicateRow.SyndicateId, cdSyndicateRow.Syndicate));
            return lst;
        }
        public ObservableCollection<SubCommitteContrect> GetSubCommitte(string value)
        {
            int id;
            if (!int.TryParse(value, out id))
                return null;
            ObservableCollection<SubCommitteContrect> lst = new ObservableCollection<SubCommitteContrect>();
            CDSubCommitteTableAdapter adp = new CDSubCommitteTableAdapter();
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
            dsETSMobile.CDSubCommitteDataTable tbl = adp.GetDataBySyndicateId(id);

            foreach (dsETSMobile.CDSubCommitteRow cDSubCommitteRow in tbl)
            {
                lst.Add(new SubCommitteContrect
                {
                    SubCommitteId = cDSubCommitteRow.SubCommitteId,
                    SubCommitte = cDSubCommitteRow.SubCommitte,
                    SyndicateId = cDSubCommitteRow.SyndicateId,
                    Lat = cDSubCommitteRow.IsLatNull() ? Convert.ToDouble(0) : cDSubCommitteRow.Lat,
                    Long = cDSubCommitteRow.IsLongNull() ? Convert.ToDouble(0) : cDSubCommitteRow.Long
                });
            }

            return lst;
        }
        public void PostSubCommitte(int subCommitteId, double lat, double Long)
        {
            new CDSubCommitteTableAdapter().SetCoord(lat, Long, subCommitteId);
        }
        public ObservableCollection<NewsFrontPageContrect> GetNewsFrontPage()
        {
            ObservableCollection<NewsFrontPageContrect> lst = new ObservableCollection<NewsFrontPageContrect>();
            TblNewsTableAdapter adp = new TblNewsTableAdapter();
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
            dsETSMobile.TblNewsDataTable tbl = adp.GetData();
            foreach (dsETSMobile.TblNewsRow tblNewsRow in tbl)
            {
                string subject = tblNewsRow.IssubjectNull() ? string.Empty : tblNewsRow.subject;
                string imagePath = tblNewsRow.Isimage_pathNull() ? string.Empty : tblNewsRow.image_path;
                lst.Add(new NewsFrontPageContrect(tblNewsRow.news_id, subject, imagePath));
            }
            return lst;
        }

        public NewsItemContrect GetNewsItem(string value)
        {
            NewsItemContrect returnItem = null;
            int id;
            if (!int.TryParse(value, out id))
                return null;
            dsETSMobile.TblNewsDataTable tbl = new TblNewsTableAdapter().GetDataByID(id);
            if (tbl.Rows.Count > 0)
            {
                dsETSMobile.TblNewsRow row = tbl[0];
                string subject = row.IssubjectNull() ? string.Empty : row.subject;
                string imagePath = row.Isimage_pathNull() ? string.Empty : row.image_path;
                string contain = row.IscontainNull() ? string.Empty : row.contain;
                returnItem = new NewsItemContrect(row.news_id, subject, imagePath, contain);
            }
            return returnItem;
        }

        public MemberInfoContrect GetMemberInfo(string value)
        {
            MemberInfoContrect returnItem = null;
            int id;
            if (!int.TryParse(value, out id))
                return null;
            dsETSMobile.MemberInfoDataTable tbl = new MemberInfoTableAdapter().GetData(id);
            if (tbl.Rows.Count > 0)
            {
                dsETSMobile.MemberInfoRow row = tbl[0];
                returnItem = new MemberInfoContrect(row.MMashatName, row.Syndicate, row.SubCommitte);
            }
            return returnItem;
        }
        public WarasaInfoContrect GetWarasaInfo(string value)
        {
            WarasaInfoContrect returnItem = null;
            int id;
            if (!int.TryParse(value, out id))
                return null;
            dsETSMobile.WarasaInfoDataTable tbl = new WarasaInfoTableAdapter().GetData(id);
            if (tbl.Rows.Count > 0)
            {
                dsETSMobile.WarasaInfoRow row = tbl[0];
                returnItem = new WarasaInfoContrect(row.personName, row.Syndicate, row.SubCommitte);
            }
            return returnItem;
        }

        public ObservableCollection<AdsContrect> GetAds()
        {
            ObservableCollection<AdsContrect> lst = new ObservableCollection<AdsContrect>();
            TblAdsTableAdapter adp = new TblAdsTableAdapter();
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
            dsETSMobile.TblAdsDataTable tbl = adp.GetData();
            foreach (dsETSMobile.TblAdsRow AdsRow in tbl)
                lst.Add(new AdsContrect(AdsRow.ads_id, AdsRow.image_path));
            return lst;
        }
    }
}
