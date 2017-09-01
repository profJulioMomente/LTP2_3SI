<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="LTP2_ControleAcademico.Cursos" %>

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
            <h3><strong>Visualização de Cursos</strong></h3>
        </div>
        <div style="padding-left: 30px">
            <a id="lknAdicionar" href="NovoCurso.aspx" class="btn btn-default">Adicionar Novo</a>
        </div>
        <form id="form1" runat="server">
            <div>
                <asp:GridView ID="gdvCursos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" EmptyDataText="Não há cursos Cadastrados" OnRowCommand="gdvCursos_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="Editar" runat="server" CommandName="editar" CommandArgument='<%# Eval("ID_Curso") %>' ToolTip="Editar Curso">
                                <span class="glyphicon glyphicon-pencil"></span>
                                </asp:LinkButton>
                                &nbsp
                            <asp:LinkButton ID="Excluir" runat="server" CommandName="excluir" CommandArgument='<%# Eval("ID_Curso") %>' ToolTip="Excluir Curso">
                                <span class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Código" DataField="Codigo_Curso" />
                        <asp:BoundField HeaderText="Curso" DataField="Nome_Curso" />
                        <asp:BoundField HeaderText="Período" DataField="Periodo_Curso" />
                        <asp:BoundField HeaderText="Duração" DataField="Duracao_Curso" />
                        <asp:BoundField HeaderText="Enade" DataField="Enade_Curso" />
                    </Columns>
                </asp:GridView>
            </div>
        </form>
        <hr />
    </div>
</body>
</html>
