﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Aplicacion_Web_Call_Center
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("error", exc.Message);
            Response.Redirect("Error.aspx");
        }
    }
}