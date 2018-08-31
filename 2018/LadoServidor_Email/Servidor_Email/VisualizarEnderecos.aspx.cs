using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servidor_Email
{
    public partial class VisualizarEnderecos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGridView();
        }

        private void carregarGridView()
        {
            EndercoServer es = new EndercoServer();

            DataTable dados = es.BuscarDados();

            gdvEnderecos.DataSource = dados;
            gdvEnderecos.DataBind();
        }
    }
}