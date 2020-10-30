using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Booking : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            foreach (var k in Request.Form.AllKeys)
            {
                if (k.Contains("logoutButton"))
                    return;
            }
        }

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

        if (!IsPostBack)
        {
            BookingMaster.DataBind();

            if (Session["USER"] != null)
            {
                int selectedId = Int32.Parse(BookingMaster.SelectedValue);
                var selectCommand = "select Service.id, title from Service " +
                                    "join MasterService on Service.id = MasterService.ServiceId " +
                                    "where MasterId = " + selectedId + ";";
                BookingService.DataSource = new SqlDataSource(Model.ConnectionString, selectCommand);
                BookingService.DataTextField = "title";
                BookingService.DataValueField = "id";
                BookingService.DataBind();
            }

            BookingYear.Items.Clear();
            BookingMonth.Items.Clear();
            BookingDay.Items.Clear();
            BookingHour.Items.Clear();
            BookingMinutes.Items.Clear();

            int startYear = DateTime.Now.Year;
            string[] months = { "январь", "февраль", "март", "апрель", "май", "июнь",
                            "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь"};

            for (int i = 1; i != 31; ++i)
            {
                BookingYear.Items.Add(new ListItem("" + (startYear + i - 1), "" + (startYear + i - 1)));
                BookingDay.Items.Add(new ListItem("" + i, "" + i));
                if (i < 17) BookingHour.Items.Add(new ListItem("" + (5 + i), "" + (5 + i)));
                if (i <= 11) BookingMinutes.Items.Add(new ListItem("" + (i * 5), "" + (i * 5)));
            }

            for (int i = 0; i < months.Length; ++i)
            {
                BookingMonth.Items.Add(new ListItem(months[i], "" + (i + 1)));
            }
        }
    }



    protected void BookServiceButton_Click(object sender, EventArgs e)
    {
        try
        {
            int client_id = ((Client)Session["USER"]).Id;
            int master_id = Int32.Parse(BookingMaster.SelectedValue);
            int service_id = Int32.Parse(BookingService.SelectedValue);

            string datetime = BookingYear.SelectedValue + "/" + BookingMonth.SelectedValue + "/" +
                              BookingDay.SelectedValue + " " + BookingHour.SelectedValue + ":" + BookingMinutes.SelectedValue;

            // Response.Write("<script>alert('" + datetime + "');</script>");
            
            if (Model.isBookedOnDateOnMaster(datetime, master_id))
            {
                Response.Write("<script>alert('Мастер занят в это время/дату!');</script>");
                return;
            }

            Model.AddBooking(client_id, master_id, service_id, datetime);
            Response.Write("<script>alert('Вы успешно забронировали!');</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Что-то пошло не так!" + ex.ToString() + "')</script>");
            return;
        }
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        // delete user from session, redirect
        Session["USER"] = null;
        Response.Redirect("/Pages/Main.aspx");
        return;
    }

}