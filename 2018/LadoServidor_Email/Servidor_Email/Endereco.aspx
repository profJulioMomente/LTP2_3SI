<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Endereco.aspx.cs" Inherits="Servidor_Email.Endereco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro de Endereço</title>

    <link rel="stylesheet" href="Content/bootstrap.css" />
    <script type="text/javascript" src="Scripts/jquery-3.0.0.js"></script>
    <script type="text/javascript" src="Scripts/umd/popper.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <div class="container">
        <br />
        <h2>Cadastro de Endereço</h2>
        <br />
        <form id="form1" runat="server">
            <div class="row">
                <div class="col-3" style="text-align:right">
                    <label id="lblLogradouro" runat="server" class="col-form-label">Logradouro:</label>
                </div>
                <div class="col-6">
                    <input id="txtLogradouro" runat="server" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-3" style="text-align:right">
                    <label id="lblNumero" runat="server" class="col-form-label">Número:</label>
                </div>
                <div class="col-6">
                    <input id="txtNumero" runat="server" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-3" style="text-align:right">
                    <label id="lblCidade" runat="server" class="col-form-label">Cidade:</label>
                </div>
                <div class="col-6">
                    <input id="txtCidade" runat="server" class="form-control" />
                </div>
            </div>
            <div class="row">
                <div class="col-3" style="text-align:right">
                    <label id="lblEstado" runat="server" class="col-form-label">Estado:</label>
                </div>
                <div class="col-6">
                    <input id="txtEstado" runat="server" class="form-control" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-3" style="text-align:right">
                    <button id="btnEnviar" type="submit" runat="server" class="btn btn-info" onserverclick="btnEnviar_ServerClick">Enviar</button>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
