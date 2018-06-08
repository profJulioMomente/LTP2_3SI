<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAsp.aspx.cs" Inherits="Servidor_Email.WebFormAsp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <script type="text/javascript" src="Scripts/jquery-3.0.0.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblExemplo" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" CssClass="form-control"></asp:TextBox>
        <asp:DropDownList runat="server" ID="ddlTeste" OnSelectedIndexChanged="ddlTeste_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>


        <asp:Button ID="Button1" runat="server" Height="59px" OnClick="Button1_Click" Text="Button" Width="111px" />


    </div>
    </form>
</body>
</html>
