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
    public partial class NovaDisciplina : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Disciplina"] != null && !String.IsNullOrEmpty(Session["Disciplina"].ToString()))
                {

                }
                carregarCursos();
                if (Session["Disciplina"].ToString() != "0")
                {
                    preencherFormulario();
                }
            }
        }

        private void carregarCursos()
        {
            rnCurso C = new rnCurso();
            DataTable d = C.recuperarCursos("");
            ddlCurso.DataTextField = "Nome_Curso";
            ddlCurso.DataValueField = "ID_Curso";
            ddlCurso.DataSource = d;
            ddlCurso.DataBind();


        }

        protected void btnSalvar_Click(object sender , EventArgs e)
        {
            rnDisciplina D = new rnDisciplina();

            D.Codigo_Disciplina = txtCodido.Text;
            D.Nome_Disciplina = txtDisciplina.Text;
            D.Ementa_Disciplina = txtEmenta.Text;
            D.Semestre_Disciplina = Convert.ToInt32(txtSemestre.Text);
            D.CargaHoraria_Disciplina = Convert.ToInt32(txtCargaHoraria.Text);
            D.Curso.ID_Curso = Convert.ToInt32(ddlCurso.SelectedValue);

            D.Curso.recuperarRegistro();

            if (Session["Disciplina"].ToString() == "0")
            {
                D.inserir();
            }
            else
            {
                D.ID_Disciplina = Convert.ToInt32(Session["Disciplina"]);
                D.alterar();
            }

            ////lblSucesso.Text = "Curso Inserido com sucesso!";
            Response.Redirect("Disciplinas.aspx");

        }

        public void preencherFormulario()
        {
            rnDisciplina D = new rnDisciplina();
            //D.ID_Disciplina = Convert.ToInt32(Session["Disciplina"]);

            D.ID_Disciplina = Convert.ToInt32(Session["Disciplina"]);

            D.recuperarRegistro();

            txtCodido.Text = D.Codigo_Disciplina;
            txtDisciplina.Text = D.Nome_Disciplina;
            txtEmenta.Text = D.Ementa_Disciplina;
            txtSemestre.Text = D.Semestre_Disciplina.ToString();
            txtCargaHoraria.Text = D.CargaHoraria_Disciplina.ToString();
            ddlCurso.SelectedValue = D.Curso.ID_Curso.ToString();
        }
    }
}
