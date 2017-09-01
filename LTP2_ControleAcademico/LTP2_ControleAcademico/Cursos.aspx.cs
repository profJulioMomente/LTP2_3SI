using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTP2_ControleAcademico
{
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {
            //ID = 0;
            preencher_dados();
        }

        private void preencher_dados()
        {
            //conectCurso C = new conectCurso();
            //C.configurarConexao();

            //tabelaCursos.DataSource = C.visualizarCursos();
            //tabelaCursos.DataBind();
        }

        protected void gdvCursos_RowCommand(object sender , GridViewCommandEventArgs e)
        {
            //ID = Convert.ToInt32(e.CommandArgument);

            //if (e.CommandName == "editar")
            //{
            //    Response.Redirect("Curso.aspx");
            //}
            //if (e.CommandName == "excluir")
            //{
            //    conectCurso C = new conectCurso();
            //    C.ID_Curso = ID;
            //    C.configurarConexao();
            //    C.excluirItem();

            //    Response.Redirect("VisualizarCursos.aspx");
            //}
        }
    }
}