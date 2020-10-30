using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Registration : System.Web.UI.Page
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

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        Client client = new Client(FirstNameTextBox.Text, LastNameTextBox.Text, FaterNameTextBox.Text, 
                                   EmailTextBox.Text, PasswordTextBox.Text, CreditCardTextBox.Text);

        if (client.FirstName.Length == 0 || client.FatherName.Length == 0 ||
            client.LastName.Length == 0 || client.Email.Length == 0 ||
            client.Password.Length == 0 || client.CreditCard.Length == 0)
        {
            Response.Write("<script>alert('НАДО ЗАПОЛНИТЬ ВСЕ ПОЛЯ!');</script>");
            return;
        }


        Model.AddClient(client);
        Response.Redirect("/Pages/Main.aspx");
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // delete user from session, redirect
        Session["USER"] = null;
        Response.Redirect("/Pages/Main.aspx");
    }
}