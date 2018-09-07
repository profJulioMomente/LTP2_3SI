using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaExemplo.Negocio;

namespace SistemaExemplo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            bool ok = nUsuario.ValidarLogin(email, senha);

            if (ok)
            {
                Response.Redirect("cadastroUsuario.aspx");
            }
        }
    }
}