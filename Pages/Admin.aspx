<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Pages_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>ADMIN</h1>
        </div>

        <div>
            <h2>MASTER</h2>
            <asp:TextBox runat="server" ID="masterFirstName"> fname </asp:TextBox>
            <asp:TextBox runat="server" ID="masterLastName"> lname </asp:TextBox>
            <asp:TextBox runat="server" ID="Info"> ifno </asp:TextBox>
            
            Изображение: 
                <asp:FileUpload ID="MasterImage" runat="server" />
            <asp:Button runat="server" ID="AddMasterButton" OnClick="AddMasterButton_Click" Text="Добавить мастера"/>
        </div>

        <div>
            <h2>SERVICE</h2>
            <asp:TextBox runat="server" ID="serviceTitle"> TITLE </asp:TextBox>
            <asp:TextBox runat="server" ID="serviceDescription"> DESCR </asp:TextBox>
            <asp:TextBox runat="server" ID="serviceCost"> COST </asp:TextBox>
            
            Изображение: 
                <asp:FileUpload ID="ServiceImage" runat="server" />
            <asp:Button runat="server" ID="AddServiceButton" OnClick="AddServiceButton_Click" Text="Добавить услугу"/>
        </div>

        <div>
            <h2>master/service</h2>
            <asp:DropDownList runat="server" ID="Master" DataSourceID="MasterDataSource" DataTextField="LastName" DataValueField="Id"></asp:DropDownList>
            <asp:SqlDataSource ID="MasterDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SpaDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [LastName] FROM [Master]"></asp:SqlDataSource>
            <asp:DropDownList runat="server" ID="Service" DataSourceID="ServiceDataSource" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
            <asp:SqlDataSource ID="ServiceDataSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SpaDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [Title] FROM [Service]"></asp:SqlDataSource>
            <asp:Button ID="AddMasterServiceButton" runat="server" OnClick="AddMasterServiceButton_Click" Text="Добавить отношение мастер/услуга" />
        </div>

    </form>
</body>
</html>
