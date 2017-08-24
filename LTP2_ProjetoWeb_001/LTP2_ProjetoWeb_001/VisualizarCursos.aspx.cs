using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTP2_ProjetoWeb_001
{
    public partial class VisualizarCursos : System.Web.UI.Page
    {
        public static int ID;

        protected void Page_Load(object sender , EventArgs e)
        {
            ID = 0;
            preencher_dados();
        }

        private void preencher_dados()
        {
            conectCurso C = new conectCurso();
            C.configurarConexao();

            tabelaCursos.DataSource = C.visualizarCursos();
            tabelaCursos.DataBind();
        }

        protected void tabelaCursos_RowCommand(object sender , GridViewCommandEventArgs e)
        {
            ID = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("Curso.aspx");
        }
    }
}