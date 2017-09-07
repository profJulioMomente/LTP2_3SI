using LTP2_ControleAcademico.Negocio;
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
            if (!IsPostBack)
            {
                Session["Curso"] = "0";
                preencher_dados();
            }
        }

        private void preencher_dados()
        {
            rnCurso C = new rnCurso();

            gdvCursos.DataSource = C.recuperarCursos("");
            gdvCursos.DataBind();

            
        }

        protected void gdvCursos_RowCommand(object sender , GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "editar")
            {
                Session["Curso"] = e.CommandArgument;
                Response.Redirect("NovoCurso.aspx");
            }
            if (e.CommandName == "excluir")
            {
                rnCurso C = new rnCurso();
                C.ID_Curso = Convert.ToInt32(e.CommandArgument);
                C.excluir();
                
                Response.Redirect("Cursos.aspx");
            }
        }

        protected void btnBuscar_Click(object sender , EventArgs e)
        {
            rnCurso C = new rnCurso();
            string valorBusca = txtBusca.Text;
            if (!String.IsNullOrEmpty(valorBusca))
            {
                string query = "Nome_Curso LIKE '%" + valorBusca + "%'";

                gdvCursos.DataSource = null;

                
                gdvCursos.DataSource = C.recuperarCursos(query);
                gdvCursos.DataBind();
            }
            else
            {
                gdvCursos.DataSource = C.recuperarCursos("");
                gdvCursos.DataBind();
            }
        }
    }
}