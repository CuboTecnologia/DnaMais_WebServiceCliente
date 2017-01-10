using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections;
using System.Web.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


namespace DNA.Util
{
    public class EnviarEmail
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public void _Envia(Entidades.ContatoEmail contato)
        {
            try
            {
                if (contato.NomeDestinatario.Length == 0)
                { throw new Exception("Informe seu nome."); }

                if (contato.Mensagem.Length == 0)
                { throw new Exception("Digite a mensagem que deseja nos enviar."); }

                if (contato.EmailDestinatario.Length == 0)
                { throw new Exception("Informe seu endereço de e-mail."); }

                NameValueCollection appSettings = WebConfigurationManager.AppSettings;

                int portaSmtp = int.Parse(appSettings.Get("SMTP_Port").ToString());
                string enderecoServidorSMTP = appSettings.Get("SMTP_Address").ToString();
                string emailRemetente = appSettings.Get("SMTP_User").ToString();
                string emailDestinatario = appSettings.Get("Email_Contato_MotorData").ToString();
                string senhaEmail = appSettings.Get("SMTP_Senha").ToString();

                SmtpClient smtpClient = new SmtpClient(enderecoServidorSMTP, portaSmtp);
                smtpClient.EnableSsl = true;
                smtpClient.Host = enderecoServidorSMTP;
                smtpClient.Credentials = new NetworkCredential(emailRemetente, senhaEmail);
                smtpClient.Port = portaSmtp;

                MailAddress mailDestinatario = new MailAddress(emailDestinatario, "Motor Data");
                MailAddress mailRemetente = new MailAddress(emailDestinatario, "Motor Data");

                MailMessage oEmail = new MailMessage();

                contato.Assunto = "[Contato pelo Site]";

                oEmail.From = mailDestinatario;
                oEmail.To.Add(emailDestinatario);
                oEmail.Subject = contato.Assunto;

                oEmail.IsBodyHtml = false;
                oEmail.Body = MontaMensagem(contato);
                oEmail.SubjectEncoding = Encoding.GetEncoding("iso-8859-1");
                oEmail.BodyEncoding = Encoding.GetEncoding("iso-8859-1");

                NetworkCredential credenciais = new NetworkCredential(emailRemetente, senhaEmail);
                smtpClient.Credentials = credenciais;

                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                smtpClient.Send(oEmail);

            }
            catch (Exception ex)
            { throw ex; }
        }

        private string MontaMensagem(Entidades.ContatoEmail contato)
        {
            try
            {
                string strMensagem = "";

                strMensagem = "\n- Nome: " + contato.NomeDestinatario + "\n\n";
                strMensagem += "- E-Mail: " + contato.EmailDestinatario + "\n\n";
                strMensagem += "- Site: " + contato.SiteDestinatario + "\n\n";
                strMensagem += "- Data e Hora do Contato: " + DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm") + "\n\n";
                strMensagem += "- Mensagem: ";
                strMensagem += contato.Mensagem;

                return strMensagem;
            }
            catch (Exception ex)
            { throw ex; }

        }
    }
}
