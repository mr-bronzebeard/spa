using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyBookings : System.Web.UI.Page
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
            foreach (var k in Request.Form.AllKeys)
            {
                if (k.Contains("pay_button"))
                {
                    int id = Int32.Parse(k.Substring(("pay_button").Length));
                    Model.UpdateBookingStatus(id, Model.BookingStatus.PAYED);
                    Response.Write("<script>alert('ПРЕДОПЛАТА СНЯТА С ВАШЕЙ КАРТЫ.')</script>");
                    break;
                }

                if (k.Contains("remove_button"))
                {
                    int id = Int32.Parse(k.Substring(("remove_button").Length));
                    Model.DeleteBookingByID(id);
                    Response.Write("<script>alert('БРОНЬ СНЯТА')</script>");
                    break;
                }

                if (k.Contains("refuse_button"))
                {                    
                    int id = Int32.Parse(k.Substring(("refuse_button").Length));
                    Model.UpdateBookingStatus(id, Model.BookingStatus.BOOKED); ;
                    Response.Write(String.Format("<script>alert('ХОРОШО. ДЕНЬГИ ВЕРНУЛИСЬ ВАМ НА КАРТУ')</script>", id));
                    break;
                }
            }
        }

        var bookings = Model.GetBookingByClientId(((Client)Session["USER"]).Id);

        int cnt = 1;
        foreach (var b in bookings)
        {
            TableRow row = new TableRow();
            Button remove_btn, pay_btn, refuse_btn;

            TableCell num = new TableCell();
            num.Text = "" + cnt;

            TableCell datetime = new TableCell();
            datetime.Text = b.ServiceDateTime;

            TableCell master = new TableCell();
            master.Text = b.MasterFirstName + " " + b.MasterLastName;

            TableCell service = new TableCell();
            service.Text = b.ServiceTitle;

            TableCell cost = new TableCell();
            cost.Text = "" + b.ServiceCost;

            // ACTIONS: delete, pay, refuse service
            TableCell actions = new TableCell();
            if (b.BookingStatus == Model.BookingStatus.BOOKED.ToString())
            {
                pay_btn = new Button();
                pay_btn.Text = "ОПЛАТИТЬ";
                pay_btn.ID = "pay_button" + b.Id;

                remove_btn = new Button();
                remove_btn.Text = "СНЯТЬ БРОНЬ";
                remove_btn.ID = "remove_button" + b.Id;

                actions.Controls.Add(remove_btn);
                actions.Controls.Add(pay_btn);
            }
            else if (b.BookingStatus == Model.BookingStatus.PAYED.ToString())
            {
                refuse_btn = new Button();
                refuse_btn.Text = "ОТКАЗАТЬСЯ";
                refuse_btn.ID = "refuse_button" + b.Id;

                actions.Controls.Add(refuse_btn);
            }            
            // ACTIONS

            row.Controls.Add(num);
            row.Controls.Add(datetime);
            row.Controls.Add(master);
            row.Controls.Add(service);
            row.Controls.Add(cost);
            row.Controls.Add(actions);

            BookingTable.Rows.Add(row);
            cnt += 1;
        }
        bookings = null;
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // delete user from session, redirect
        Session["USER"] = null;
        Response.Redirect("/Pages/Main.aspx");
    }
}