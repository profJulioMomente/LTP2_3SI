<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disciplinas.aspx.cs" Inherits="LTP2_ControleAcademico.Disciplinas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Controle Acadêmico</title>
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>

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

    <meta charset="utf-8" />
    <meta name="viewport" content="width-device-width, initial-scale=1" />
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <h3><strong>Visualização de Disciplinas</strong></h3>
        </div>
        <div style="padding-left: 30px">
            <a id="lknAdicionar" href="NovaDisciplina.aspx" class="btn btn-default">Adicionar Nova</a>
        </div>
        <form id="form1" runat="server">
            <div style="padding-left: 150px">
                <br />
                <br />
                <div style="text-align: center" class="row">
                    <div class="col-md-8">
                        <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <br />
                <br />
                <asp:GridView ID="gdvDisciplinas" runat="server" 
                    AutoGenerateColumns="false" Width="80%" 
                    CssClass="table table-hover table-responsive" GridLines="None" 
                    EmptyDataText="Não há disciplinas Cadastrados" 
                    OnRowCommand="gdvDisciplinas_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Editar" runat="server" CommandName="editar" 
                                    CommandArgument='<%# Eval("ID_Disciplina") %>' 
                                    ToolTip="Editar Curso">
                                <span class="glyphicon glyphicon-pencil"></span>
                                </asp:LinkButton>
                                &nbsp
                            <asp:LinkButton ID="Excluir" runat="server" CommandName="excluir" 
                                CommandArgument='<%# Eval("ID_Disciplina") %>' ToolTip="Excluir Curso">
                                <span class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Código" DataField="Codigo_Disciplina" />
                        <asp:BoundField HeaderText="Disciplina" DataField="Nome_Disciplina" />
                        <asp:BoundField HeaderText="Semestre" DataField="Semestre_Disciplina" />
                        <asp:BoundField HeaderText="Carga Horária" DataField="CargaHoraria_Disciplina" />
                        <asp:BoundField HeaderText="Curso" DataField="Curso.Nome" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
        <hr />
    </div>
</body>
</html>
