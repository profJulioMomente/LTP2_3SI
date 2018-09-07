using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaExemplo.Negocio;

namespace SistemaExemplo
{
    public partial class cadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            nUsuario usr = new nUsuario();
            usr.Nome = txtNome.Text;
            usr.Email = txtEmail.Text;
            usr.Cpf = txtCPF.Text;
            usr.DataNasc = txtDataNasc.Text;
            usr.Sexo = rblSexo.SelectedValue;
            usr.Senha = txtSenha.Text;

            usr.AdicionarUsuario();
        }
    }
}