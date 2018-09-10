<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="SistemaExemplo.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuários</title>
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
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <h3><strong>Visualização de Usuários</strong></h3>
        </div>
        <div style="padding-left: 30px">
            <a id="lknAdicionar" href="cadastroUsuario.aspx" class="btn btn-info">Adicionar Novo</a>
        </div>
        <form id="form1" runat="server">
            <div style="padding-left: 150px">
                <br />
                <br />
                <div style="text-align: center" class="row">
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlOpcao" runat="server" CssClass="form-control">
                            <asp:ListItem Value="nome" Text="Nome" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="email" Text="E-mail"></asp:ListItem>
                            <asp:ListItem Value="cpf" Text="CPF"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <br />
                <br />
                <asp:GridView ID="gdvUsuarios" runat="server" 
                    AutoGenerateColumns="false" Width="80%" 
                    CssClass="table table-hover table-responsive" GridLines="None" 
                    EmptyDataText="Não há usuários cadastrados" 
                    OnRowCommand="gdvUsuarios_RowCommand">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:LinkButton ID="Editar" runat="server" CommandName="editar" 
                                    CommandArgument='<%# Eval("id") %>' 
                                    ToolTip="Editar usuário">
                                <span class="fa fa-pencil"></span>
                                </asp:LinkButton>
                                &nbsp
                            <asp:LinkButton ID="Inativar" runat="server" CommandName="inativar" 
                                CommandArgument='<%# Eval("id") %>' ToolTip="Inativar usuário">
                                <span class="fa fa-ban"></span>
                            </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nome" DataField="nome" />
                        <asp:BoundField HeaderText="CPF" DataField="cpf" />
                        <asp:BoundField HeaderText="Data de Nascimento" DataField="dataNascDisplay" />
                        <asp:BoundField HeaderText="Sexo" DataField="sexoDisplay" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
        <hr />
    </div>
</body>
</html>
