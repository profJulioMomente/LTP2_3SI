using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTP2_ProjetoWeb_001
{
    public partial class Curso : System.Web.UI.Page
    {
        conectCurso C = new conectCurso();
        protected void Page_Load(object sender , EventArgs e)
        {
            if (!IsPostBack)
            {
                if (VisualizarCursos.ID != 0)
                {
                    preencherFormulario();
                }
            }
        }

        protected void btnSalvar_Click(object sender , EventArgs e)
        {
            C.configurarConexao();

            string test = txtDuracao.Text;

            C.Codigo_Curso = txtCodido.Text;
            C.Nome_Curso = txtCurso.Text;
            C.Periodo_Curso = txtPeriodo.Text;
            C.Duracao_Curso = txtDuracao.Text;
            C.Enade_Curso = txtEnade.Text;

            if (VisualizarCursos.ID == 0)
            {
                C.InserirCurso();
            } else
            {
                C.ID_Curso = VisualizarCursos.ID;
                C.alterarItem();
            }

            //lblSucesso.Text = "Curso Inserido com sucesso!";
            Response.Redirect("VisualizarCursos.aspx");

        }

        public void preencherFormulario()
        {
            int ID = VisualizarCursos.ID;

            C.configurarConexao();
            C = C.retornarItem(ID);

            txtCodido.Text = C.Codigo_Curso;
            txtCurso.Text = C.Nome_Curso;
            txtPeriodo.Text = C.Periodo_Curso;
            txtDuracao.Text = C.Duracao_Curso;
            txtEnade.Text = C.Enade_Curso;
        }
    }
}