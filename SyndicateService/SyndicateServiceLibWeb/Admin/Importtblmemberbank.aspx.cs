﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace SyndicateServiceLibWeb.Import
{
    public partial class Importtblmemberbank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!sessionETSMobile.IsAuth)
            //    Response.Redirect("Login.aspx?RedirectURL=" + Server.UrlEncode(Request.Url.ToString()).ToString());
            //if (!sessionETSMobile.IsAdmin)
            //    Response.Redirect("AccessDenied.aspx");
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
                tblmemberbank sqlRow = new tblmemberbank();
                sqlRow.AutoId = Convert.ToInt64(row["AutoId"]);
                sqlRow.MMashatId = Convert.ToInt32(row["MMashatId"]);
                sqlRow.DofatSarfId = Convert.ToInt32(row["DofatSarfId"]);
                sqlRow.summony = Convert.ToDouble(row["summony"]);
                if (row["sendbankdate"] != null && row["sendbankdate"].ToString() != string.Empty)
                    sqlRow.sendbankdate = Convert.ToDateTime(row["sendbankdate"]);
                sqlRow.amanatmony = Convert.ToDouble(row["amanatmony"]);
                if (row["amanatwareddate"] != null && row["amanatwareddate"].ToString() != string.Empty)
                    sqlRow.amanatwareddate = Convert.ToDateTime(row["amanatwareddate"]);
                entity.tblmemberbanks.Add(sqlRow);
            }
            dtExcel.Clear(); dtExcel.Dispose();
            entity.SaveChanges();
        }
    }
}