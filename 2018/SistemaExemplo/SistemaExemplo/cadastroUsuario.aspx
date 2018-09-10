<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroUsuario.aspx.cs" Inherits="SistemaExemplo.cadastroUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Usuários</title>
    <script type="text/javascript" src="Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>

    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .container {
            background-color: aliceblue;
            padding-left: 0px;
            padding-right: 0px;
        }

        .jumbotron {
            background-color: lightblue;
        }
    </style>

    <meta name="viewport" content="width-device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <h3><strong>Cadastrar novo usuário</strong></h3>
        </div>
        <form id="form1" runat="server">
            <div class="alert-success" id="divSucesso" style="display:none;" runat="server">Sucesso</div>
            <div class="alert-danger" id="divErro" style ="display:none;" runat="server">Erro</div>
            <div class="row">
                <div class="col-9" style="text-align: center">
                    <table style="border-collapse: separate; border-spacing: 10px; width: 100%">
                        <tr>
                            <td style="text-align: right; padding-right: 5px;">Nome:</td>
                            <td>
                                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 5px;">E-mail:</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 5px;">CPF:</td>
                            <td>
                                <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 5px;">Data de nascimento:</td>
                            <td>
                                <asp:TextBox ID="txtDataNasc" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 5px;">Sexo:</td>
                            <td>
                                <asp:RadioButtonList ID="rblSexo" runat="server" >
                                    <asp:ListItem Value="M" Selected="true">&nbsp;Masculino</asp:ListItem>
                                    <asp:ListItem Value="F">&nbsp;Feminino</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 5px;">Senha:</td>
                            <td ><asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-4" style="text-align:right">
                    <asp:Button ID="btnSalvar"  runat="server" CssClass="btn btn-info" OnClick="btnSalvar_Click" Text="Salvar" />
                </div>
                <div class="col-2" style="text-align:right" >
                    <a id="btnVisualizar" href="usuarios.aspx" class="btn btn-info">Ver usuários</a>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
