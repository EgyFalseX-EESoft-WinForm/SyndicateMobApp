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
                bool active = false;
                if (!row.IsActivateNull())
                    active = row.Activate;
                DateTime? activeDate = null;
                if (!row.IsActivateDateNull())
                    activeDate = row.ActivateDate;

                return new LoginMemberContrect(row.MMashatId, row.MMashatName, row.sarfnumber, hafzano, hafzadate, row.Syndicate, row.SubCommitte, active, activeDate);
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
                int hafzano = 0;
                if (!row.IshafzaNull())
                    hafzano = row.hafza;
                DateTime? hafzadate = null;
                if (!row.IshafzadateNull())
                    hafzadate = row.hafzadate;
                bool active = false;
                if (!row.IsActivateNull())
                    active = row.Activate;
                DateTime? activeDate = null;
                if (!row.IsActivateDateNull())
                    activeDate = row.ActivateDate;
                return new LoginWarasaContrect(row.PersonId, row.MMashatId, row.personName, row.yasref, row.responsiblesarf, row.code60, row.MMashatName, row.Syndicate, row.SubCommitte
                    , row.ResPersonName, hafzano, hafzadate, active, activeDate);
            }
            return null;
        }
        
        public LoginContrect Login(string user, string pass)
        {
            userTableAdapter adp = new userTableAdapter();
            dsETSMobile.userDataTable tbl = adp.GetDataByUser_Pass(user, pass);
            if (tbl.Count > 0)
            {
                dsETSMobile.userRow row = tbl[0];
                return new LoginContrect(row.user_id, row.user_name, row.user_pass, row.IsSyndicateIdNull() ? 0 : row.SyndicateId, row.IssubCommitteIdNull() ? 0 : row.subCommitteId);
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
                int? hafzano = null;
                if (!row.IshafzanoNull())
                    hafzano = row.hafzano;
                DateTime? hafzadate = null;
                if (!row.IshafzadateNull())
                    hafzadate = row.hafzadate;
                bool activate = false;
                if (!row.IsActivateNull())
                    activate = row.Activate;
                DateTime? activateDate = null;
                if (!row.IsActivateDateNull())
                    activateDate = row.ActivateDate;

                returnItem = new MemberInfoContrect(row.MMashatName, row.Syndicate, row.SubCommitte, hafzano, hafzadate, activate, activateDate);
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

                int? hafza = null;
                if (!row.IshafzaNull())
                    hafza = row.hafza;
                DateTime? hafzadate = null;
                if (!row.IshafzadateNull())
                    hafzadate = row.hafzadate;
                bool activate = false;
                if (!row.IsActivateNull())
                    activate = row.Activate;
                DateTime? activateDate = null;
                if (!row.IsActivateDateNull())
                    activateDate = row.ActivateDate;

                returnItem = new WarasaInfoContrect(row.personName, row.Syndicate, row.SubCommitte, hafza, hafzadate, activate, activateDate);
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

        public ObservableCollection<AppOptionContrect> GetAppOption()
        {
            ObservableCollection<AppOptionContrect> lst = new ObservableCollection<AppOptionContrect>();
            AppOptionTableAdapter adp = new AppOptionTableAdapter();
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
            dsETSMobile.AppOptionDataTable tbl = adp.GetData();
            foreach (dsETSMobile.AppOptionRow row in tbl)
                lst.Add(new AppOptionContrect(row.option_name, row.option_value));
            return lst;
        }

        public string GetInsertMemberAmanat(int MMashatId, int UserId)
        {
            QueriesTableAdapter adp = new QueriesTableAdapter();
            try
            {
                return (string)adp.RequestAmanat(MMashatId, UserId);
            }
            catch ( Exception ex)
            {
                return ex.Message;   
            }
            
        }

        public string ActivateMemberVisa(string visa, string user)
        {
            int visaToActive;
            int userToActive;
            if (!int.TryParse(visa, out visaToActive) || !int.TryParse(user, out userToActive))
                return "رقم غير صحيح";
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            bool active = Convert.ToBoolean(adpQry.IsMemberVisaActivated(visaToActive));
            if (active)
                return "تم التفعيل مسبقا";
            string userAuth = adpQry.CheckUserActiveMemAuth(visaToActive, userToActive).ToString();
            if (userAuth != "1")
                return userAuth;

            int result = adpQry.ActivateMemberVisa(userToActive, visaToActive);
            if (result > 0)
                return "تم التفعيل";
            else
                return "لم يتم التفعيل";
        }
        public string ActivateWarasaVisa(string visa, string user)
        {
            int visaToActive;
            int userToActive;
            if (!int.TryParse(visa, out visaToActive) || !int.TryParse(user, out userToActive))
                return "رقم غير صحيح";
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            bool active = Convert.ToBoolean(adpQry.IsWarasaVisaActivated(visaToActive));
            if (active)
                return "تم التفعيل مسبقا";
            string userAuth = adpQry.CheckUserActiveWarasaAuth(visaToActive, userToActive).ToString();
            if (userAuth != "1")
                return userAuth;
            int result = adpQry.ActivateWarasaVisa(userToActive, visaToActive);
            if (result > 0)
                return "تم التفعيل";
            else
                return "لم يتم التفعيل";
        }

        public ObservableCollection<ActivateVisaContrect> GetMemberVisaByHafza(string hafza, string user)
        {
            ObservableCollection<ActivateVisaContrect> returnItem = new ObservableCollection<ActivateVisaContrect>();
            int hafzaNumber;
            if (!int.TryParse(hafza, out hafzaNumber))
                return null;
            int userNumber;
            if (!int.TryParse(user, out userNumber))
                return null;
            dsETSMobile.DisactiveMemberVisaDataTable tbl = new DisactiveMemberVisaTableAdapter().GetData(hafzaNumber, userNumber);
            foreach (dsETSMobile.DisactiveMemberVisaRow item in tbl)
                returnItem.Add(new ActivateVisaContrect(item.MMashatId.ToString(), false));
            return returnItem;
        }
        public ObservableCollection<ActivateVisaContrect> GetWarasaVisaByHafza(string hafza, string user)
        {
            ObservableCollection<ActivateVisaContrect> returnItem = new ObservableCollection<ActivateVisaContrect>();
            int hafzaNumber;
            if (!int.TryParse(hafza, out hafzaNumber))
                return null;
            int userNumber;
            if (!int.TryParse(user, out userNumber))
                return null;
            dsETSMobile.DisactiveWarasaVisaDataTable tbl = new DisactiveWarasaVisaTableAdapter().GetData(hafzaNumber, userNumber);
            foreach (dsETSMobile.DisactiveWarasaVisaRow item in tbl)
                returnItem.Add(new ActivateVisaContrect(item.code60.ToString(), false));
            return returnItem;
        }

        public string PostActiveMemberVisa(string visa, string user)
        {
            if (visa.Trim() == string.Empty)
                return "رقم غير صحيح";

            int user_number;
            if (!int.TryParse(user, out user_number))
                return "رقم غير صحيح";

            string[] visaList = visa.Split('|');
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            foreach (string item in visaList)
            {
                int number;
                if (!int.TryParse(item, out number))
                    continue;
                //check for user authorization
                string userAuth = adpQry.CheckUserActiveMemAuth(number, user_number).ToString();
                if (userAuth != "1")
                    return userAuth;
                int aa = adpQry.ActivateMemberVisa(user_number, number);
            }
            return "تم التفعيل";
        }
        public string PostActiveWarasaVisa(string visa, string user)
        {
            if (visa.Trim() == string.Empty)
                return "رقم غير صحيح";

            int user_number;
            if (!int.TryParse(user, out user_number))
                return "رقم غير صحيح";

            string[] visaList = visa.Split('|');
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            foreach (string item in visaList)
            {
                int number;
                if (!int.TryParse(item, out number))
                    continue;
                string userAuth = adpQry.CheckUserActiveWarasaAuth(number, user_number).ToString();
                if (userAuth != "1")
                    return userAuth;
                adpQry.ActivateWarasaVisa(user_number, number);
            }
            return "تم التفعيل";
        }

        public string GetStopVisaMember(string visa, string user)
        {
            int visaToStop;
            int userToStop;
            if (!int.TryParse(visa, out visaToStop) || !int.TryParse(user, out userToStop))
                return "رقم غير صحيح";

            StopVisaMemberTableAdapter adp = new StopVisaMemberTableAdapter();
            if (adp.RecordExist(visaToStop) > 0)
                return "تم الايقاف مسبقا";
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            string userAuth = adpQry.CheckUserActiveMemAuth(visaToStop, userToStop).ToString();
            if (userAuth != "1")
                return userAuth;
            int result = adp.Insert(visaToStop, userToStop, DateTime.Now);
            if (result > 0)
                return "تم الايقاف";
            else
                return "لم يتم الايقاف";
        }
        public string GetStopVisaWarasa(string visa, string user)
        {
            int visaToStop;
            int userToStop;
            if (!int.TryParse(visa, out visaToStop) || !int.TryParse(user, out userToStop))
                return "رقم غير صحيح";

            StopVisaWarasaTableAdapter adp = new StopVisaWarasaTableAdapter();
            if (adp.RecordExist(visaToStop) > 0)
                return "تم الايقاف مسبقا";
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            string userAuth = adpQry.CheckUserActiveWarasaAuth(visaToStop, userToStop).ToString();
            if (userAuth != "1")
                return userAuth;
            int result = adp.Insert(visaToStop, userToStop, DateTime.Now);
            if (result > 0)
                return "تم الايقاف";
            else
                return "لم يتم الايقاف";
        }


        public ObservableCollection<RePrintResonContrect> GetRePrintReson()
        {
            ObservableCollection<RePrintResonContrect> lst = new ObservableCollection<RePrintResonContrect>();
            CDreprintresonTableAdapter adp = new CDreprintresonTableAdapter();
            Misc.Misc.SetAllCommandTimeouts(adp, Misc.Misc.UnlimitedTimeOut);
            dsETSMobile.CDreprintresonDataTable tbl = adp.GetData();
            foreach (dsETSMobile.CDreprintresonRow cdSyndicateRow in tbl)
                lst.Add(new RePrintResonContrect(cdSyndicateRow.reprintresonid, cdSyndicateRow.reprintreson));
            return lst;
        }
        public string GetReprintMember(string visa, string user, string type)
        {
            int visaToPrint;
            int userToPrint;
            byte typeToPrint;
            if (!int.TryParse(visa, out visaToPrint) || !int.TryParse(user, out userToPrint) || !byte.TryParse(type, out typeToPrint))
                return "رقم غير صحيح";

            TBLReprintMemberTableAdapter adp = new TBLReprintMemberTableAdapter();
            
            if (adp.CheckForExists(visaToPrint, DateTime.Now.AddDays(-45), DateTime.Now) > 0)
                return "تم الادخال مسبقا";
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            string userAuth = adpQry.CheckUserActiveMemAuth(visaToPrint, userToPrint).ToString();
            if (userAuth != "1")
                return userAuth;
            
            int result = adp.Insert(typeToPrint, DateTime.Now, visaToPrint, userToPrint, DateTime.Now);
            if (result > 0)
                return "تم الاضافة";
            else
                return "لم يتم الاضافة";
        }
        public string GetReprintWarasa(string visa, string user, string type)
        {
            int visaToPrint;
            int userToPrint;
            byte typeToPrint;
            if (!int.TryParse(visa, out visaToPrint) || !int.TryParse(user, out userToPrint) || !byte.TryParse(type, out typeToPrint))
                return "رقم غير صحيح";

            TBLReprintWarasaTableAdapter adp = new TBLReprintWarasaTableAdapter();

            if (adp.CheckForExists(visaToPrint, DateTime.Now.AddDays(-45), DateTime.Now) > 0)
                return "تم الادخال مسبقا";
            QueriesTableAdapter adpQry = new QueriesTableAdapter();
            string userAuth = adpQry.CheckUserActiveWarasaAuth(visaToPrint, userToPrint).ToString();
            if (userAuth != "1")
                return userAuth;

            int result = adp.Insert(typeToPrint, DateTime.Now, visaToPrint, userToPrint, DateTime.Now);
            if (result > 0)
                return "تم الاضافة";
            else
                return "لم يتم الاضافة";
        }
    }
}
