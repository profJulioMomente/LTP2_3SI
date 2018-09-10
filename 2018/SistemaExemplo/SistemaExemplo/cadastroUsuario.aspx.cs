using System;
using System.Collections.Generic;
using System.Data;
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
            //LimparCampos();
            if (!IsPostBack)
            {
                if (Session["usuarioID"] != null && !String.IsNullOrEmpty(Session["usuarioID"].ToString()))
                {
                    if (Session["usuarioID"].ToString() != "0")
                    {
                        preencherFormulario();
                    }

                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            nUsuario usr = new nUsuario();
            usr.Nome = txtNome.Text;
            usr.Email = txtEmail.Text;
            usr.Cpf = txtCPF.Text;
            usr.DataNasc = txtDataNasc.Text;
            usr.Sexo = rblSexo.SelectedValue;

            string erro = "";

            if (Session["usuarioID"] != null && !String.IsNullOrEmpty(Session["usuarioID"].ToString()))
            {
                usr.Id = Convert.ToInt32(Session["usuarioId"]);
                erro = usr.AlterarUsuario();

            }
            else
            {
                usr.Senha = txtSenha.Text;
                //erro = usr.AdicionarUsuario();
            }
            LimparCampos();

            if (erro == "")
            {
                divSucesso.Style.Value = "display:block;";
                divErro.Style.Value = "display:none;";
            }
            else
            {
                divSucesso.Style.Value = "display:none;";
                divErro.Style.Value = "display:block;";
            }

        }

        private void LimparCampos()
        {
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtCPF.Text = String.Empty;
            txtDataNasc.Text = String.Empty;
            txtSenha.Text = String.Empty;
        }

        public void preencherFormulario()
        {

            string usrId = Session["usuarioID"].ToString();
            DataTable dt = new DataTable();

            nUsuario.RecuperarUsuarios("id", usrId, "=", dt);

            txtNome.Text = dt.Rows[0]["nome"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            txtCPF.Text = dt.Rows[0]["cpf"].ToString();
            txtDataNasc.Text = Convert.ToDateTime(dt.Rows[0]["dataNasc"]).ToString("yyyy-MM-dd");
            rblSexo.SelectedValue = dt.Rows[0]["sexo"].ToString();
            txtSenha.Text = String.Empty;
        }
    }
}