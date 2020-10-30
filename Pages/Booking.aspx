<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Pages_Booking" %>

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
                <div class="container">
                    <div class="row align-items-center">
                        <h3 style="margin-right: 5px;">Выберите дату: </h3>
                        <asp:DropDownList ID="BookingYear" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                        <asp:DropDownList ID="BookingMonth" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                        <asp:DropDownList ID="BookingDay" runat="server" AutoPostBack="false">
                        </asp:DropDownList>
                    </div>
                    <div class="row align-items-center">
                        <h3 style="margin-right: 5px;">Выберите время: </h3>
                        <asp:DropDownList ID="BookingHour" runat="server" AutoPostBack="false"></asp:DropDownList>
                        <asp:DropDownList ID="BookingMinutes" runat="server" AutoPostBack="false"> </asp:DropDownList>
                    </div>

                    <div class="row align-items-center">
                        <h3 style="margin-right: 5px;">Выберите мастера: </h3>
                        <asp:DropDownList ID="BookingMaster" runat="server" DataSourceID="MastersDataSource" DataTextField="LastName" DataValueField="Id" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="MastersDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SpaDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [FirstName], [LastName], [Id] FROM [Master]"></asp:SqlDataSource>
                    </div>

                    <div class="row align-items-center">
                        <h3 style="margin-right: 5px;">Выберите услугу: </h3>
                        <asp:DropDownList ID="BookingService" runat="server">
                        </asp:DropDownList>
                    </div>

                    <asp:Button ID="BookServiceButton" runat="server" Text="Забронировать" OnClick="BookServiceButton_Click" CssCLass="btn btn-dark"/>
                </div>
            </div>
            <!-- CONTENT -->

            <div class="col-sm-1"></div>
        </div>
    </form>
</body>
</html>
