using System;
using System.Collections.Generic;
using System.Web;

namespace SyndicateServiceLibWeb
{
    /// <summary>
    /// Summary description for TheSessions
    /// </summary>
    public class sessionETSMobile
    {
        public sessionETSMobile()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int UserID
        {
            get
            {
                if (HttpContext.Current.Session["ETSMobileUserID"] != null)
                    return Convert.ToInt32(HttpContext.Current.Session["ETSMobileUserID"]);
                else return -1;
            }
            set { HttpContext.Current.Session["ETSMobileUserID"] = value; }
        }

        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["ETSMobileUserName"] != null)
                    return HttpContext.Current.Session["ETSMobileUserName"].ToString();
                else return null;
            }
            set { HttpContext.Current.Session["ETSMobileUserName"] = value; }
        }

        public static bool IsAdmin
        {
            get
            {
                if (HttpContext.Current.Session["ETSMobileIsAdmin"] != null)
                    return (bool) HttpContext.Current.Session["ETSMobileIsAdmin"];
                else return false;
            }
            set { HttpContext.Current.Session["ETSMobileIsAdmin"] = value; }
        }

        public static bool IsAuth
        {
            get
            {
                if (UserID == -1)
                    return false;
                else
                    return true;
            }

        }
    }

}