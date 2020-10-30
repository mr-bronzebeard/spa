using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER"] != null)
        {
            MyBookingsHref.Visible = true;
            BookingHref.Visible = true;
            logoutButton.Visible = true;
            LoginHref.Visible = false;
            RegistrationHref.Visible = false;
        }
        else
        {
            MyBookingsHref.Visible = false;
            logoutButton.Visible = false;
            BookingHref.Visible = false;
            LoginHref.Visible = true;
            RegistrationHref.Visible = true;
        }

        if (IsPostBack)
        {
            int ServiceId = -1;

            if (int.TryParse(Request.Form["show_service"], out ServiceId))
            {
                // Response.Write("VI VIBRALI: " + ServiceId);
                Session["SERVICE_ID"] = ServiceId;
                Response.Redirect("/Pages/ShowService.aspx");
            }
        }
    }

    protected void ShowServices()
    {
        var services = Model.GetServices();
        if (services.Count == 0)
        {
            Response.Write("НЕТУ УСЛУГ, СОРЕ");
        }
        else
        {
            int cnt = 0;
            int MAX_ITEMS_PER_ROW = 3;
            foreach (var s in services)
            {
                if (cnt == 0)
                {
                    Response.Write("<div class='row align-items-start'>");
                }

                Response.Write(
                    String.Format(
                        @"<div style='margin-left: 4px; margin-right: 4px; margin-top: 7px; margin-bottom: 7px;'>
                            <img src='{2}' height='250' width='250'>
                          <h3>{0}</h3>
                          <button class='btn btn-info' name='show_service' type='submit' value={1}>ПОСМОТРЕТЬ БОЛЬШЕ</button>
                          </div>",
                s.Title, s.Id, "data:image/png;base64," + Convert.ToBase64String(s.Image)));
                cnt += 1;

                if (cnt == MAX_ITEMS_PER_ROW)
                {
                    Response.Write("</div>");
                    cnt = 0;
                }
            }
        }
        services = null;
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // delete user from session, redirect
        Session["USER"] = null;
        Response.Redirect("/Pages/Main.aspx");
    }
}