using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DNA.Web.Controles
{
    public partial class ucLoginUsuario : System.Web.UI.UserControl
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (VerificaSessionAutenticacao(string.Empty, string.Empty))
                    {
                        divLogado.Style.Add("display", "block");
                        divLogar.Style.Add("display", "none");

                        lblNumeroIPCliente.Text = "Seu IP é: <b>" + Request.UserHostAddress.ToString() + "</b>";
                        lblDataAtual.Text = "Hoje é " + DataBR.ToLongDateString().PadLeft(2, '0');
                        lblNomeUsuarioLogado.Text = "Bem vindo(a) <b>" + ((Entidades.Usuario)Session["UsuarioLogado"]).NomeUsuario + "</b>";
                    }
                    else
                    {
                        divLogado.Style.Add("display", "none");
                        divLogar.Style.Add("display", "block");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Autenticar()
        {
            try
            {
                if (txtLoginUsuario.Text.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Informe o login de acesso do usuário.')</script>", false);
                    txtLoginUsuario.Focus();
                }
                else if (txtSenhaUsuario.Text.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Informe a senha de acesso do usuário.')</script>", false);
                    txtSenhaUsuario.Focus();
                }
                else
                {

                    if (!Acesso())
                    {
                        divLogado.Style.Add("display", "none");
                        divLogar.Style.Add("display", "block");

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('O nome de usuário ou a senha estão incorretos.')</script>", false);
                    }
                    else
                    {
                        divLogado.Style.Add("display", "block");
                        divLogar.Style.Add("display", "none");

                        lblNumeroIPCliente.Text = "Seu IP é: " + Request.UserHostAddress.ToString();
                        lblDataAtual.Text = "Hoje é " + DataBR.ToLongDateString();
                        lblNomeUsuarioLogado.Text = "Bem vindo <b>" + ((Entidades.Usuario)Session["UsuarioLogado"]).NomeUsuario + "</b>";

                        Response.Redirect("Paginas/Home.aspx", false);
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

                u.LoginUsuario = txtLoginUsuario.Text.Trim().ToUpper();
                u.SenhaUsuario = txtSenhaUsuario.Text.Trim().ToUpper();

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
                        //lblLoginUsuario.Text = "";
                        //lblNumeroIPCliente.Text = "";
                        //lblDataAtual.Text = "";
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
                                    if (loginUsuario.Equals("") && senhaUsuario.Equals("") && txtLoginUsuario.Text.Equals("") && txtSenhaUsuario.Text.Equals(""))
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
                                        lblLoginUsuario.Text = "";
                                        lblNumeroIPCliente.Text = "";
                                        lblDataAtual.Text = "";

                                        return false;
                                    }
                                }
                                else
                                {
                                    Session.Abandon();
                                    Session.Clear();
                                    lblLoginUsuario.Text = "";
                                    lblNumeroIPCliente.Text = "";
                                    lblDataAtual.Text = "";

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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Autenticar();
            }
            catch (Exception ex)
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("/Home.aspx", false); }
                else
                { Response.Redirect("../Home.aspx", false); }
            }
        }
    }
}