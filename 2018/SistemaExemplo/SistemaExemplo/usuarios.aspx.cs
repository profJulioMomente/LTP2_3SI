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
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["usuarioID"] = "0";
                preencher_dados();
            }
        }

        protected void gdvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                Session["usuarioID"] = e.CommandArgument;
                Response.Redirect("cadastroUsuario.aspx");
            }
            if (e.CommandName == "inativar")
            {
                nUsuario.InativarUsuario(Convert.ToInt32(e.CommandArgument));
                
                Response.Redirect("usuarios.aspx");
            }
        }

        private void preencher_dados()
        {
            DataTable dt = new DataTable();

            nUsuario.RecuperarUsuarios("", "", "", dt);

            gdvUsuarios.DataSource = dt;
            gdvUsuarios.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}