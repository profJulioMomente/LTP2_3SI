<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarCursos.aspx.cs" Inherits="LTP2_ProjetoWeb_001.VisualizarCursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Cursos</h3>
            <br />
            <br />
            <asp:GridView ID="tabelaCursos" runat="server" AutoGenerateColumns="false" OnRowCommand="tabelaCursos_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:LinkButton ID="Editar" runat="server" CommandName="editar" CommandArgument='<%# Eval("ID_Curso") %>' ToolTip="Editar Usuário">
                            Editar
                            </asp:LinkButton>
                            &nbsp
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
</body>
</html>
