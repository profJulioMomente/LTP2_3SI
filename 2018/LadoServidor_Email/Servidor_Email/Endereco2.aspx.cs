using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servidor_Email
{
    public partial class Endereco2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {
            if (!IsPostBack)
                preencherEstados();
        }

        protected void btnEnviar_ServerClick(object sender , EventArgs e)
        {

            EndercoServer E = new EndercoServer();

            E.logradouro = txtLogradouro.Value;
            E.numero = txtNumero.Value;
            E.cidade = ddl_Cidades.SelectedValue;
            E.estado = ddl_Estados.SelectedValue;

            bool retorno = E.Inserir();
            if (retorno)
                limparCampos();
        }

        protected void ddl_Estados_SelectedIndexChanged(object sender , EventArgs e)
        {
            if (ddl_Estados.SelectedIndex != 0)
            {
                int valor = Convert.ToInt32(ddl_Estados.SelectedValue);
                preencherCidades(valor);
            }
        }

        protected void preencherEstados()
        {
            Estado E = new Estado();

            ddl_Estados.DataSource = E.BuscarEstados();
            ddl_Estados.DataTextField = "Nome";
            ddl_Estados.DataValueField = "Id";
            ddl_Estados.DataBind();

            ddl_Estados.Items.Insert(0 , "-- Selecione --"); //Inserindo primeiro item
        }

        protected void preencherCidades(int estado)
        {
            ddl_Cidades.Controls.Clear();
            ddl_Cidades.Enabled = true;

            Cidade E = new Cidade();

            ddl_Cidades.DataSource = E.BuscarCidades(estado);
            ddl_Cidades.DataTextField = "Nome";
            ddl_Cidades.DataValueField = "Id";
            ddl_Cidades.DataBind();

            ddl_Cidades.Items.Insert(0 , "-- Selecione --"); //Inserindo primeiro item
        }

        private void limparCampos()
        {
            txtLogradouro.Value = String.Empty;
            txtNumero.Value = String.Empty;
            ddl_Estados.SelectedIndex = 0;
            ddl_Cidades.SelectedIndex = 0;
        }
    }
}