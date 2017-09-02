using LTP2_ControleAcademico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTP2_ControleAcademico
{
    public partial class NovoCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Curso"].ToString() != "0")
                {
                    preencherFormulario();
                }
            }
        }

        protected void btnSalvar_Click(object sender , EventArgs e)
        {
            rnCurso C = new rnCurso();

            C.Codigo = txtCodido.Text;
            C.Nome = txtCurso.Text;
            C.Periodo = txtPeriodo.Text;
            C.Duracao = txtDuracao.Text;
            C.Enade = txtEnade.Text;

            if (Session["Curso"].ToString() == "0")
            {
                C.inserir();
            }
            else
            {
                C.ID_Curso = Convert.ToInt32( Session["Curso"]);
                C.alterar();
            }
            
            ////lblSucesso.Text = "Curso Inserido com sucesso!";
            Response.Redirect("Cursos.aspx");

        }

        public void preencherFormulario()
        {
            rnCurso C = new rnCurso();
            C.ID_Curso = Convert.ToInt32(Session["Curso"]);
            C.recuperarRegistro();
            
            txtCodido.Text = C.Codigo;
            txtCurso.Text = C.Nome;
            txtPeriodo.Text = C.Periodo;
            txtDuracao.Text = C.Duracao;
            txtEnade.Text = C.Enade;
        }
    }
}