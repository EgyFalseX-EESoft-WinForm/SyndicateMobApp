using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Microsoft.AspNet.Identity;

namespace SyndicateServiceLibWeb.Import
{
    public partial class EditTblNews : System.Web.UI.Page
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
        protected void ASPxUploadControlImagePath_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            ASPxUploadControl uploader = (ASPxUploadControl)sender;
            //HiddenField hf = (HiddenField)uploader.Parent.FindControl("HiddenFieldImagePath");
            //string filename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg";
            //string uploadingPath = MapPath(mcETSMobile.UploadedFiles + filename);
            //uploader.UploadedFiles[0].SaveAs(uploadingPath);
            //hf.Value = mcETSMobile.SiteUrl + filename;
            Session["attach"] = mcETSMobile.SiteUrl + uploader.UploadedFiles[0].FileNameInStorage;
        }
        protected void SqlDataSourceMain_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters["@user_in"].Value = Request.LogonUserIdentity.GetUserId();
            if (Session["attach"] != null)
                e.Command.Parameters["@image_path"].Value = Session["attach"];
        }
        protected void SqlDataSourceMain_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            e.Command.Parameters["@user_in"].Value = Request.LogonUserIdentity.GetUserId();
            if (Session["attach"] != null)
                e.Command.Parameters["@image_path"].Value = Session["attach"];
        }
        protected void ASPxGridViewMain_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Session.Remove("attach");
        }
    }
}