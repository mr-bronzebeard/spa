<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Pages_Registration" %>

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
                    <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="FirstNameTextBox" runat="server" placeholder="Введите имя..."  CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="FaterNameTextBox" runat="server" placeholder="Введите отчество..." CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="LastNameTextBox" runat="server" placeholder="Введите фамилию..." CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="EmailTextBox" runat="server" placeholder="Введите email..." CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="PasswordTextBox" runat="server" placeholder="Введите пароль..." CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="CreditCardTextBox" runat="server" placeholder="Введите № кредитной карты..." CssClass="form-control"></asp:TextBox>
                            <asp:Button ID="RegisterButton" runat="server" OnClick="RegisterButton_Click" Text="РЕГИСТРАЦИЯ"  CssClass="form-control btn btn-success"/>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
            </div>
            <!-- CONTENT -->

            <div class="col-sm-1"></div>
        </div>
    </form>
</body>
</html>
