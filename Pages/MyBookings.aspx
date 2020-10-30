<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyBookings.aspx.cs" Inherits="Pages_MyBookings" %>

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
                <!-- ORDERS TABLE -->
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">
                        <asp:Table ID="BookingTable" runat="server" CssClass="table table-hover table-bordered">
                            <asp:TableHeaderRow CssClass="table table-bordered">
                                <asp:TableHeaderCell>№</asp:TableHeaderCell>
                                <asp:TableHeaderCell>ДАТА</asp:TableHeaderCell>
                                <asp:TableHeaderCell>МАСТЕР</asp:TableHeaderCell>
                                <asp:TableHeaderCell>УСЛУГА</asp:TableHeaderCell>
                                <asp:TableHeaderCell>СТОИМОСТЬ</asp:TableHeaderCell>
                                <asp:TableHeaderCell>ДЕЙСТВИЯ</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <!-- ORDERS TABLE -->
            </div>
            <!-- CONTENT -->

            <div class="col-sm-1"></div>
        </div>

    </form>
</body>
</html>
