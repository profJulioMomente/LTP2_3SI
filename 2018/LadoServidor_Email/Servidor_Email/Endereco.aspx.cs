using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servidor_Email
{
    public partial class Endereco : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {

        }

        protected void btnEnviar_ServerClick(object sender , EventArgs e)
        {
            EndercoServer E = new EndercoServer();

            E.logradouro = txtLogradouro.Value;
            E.numero = txtNumero.Value;
            E.cidade = txtCidade.Value;
            E.estado = txtEstado.Value;

            bool retorno = E.Inserir();

        }
    }
}