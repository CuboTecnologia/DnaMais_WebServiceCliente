using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DNA.Web
{
    public partial class OldHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    System.Web.HttpBrowserCapabilities validaBrowser = Request.Browser;
                    if (Request.UserAgent.ToUpper().Contains("CHROME") ||
                        Request.UserAgent.ToUpper().Contains("FIREFOX") ||
                        Request.UserAgent.ToUpper().Contains("SAFARI") ||
                        (validaBrowser.Browser == "IE" && validaBrowser.MajorVersion >= 9))
                    {
                        Response.Redirect("Home.aspx", false);
                        return;
                    }

                    txtLogin.Focus();

                    if (VerificaSessionAutenticacao(string.Empty, string.Empty))
                    {
                        Response.Redirect("Sistema/Home.aspx", false);
                    }
                    else
                    {
                        if (Session["UsuarioLogado"] != null)
                        { Response.Redirect("Sistema/Home.aspx", false); }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Autenticar();
            }
            catch (Exception ex)
            {
                if (Session["UsuarioLogado"] != null)
                { Response.Redirect("Sistema/Home.aspx", false); }
                else
                { Response.Redirect("Home.aspx", false); }
            }
        }

        private void Autenticar()
        {
            try
            {
                if (txtLogin.Value.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Informe o login de acesso do usuário.')</script>", false);
                    txtLogin.Focus();
                }
                else if (txtSenha.Value.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Informe a senha de acesso do usuário.')</script>", false);
                    txtSenha.Focus();
                }
                else
                {

                    if (!Acesso())
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('O nome de usuário ou a senha estão incorretos.')</script>", false);
                    }
                    else
                    {
                        Response.Redirect("Sistema/Home.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool Acesso()
        {
            try
            {
                Entidades.Usuario u = new Entidades.Usuario();
                List<Entidades.Usuario> lRetUser = new List<Entidades.Usuario>();
                Negocios.Cadastro.Usuarios n = new Negocios.Cadastro.Usuarios();

                u.LoginUsuario = txtLogin.Value.Trim().ToUpper();
                u.SenhaUsuario = txtSenha.Value.Trim().ToUpper();

                if (!VerificaSessionAutenticacao(u.LoginUsuario, u.SenhaUsuario))
                {
                    lRetUser = n.Listar(u);

                    if (lRetUser.Count > 0 && lRetUser.FirstOrDefault().FlagAtivo.Equals("S"))
                    {
                        bool temPerfil = false;

                        //verifica se o usuario tem o perfil de acesso necessario
                        for (int i = 0; i < lRetUser.FirstOrDefault().Perfil.Count; i++)
                        {
                            if (lRetUser.FirstOrDefault().Perfil[i].DescricaoPerfilAcesso.ToUpper().Trim().Equals("CLIENTE SITE") ||
                                lRetUser.FirstOrDefault().Perfil[i].DescricaoPerfilAcesso.ToUpper().Trim().Equals("ADMINISTRADOR"))
                            {
                                this.Session.Add("UsuarioLogado", lRetUser.FirstOrDefault());
                                temPerfil = true;
                            }
                        }

                        if (!temPerfil && this.Session != null)
                        {
                            this.Session.Abandon();
                            return false;
                        }
                    }
                    else
                    {
                        this.Session.Abandon();
                    }
                }

                return (lRetUser.Count > 0);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private bool VerificaSessionAutenticacao(string loginUsuario, string senhaUsuario)
        {
            try
            {
                for (int i = 0; i < Session.Count; i++)
                {
                    switch (Session.Keys[i].ToString())
                    {
                        case "UsuarioLogado":
                            {
                                if (Session["UsuarioLogado"] != null)
                                {
                                    Entidades.Usuario u = (Entidades.Usuario)Session["UsuarioLogado"];

                                    //A session existe mas não foi informado o usuario e senha que esta utilizando o sistema.
                                    if (loginUsuario.Equals("") && senhaUsuario.Equals("") && txtLogin.Value.Equals("") && txtSenha.Value.Equals(""))
                                    { return true; }

                                    Util.Cryptography cript = new Util.Cryptography(Util.EncryptionAlgorithm.TripleDes);
                                    string SenhaCript = "";
                                    SenhaCript = Convert.ToBase64String(cript.Encrypt(Encoding.ASCII.GetBytes(u.SenhaUsuario), Util.Cryptography.Key, Util.Cryptography.Vector));

                                    if (u.LoginUsuario.ToUpper().Equals(loginUsuario.ToUpper()) && u.SenhaUsuario.ToUpper().Equals(SenhaCript.ToUpper()))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        Session.Abandon();
                                        Session.Clear();

                                        return false;
                                    }
                                }
                                else
                                {
                                    Session.Abandon();
                                    Session.Clear();

                                    return false;
                                }

                                //break;
                            }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}