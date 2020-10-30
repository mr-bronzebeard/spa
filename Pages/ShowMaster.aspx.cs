using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ShowMaster : System.Web.UI.Page
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
    }

    protected void AddNewReview_Click(object sender, EventArgs e)
    {
        int MasterId = (int)Session["MASTER_ID"];
        int ClientId = ((Client)Session["USER"]).Id;
        string review = NewReviewTextBox.Text;
        Model.AddMasterReview(ClientId, MasterId, review);
        Response.Redirect("/Pages/ShowMaster.aspx");
    }


    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // delete user from session, redirect
        Session["USER"] = null;
        Response.Redirect("/Pages/Main.aspx");
    }

    protected void ShowMasterInfo()
    {
        if (Session["MASTER_ID"] != null)
        {
            var master = Model.GetMasterByID((int)Session["MASTER_ID"]);

            if (master != null)
            {
                Response.Write("<div class='row' style='margin-bottom: 20px;'>");
                Response.Write(
                   String.Format(
                       @"<div class='col-sm-4'><img src='{2}' height='250'></div>
                          <div class='col-sm-8'>
                          <h3>{0}</h3>
                          <h4>{1}</h4>
                          </div>",
                master.FirstName + " " + master.LastName, master.Information, "data:image/png;base64," + Convert.ToBase64String(master.Picture)));

                Response.Write("<div class='container' style='margin-bottom: 20px;'>");
                Response.Write("<h3>Услуги, предоставляемые мастером:</h3>");

                Response.Write("<ul>");
                foreach (var ser in Model.GetServicesByMasterId(master.ID))
                {
                    Response.Write(String.Format("<li>{0}</li>", ser.Title));
                }
                Response.Write("</ul>");

                Response.Write("</div>");
                Response.Write("</div>");
            }
            else
            {
                Response.Write("НЕТ МАСТЕРА С ТАКИМ ID");
            }
        }
        else
        {
            Response.Write("НЕТ МАСТЕРА С ТАКИМ ID");
        }
    }
}