<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarEnderecos.aspx.cs" Inherits="Servidor_Email.VisualizarEnderecos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Visualização de Endereço</title>

    <link rel="stylesheet" href="Content/bootstrap.css" />
    <script type="text/javascript" src="Scripts/jquery-3.0.0.js"></script>
    <script type="text/javascript" src="Scripts/umd/popper.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

</head>
<body>
    <h2>Endereços Cadastrados</h2>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <form id="form1" runat="server">
                <div>
                    <asp:GridView runat="server" ID="gdvEnderecos" CssClass="table table-bordered table-responsive"></asp:GridView>
                </div>
            </form>
        </div>
        <div class="col-3"></div>
    </div>

</body>
</html>
