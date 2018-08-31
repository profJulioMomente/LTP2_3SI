using LTP2_ControleAcademico.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LTP2_ControleAcademico
{
    public partial class Disciplinas : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Disciplina"] = "0";
                preencher_dados();
            }
        }

        private void preencher_dados()
        {
            rnDisciplina D = new rnDisciplina();

            DataTable dt = new DataTable();
            dt = D.recuperarDisciplinas("");

            List<rnDisciplina> LD = new List<rnDisciplina>();

            foreach(DataRow dr in dt.Rows)
            {
                rnDisciplina nd = new rnDisciplina();
                nd.ID_Disciplina = Convert.ToInt32(dr["ID_Disciplina"].ToString());
                nd.Codigo_Disciplina = dr["Codigo_Disciplina"].ToString();
                nd.Nome_Disciplina = dr["Nome_Disciplina"].ToString();
                nd.Ementa_Disciplina = dr["Ementa_Disciplina"].ToString();
                nd.Semestre_Disciplina = Convert.ToInt32(dr["Semestre_Disciplina"].ToString());
                nd.CargaHoraria_Disciplina = Convert.ToInt32(dr["CargaHoraria_Disciplina"].ToString());
                nd.Curso.ID_Curso = Convert.ToInt32(dr["ID_Curso"].ToString());

                nd.Curso.recuperarRegistro();

                LD.Add(nd);
            }


            gdvDisciplinas.DataSource = LD;
            gdvDisciplinas.DataBind();
        }

        protected void gdvDisciplinas_RowCommand(object sender , GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                Session["pessoa"] = e.CommandArgument;
                Response.Redirect("NovaDisciplina.aspx");
            }
            if (e.CommandName == "excluir")
            {
                rnDisciplina D = new rnDisciplina();
                D.ID_Disciplina = Convert.ToInt32(e.CommandArgument);
                D.excluir();

                Response.Redirect("Disciplinas.aspx");
            }
        }

        protected void btnBuscar_Click(object sender , EventArgs e)
        {
            rnDisciplina D = new rnDisciplina();
            string valorBusca = txtBusca.Text;
            if (!String.IsNullOrEmpty(valorBusca))
            {
                string query = "Nome_Disciplina LIKE '%" + valorBusca + "%'";

                gdvDisciplinas.DataSource = null;


                gdvDisciplinas.DataSource = D.recuperarDisciplinas(query);
                gdvDisciplinas.DataBind();
            }
            else
            {
                gdvDisciplinas.DataSource = D.recuperarDisciplinas("");
                gdvDisciplinas.DataBind();
            }
        }

    }
}