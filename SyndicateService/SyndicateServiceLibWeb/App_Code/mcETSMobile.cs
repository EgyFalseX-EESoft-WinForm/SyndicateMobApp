using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data.OleDb;


namespace SyndicateServiceLibWeb
{
    /// <summary>
    /// Summary description for MC
    /// </summary>
    public class mcETSMobile
    {
        // Paths
        public static string constr
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["loginConnectionString"].ToString();
            }
        }

        public static string EtsMobileConnectionstring
        {
            get
            {
                return
                    System.Configuration.ConfigurationManager.ConnectionStrings["ETSMOBILEConnectionString"].ToString();
            }
        }

        public static string ExcelFiles = "~/Download/ExcelFiles/";
        public static string ReportURL = @"http://LOCALHOST:8081/ReportServer";
        public static string ReportPath = @"/StoreReport/";
        public static string FilesPath = "Assets/";
        public static string UploadedFiles = "~/App_Data/UploadedFiles/";
        public static string SiteUrl = "http://egycstest.com/NewsFiles/";

        public mcETSMobile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public enum AppOptions
        {
            Options1
        }

        public static void InsertEmptyValue(ref SqlCommand cmd)
        {
            foreach (SqlParameter item in cmd.Parameters)
            {
                if (IsNullOrEmpty(item.Value))
                {
                    if (item.SqlDbType == SqlDbType.Bit)
                        item.Value = "False";
                    else
                        item.Value = DBNull.Value;
                }
            }
        }

        public static bool IsNullOrEmpty(object obj)
        {
            if (obj == null)
                return true;

            if (obj.ToString() == string.Empty)
                return true;
            else
                return false;
        }

        public static string ConvertToDateYMD(string PDate)
        {
            if (PDate == string.Empty)
                return "";
            string ReturnMe = string.Empty;
            DateTime MyDate = Convert.ToDateTime(PDate);
            ReturnMe = String.Format("{0}-{1}-{2}", MyDate.Year, MyDate.Month, MyDate.Day);
            return ReturnMe;
        } //Date Convertor

        public static string ConvertToDateYMDhms(string PDate)
        {
            //yyyy-mm-dd hh-mm-ss  for Convert(20). CONVERT(DATETIME, GetDate(), 20)
            if (PDate == string.Empty)
                return "";
            string ReturnMe = string.Empty;
            DateTime MyDate = Convert.ToDateTime(PDate);
            ReturnMe = String.Format("{0}-{1}-{2} {3}:{4}:{5}", MyDate.Year, MyDate.Month, MyDate.Day, MyDate.Hour,
                MyDate.Minute, MyDate.Second);
            return ReturnMe;
        } //Date Convertor

        public static Single ConvertStringToInt(string str)
        {
            string ReturnMe = string.Empty;
            int count = 0;
            foreach (char c in str.ToCharArray())
            {
                if (c == Convert.ToChar(".") && count < 1)
                {
                    ReturnMe += c.ToString();
                    count++;
                }
                if (char.IsNumber(c))
                {
                    ReturnMe += c.ToString();
                }
            }
            if (ReturnMe == string.Empty)
            {
                ReturnMe = "0";
            }
            return Convert.ToSingle(ReturnMe);
        }

        public static bool IsDecimal(string theValue)
        {
            try
            {
                Convert.ToDouble(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsDecimal

        public static bool IsInteger(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger

        public static SqlConnection DBConnection
        {
            get
            {

                SqlConnection con1 = new SqlConnection(constr);
                if (con1.State == ConnectionState.Open)
                {
                    con1.Close();
                }
                return con1;
            }
        } //Sql Server connection object

        public static string CheckExp(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627:
                    return "موجود مسبقاً ...";
                case 233:
                    return "SQl Server غير متاح";
                case 2:
                    return "SQl Server غير متاح";
                case 515:
                    string ReturnMe = "يجب مليء" + Environment.NewLine;
                    int tempint = 0;
                    foreach (char Chr in ex.Message.ToCharArray())
                    {
                        //Get column name from error msg and its between ''
                        char Dot = '\'';

                        if (Chr == Dot)
                            tempint++;
                        if (tempint == 1)
                            ReturnMe += Chr;
                        else if (tempint == 2)
                            break;
                    }
                    return ReturnMe + "'";
                default:
                    return "خطاء في بيانات الادخال";
            }
        } // Get Message For Exceptions

        public static DataTable LoadDataTable(string CommandString, bool EnableAddEmptyRow)
        {
            DataTable ReturnMe = new DataTable("FX2011-05");
            using (SqlDataAdapter DA = new SqlDataAdapter(CommandString, DBConnection))
            {
                try
                {
                    DA.Fill(ReturnMe);
                    DataRow row = ReturnMe.NewRow();
                    //row[0] = "0";
                    //row[1] = "اختار";
                    if (EnableAddEmptyRow)
                        ReturnMe.Rows.InsertAt(row, 0);
                }
                catch
                {
                }
            }

            return ReturnMe;
        } //Load Table From Database

        public static DataTable LoadDataTable(string CommandString, string connectionstring)
        {
            DataTable ReturnMe = new DataTable("FX2011-05");
            using (OleDbDataAdapter DA = new OleDbDataAdapter(CommandString, connectionstring))
            {
                try
                {
                    DA.Fill(ReturnMe);
                    DataRow row = ReturnMe.NewRow();
                }
                catch
                {
                }
            }

            return ReturnMe;
        } //Load Table From Database

        public static string GetNewID(string TableName, string ColumnName)
        {
            string ReturnMe = string.Empty;
            SqlConnection Con = DBConnection;
            SqlCommand Cmd =
                new SqlCommand(
                    "SELECT ISNULL(MAX(" + ColumnName + ") + 1, 1) AS NewID FROM " + TableName + " AS NewID", Con);
            SqlDataReader dr;
            try
            {
                Con.Open();
                dr = Cmd.ExecuteReader();
                if (dr.HasRows)
                    dr.Read();
                ReturnMe = dr.GetValue(0).ToString();
            }
            catch (SqlException ex)
            {
                // nothing here
                string x = ex.Message;
            }
            Con.Close();
            return ReturnMe;
        } //Get Unique New ID

        public static string GetOptionValue(AppOptions AppOp)
        {
            string ReturnMe = "0";
            SqlConnection con = DBConnection;
            SqlCommand cmd = new SqlCommand("", con);
            try
            {
                cmd.CommandText = string.Format("Select opvalue From CDOptions Where opname = N'{0}'", AppOp);
                con.Open();
                ReturnMe = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException)
            {
            }
            con.Close();
            return ReturnMe;
        } // Get Option Value From Database

        public static bool GetPagePriv(string PageName, string UserID)
        {
            bool ReturnMe = false;
            SqlConnection con = DBConnection;
            SqlCommand cmd = new SqlCommand("", con);
            try
            {
                con.Open();
                cmd.CommandText =
                    string.Format(@"SELECT COUNT(*) AS Found FROM MenuItemName WHERE (PageName = '{0}') AND 
                EXISTS (SELECT TOP (1) MenuItemNameID FROM RoleDetial WHERE (MenuItemNameID = MenuItemName.MenuItemNameID) AND 
                (RoleID IN (SELECT RoleId FROM UserRoles WHERE (UserId = {1}))))", PageName, UserID);
                string Read = cmd.ExecuteScalar().ToString();
                if (Read != "0")
                    ReturnMe = true;
            }
            catch (SqlException ex)
            {
                string x = ex.Message;
            }
            con.Close();
            return ReturnMe;
        } // Get Privilage For A Page

        public static bool UpdateBulktblmemberbank(SqlCommand cmd)//, dsETSMobile.tblmemberbankDataTable BulkTable
        {
            bool outPut = false;
            //DateTime dtStart = DateTime.Now;
            //const string BulkTableName = "dbo.tblmemberbank";
            //try
            //{
            //    SqlBulkCopy bulkCopy = new SqlBulkCopy(cmd.Connection);
            //    cmd.CommandTimeout = 0;
            //    bulkCopy.BulkCopyTimeout = 0;

            //    bulkCopy.ColumnMappings.Clear();
            //    bulkCopy.ColumnMappings.Add("AutoId", "AutoId");
            //    bulkCopy.ColumnMappings.Add("MMashatId", "MMashatId");
            //    bulkCopy.ColumnMappings.Add("DofatSarfId", "DofatSarfId");
            //    bulkCopy.ColumnMappings.Add("summony", "summony");
            //    bulkCopy.ColumnMappings.Add("sendbankdate", "sendbankdate");
            //    bulkCopy.ColumnMappings.Add("amanatmony", "amanatmony");
            //    bulkCopy.ColumnMappings.Add("amanatwareddate", "amanatwareddate");

            //    bulkCopy.DestinationTableName = BulkTableName;
            //    bulkCopy.BatchSize = BulkTable.Count;
            //    bulkCopy.WriteToServer(BulkTable);
            //    outPut = true;
            //}
            //catch (SqlException ex)
            //{
            //    //Classes.Core.LogException(Logger, ex, Classes.Core.ExceptionLevelEnum.General, Classes.Managers.UserManager.defaultInstance.User.UserId);
            //    //System.Windows.Forms.MessageBox.Show("Error while trying to save Bulk - " + ex.Message);
            //}
            return outPut;
        }

    }
}