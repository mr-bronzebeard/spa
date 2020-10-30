using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Login : System.Web.UI.Page
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

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (EmailTextBox.Text == "admin" && PasswordTextBox.Text == "admin")
        {
            Response.Redirect("/Pages/Admin.aspx");
            return;
        }

        var client = Model.GetClient(EmailTextBox.Text, PasswordTextBox.Text);

        if (client == null)
        {
            Response.Write("<script>alert('НЕТ ПОЛЬЗОВАТЕЛЯ С ТАКИ ЛОГИНОМ ИЛИ ПАРОЛЕМ')</script>");
        }
        else
        {
            Session["USER"] = client;
            Response.Redirect("/Pages/Main.aspx");
        }
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // delete user from session, redirect
        Session["USER"] = null;
        Response.Redirect("/Pages/Main.aspx");
    }
}