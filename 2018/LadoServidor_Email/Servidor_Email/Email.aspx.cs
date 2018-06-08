using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servidor_Email
{
    public partial class Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender , EventArgs e)
        {
            if (!Page.IsPostBack)
                lblNome.InnerText = lblNome.InnerText + "Rótulo";
        }

        protected void btnEnviar_ServerClick(object sender , EventArgs e)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add("juliocesar.momente@gmail.com");
                mail.From = new MailAddress("juliocesar.momente@gmail.com");
                mail.Subject = "[Site] Contato";
                mail.Body = txtNome.Value + " <" + txtEmail.Value + "> enviou :\n"
                    + txtMensagem.Value;

                SmtpClient client = new SmtpClient("smtp.gmail.com" , 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials =
                    new System.Net.NetworkCredential("juliocesar.momente@gmail.com" , "suasenha");

                client.Send(mail);
            } catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }

        private bool ValidaEmail()
        {
            return true;
        }
    }
}