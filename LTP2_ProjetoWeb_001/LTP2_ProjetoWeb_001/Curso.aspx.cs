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
            
        }

        protected void btnSalvar_Click(object sender , EventArgs e)
        {
            C.configurarConexao();

            C.Codigo_Curso = txtCodido.Text;
            C.Nome_Curso = txtCurso.Text;
            C.Periodo_Curso = txtPeriodo.Text;
            C.Duracao_Curso = txtDuracao.Text;
            C.Enade_Curso = txtEnade.Text;

            C.InserirCurso();

            lblSucesso.Text = "Curso Inserido com sucesso!";
        }
    }
}