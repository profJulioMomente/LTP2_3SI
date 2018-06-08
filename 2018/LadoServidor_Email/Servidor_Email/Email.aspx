<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="Servidor_Email.Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="Content/bootstrap.css" />
    <script type="text/javascript" src="Scripts/jquery-3.0.0.js"></script>
    <script type="text/javascript" src="Scripts/umd/popper.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

</head>
<body>
    <div class="container">
        <br />
        <h3>Contato:</h3>
        <form runat="server">
            <div class="row">
                <div class="col-6 form-group">
                    <label id="lblNome" class="col-form-label" runat="server">Nome:</label>
                    <input class="form-control" id="txtNome" runat="server" name="nome" placeholder="Nome" type="text" required="required" />
                </div>
                <div class="col-6 form-group">
                    <input class="form-control" id="txtEmail" runat="server" name="email" placeholder="Email" type="email" required="required" />
                </div>
            </div>
            <textarea class="form-control" id="txtMensagem" runat="server" name="comentario" placeholder="Comentário" rows="5"></textarea><br />
            <div class="row">
                <div class="col-12 form-group">
                    <button id="btnEnviar" runat="server" class="btn btn-default pull-right" type="submit" onserverclick="btnEnviar_ServerClick">Enviar</button>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
