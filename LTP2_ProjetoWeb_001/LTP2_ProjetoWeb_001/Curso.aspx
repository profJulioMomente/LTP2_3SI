<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curso.aspx.cs" Inherits="LTP2_ProjetoWeb_001.Curso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Curso</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Cadastro de Curso</h3>

        <asp:Label ID="lblSucesso" runat="server"></asp:Label>
    <table>
        <tr>
            <td style="text-align:right">Código:</td>
            <td><asp:TextBox ID="txtCodido" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Curso:</td>
            <td><asp:TextBox ID="txtCurso" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Período:</td>
            <td><asp:TextBox ID="txtPeriodo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Duração:</td>
            <td><asp:TextBox ID="txtDuracao" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Conceito Enade:</td>
            <td><asp:TextBox ID="txtEnade" runat="server"></asp:TextBox></td>
        </tr>
    </table>
        <br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    </div>
    </form>
</body>
</html>
