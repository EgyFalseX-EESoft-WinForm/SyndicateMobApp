using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SyndicateServiceLibWeb.Import
{
    public partial class ImportTblNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.ToString()).ToString());
            }
            if (!IsPostBack)
                Session["attach"] = null;

        }
        protected void ASPxUploadControlMain_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            DevExpress.Web.ASPxUploadControl uploader = (DevExpress.Web.ASPxUploadControl)sender;
            string FName = "attach" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + uploader.UploadedFiles[0].FileName;
            if (uploader.UploadedFiles.Length == 0)
                return;
            string filepath = MapPath(mcETSMobile.ExcelFiles + FName);
            uploader.UploadedFiles[0].SaveAs(filepath, true);
            Session["attach"] = filepath;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            EtsEntities entity = new EtsEntities();
            if (Session["attach"] == null)
                return;
            DataTable dtExcel = ExcelAPI.LoadExcelFile_VBA(Session["attach"].ToString(), 0, "*");

            foreach (DataRow row in dtExcel.Rows)
            {
                TblNew sqlRow = new TblNew();
                sqlRow.news_id = Convert.ToInt32(row["news_id"]);
                sqlRow.subject = row["subject"].ToString();
                sqlRow.image_path = row["image_path"].ToString();
                sqlRow.contain = row["contain"].ToString();
                if (row["news_date"] != null && row["news_date"].ToString() != string.Empty)
                    sqlRow.news_date = Convert.ToDateTime(row["news_date"]);
                sqlRow.date_in = DateTime.Now;
                entity.TblNews.Add(sqlRow);
            }
            dtExcel.Clear(); dtExcel.Dispose();
            entity.SaveChanges();
        }
    }
}