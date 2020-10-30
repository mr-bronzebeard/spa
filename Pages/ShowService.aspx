<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowService.aspx.cs" Inherits="Pages_ShowService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- HEADER -->
        <div class="nav navbar nav">
            <div class="col-sm-9">
                <a href="/Pages/Main.aspx" class="h2 navbar-text">SPA САЛОН "КЛЕОПАТРА"</a>
            </div>
            <div class="col-sm-3">
                <a href="/Pages/Registration.aspx" id="RegistrationHref" runat="server" class="h4 navbar-text">РЕГИСТРАЦИЯ</a>
                <a href="/Pages/Login.aspx" id="LoginHref" runat="server" class="h4 navbar-text">ВОЙТИ</a>
                <a href="/Pages/MyBookings.aspx" id="MyBookingsHref" runat="server" class="h4 navbar-text">МОИ БРОНИ</a>
                <asp:Button ID="logoutButton" runat="server" Text="ВЫЙТИ" OnClick="logoutButton_Click" />
            </div>
        </div>
        <!-- HEADER -->
        <div></div>


        <div class="row">
            <div class="col-sm-1"></div>
            <!-- MENU -->
            <div class="col-sm-3">
                <div class="container" id="MainMenu">
                    <h2>ГЛАВНОЕ МЕНЮ</h2>
                    <a href="/Pages/Masters.aspx" class="h3">МАСТЕРА</a><br />
                    <a href="/Pages/Services.aspx" class="h3">УСЛУГИ</a><br />
                    <a href="/Pages/Booking.aspx" id="BookingHref" runat="server" class="h3">БРОНИРОВАНИЕ</a><br />
                </div>
            </div>
            <!-- MENU -->


            <!-- CONTENT -->
            <div class="col-sm-7" id="ContentPlace">

                <!-- SERVICE -->
                <div>
                    <% 
                        if (Session["SERVICE_ID"] != null)
                        {
                            var service = Model.GetServiceByID((int)Session["SERVICE_ID"]);

                            if (service != null)
                            {
                                Response.Write("<div class='row' style='margin-bottom: 20px;'>");
                                Response.Write(
                                   String.Format(
                                       @"<div class='col-sm-5'><img src='{3}' width='300'></div>
                                        <div class='col-sm-7'>
                                        <h3>{0}</h3>
                                        <h4>{1}</h4>
                                        <h4>{2}</h4>
                                        </div>",
                                service.Title, service.Description, service.Cost, "data:image/png;base64," + Convert.ToBase64String(service.Image)));
                                Response.Write("</div>");
                            }
                            else
                            {
                                Response.Write("НЕТ УСЛУГИ С ТАКИМ ID");
                            }
                        }
                        else
                        {
                            Response.Write("НЕТ УСЛУГИ С ТАКИМ ID");
                        }
                    %>
                </div>
                <!-- SERVICE -->

                <!-- COMMENTS -->
                <h2 style="margin-bottom: 10px;">ОТЗЫВЫ</h2>
                <div>
                    <%
                        if (Session["SERVICE_ID"] != null)
                        {
                            var reviews = Model.GetServiceReview((int)Session["SERVICE_ID"]);

                            if (reviews.Count != 0)
                            {
                                foreach (var r in reviews)
                                {
                                    Response.Write(
                                    String.Format(
                                       @"<div class='container' style='margin-bottom: 20px;'>
                                    <div class='row'><h4>{0} @ {1}</h4></div>
                                    <div class='row'><h5>{2}</h5></div>
                                    </div>",
                                    r.ClientName, r.Date, r.Text));
                                }

                                reviews = null;
                            }
                            else
                            {
                                Response.Write("ЕЩЁ НЕТ ОТЗЫВОВ!");
                            }
                        }
                        else
                        {
                            Response.Write("НЕТ УСЛУГИ С ТАКИМ ID");
                        }
                    %>
                </div>
                <div class="container">
                    <% 
                        if (Session["USER"] != null)
                        {
                            NewReviewTextBox.Visible = true;
                            AddNewReview.Visible = true;
                            message.Visible = false;
                        }
                        else
                        {
                            NewReviewTextBox.Visible = false;
                            AddNewReview.Visible = false;
                            message.Visible = true;
                        }
                    %>
                    <div class="row">
                        <asp:Label ID="message" runat="server">ЧТОБЫ ИМЕТЬ ВОЗМОЖНОСТЬ ОСТАВЛЯТЬ ОТЗЫВЫ, ВЫ ДОЛЖНЫ ВОЙТИ В СИСТЕМУ.</asp:Label>
                        <asp:TextBox ID="NewReviewTextBox" runat="server" placeholder="Введите отзыв..."></asp:TextBox>
                        <asp:Button ID="AddNewReview" runat="server" Text="ОСТАВИТЬ ОТЗЫВ" OnClick="AddNewReview_Click" />
                    </div>
                </div>
                <!-- COMMENTS -->
            </div>
            <!-- CONTENT -->
            <div class="col-sm-1"></div>
        </div>
    </form>
</body>
</html>
