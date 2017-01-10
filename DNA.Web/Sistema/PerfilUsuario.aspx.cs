using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DNA.Web.Sistema
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        string nomeModuloLog = "PerfilUsuario";
        string diretorioLog = "../../../";
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];

                SelecionaMenuMasterPage();
                PopularCampos();
                SetJavaScript();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", nomeModuloLog, HttpContext.Current.Server.MapPath(diretorioLog));
                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void PostBackBind_DataBinding(object sender, EventArgs e)
        {
            try
            {
                Button lb = (Button)sender;
                ScriptManager sm = (ScriptManager)Page.Master.FindControl("ScriptManager1");
                sm.RegisterPostBackControl(lb);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void SelecionaMenuMasterPage()
        {
            this.Page.Title = "DNA+ - Perfil do Usuário";
            this.Master.MenuAtual = PrincipalAutenticada.menuSelecionado.PerfilUsuario;
        }

        private void PopularCampos()
        {
            try
            {
                #region Popula Dados do Cliente

                if (!usuarioLogado.Cliente.NumeroDocCPFCNPJ.Trim().Equals(""))
                { lblCNPJ.Text = Util.Format.FormatString(usuarioLogado.Cliente.NumeroDocCPFCNPJ, Util.Format.TypeString.CNPJ); }

                lblRazaoSocial.Text = usuarioLogado.Cliente.NomeRazaoSocial.ToUpper();
                lblNomeFantasia.Text = usuarioLogado.Cliente.NomeFantasia.ToUpper();
                lblLogradouro.Text = usuarioLogado.Cliente.EnderecoLogradouro.ToUpper();
                lblEnderecoNumero.Text = usuarioLogado.Cliente.EnderecoNumero.ToUpper();
                lblEnderecoComplemento.Text = usuarioLogado.Cliente.EnderecoComplemento.ToUpper();
                lblBairro.Text = usuarioLogado.Cliente.EnderecoBairro.ToUpper();
                lblCidade.Text = usuarioLogado.Cliente.EnderecoMunicipio.ToUpper();
                lblUF.Text = usuarioLogado.Cliente.EnderecoUF.ToUpper();
                lblCEP.Text = usuarioLogado.Cliente.EnderecoCEP.ToUpper();
                lblEmail1.Text = usuarioLogado.Cliente.Email1.ToUpper();
                lblEmail2.Text = usuarioLogado.Cliente.Email2.ToUpper();

                if (!usuarioLogado.Cliente.DDDTelComercial.Trim().Equals(""))
                { lblTelefoneCom.Text = "(" + usuarioLogado.Cliente.DDDTelComercial.Trim() + ") "; }
                else
                { lblTelefoneCom.Text = "(00) "; }

                if (!usuarioLogado.Cliente.NumeroTelComercial.Trim().Equals(""))
                { lblTelefoneCom.Text += usuarioLogado.Cliente.NumeroTelComercial.Trim(); }
                else
                { lblTelefoneCom.Text += "0000-0000"; }

                if (!usuarioLogado.Cliente.NumeroTelComercialRamal.Trim().Equals(""))
                { lblTelefoneCom.Text += " Ramal: " + usuarioLogado.Cliente.NumeroTelComercialRamal.Trim(); }


                if (!usuarioLogado.Cliente.DDDTelResidencial.Trim().Equals(""))
                { lblTelefoneRes.Text = "(" + usuarioLogado.Cliente.DDDTelResidencial.Trim() + ") "; }
                else
                { lblTelefoneRes.Text = "(00) "; }

                if (!usuarioLogado.Cliente.NumeroTelResidencial.Trim().Equals(""))
                { lblTelefoneRes.Text += usuarioLogado.Cliente.NumeroTelResidencial.Trim(); }
                else
                { lblTelefoneRes.Text += "0000-0000"; }


                if (!usuarioLogado.Cliente.DataNascimento.Trim().Equals(""))
                { lblCelular.Text = "(" + usuarioLogado.Cliente.DataNascimento.Trim() + ") "; }
                else
                { lblCelular.Text = "(00) "; }

                if (!usuarioLogado.Cliente.NumeroTelComercial.Trim().Equals(""))
                { lblCelular.Text += usuarioLogado.Cliente.NumeroTelComercial.Trim(); }
                else
                { lblCelular.Text += "0000-0000"; }

                if (usuarioLogado.Cliente.DataInclusaoCliente != null)
                { lblDataCadastro.Text = ((DateTime)usuarioLogado.Cliente.DataInclusaoCliente).ToLongDateString().ToUpper(); }

                txtObservacao.Text = usuarioLogado.Cliente.Observacao.Trim().ToUpper();
                
                #endregion

                #region Popula Dados do Usuario

                lblNomeUsuario.Text = usuarioLogado.NomeUsuario.ToUpper();
                lblLoginUsuario.Text = usuarioLogado.LoginUsuario.ToUpper();
                lblEmail1.Text = usuarioLogado.Email1.ToUpper();
                lblEmail2.Text = usuarioLogado.Email2.ToUpper();

                if (usuarioLogado.DataInclusao != null)
                { lblDataCadastroUsuario.Text = ((DateTime)usuarioLogado.DataInclusao).ToLongDateString().ToUpper(); }

                if (usuarioLogado.DataAlteracao != null)
                { lblUltimaAlteracaoUsuario.Text = ((DateTime)usuarioLogado.DataAlteracao).ToLongDateString().ToUpper(); }

                foreach (var item in usuarioLogado.Produtos)
                {
                    if (txtProdutosUsuario.Text.Length == 0)
                    { txtProdutosUsuario.Text = "- " + item.NomeProduto.ToUpper(); }
                    else
                    {
                        txtProdutosUsuario.Text += Environment.NewLine;
                        txtProdutosUsuario.Text += "- " + item.NomeProduto.ToUpper();
                    }
                }

                txtObservacao.Text = usuarioLogado.Observacao.ToUpper();


                #endregion
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "PopularCampos", nomeModuloLog, HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void btnSalvarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSenhaAtual.Text.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('Informe a senha atual');</script>", false);
                    return;
                }
                else if (txtNovaSenha.Text.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('Informe a nova senha');</script>", false);
                    return;
                }
                else if (txtConfirmaNovaSenha.Text.Trim().Length == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('Informe a confirmação da nova senha');</script>", false);
                    return;
                }
                else if (!txtConfirmaNovaSenha.Text.ToUpper().Trim().Equals(txtNovaSenha.Text.Trim().ToUpper()))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('A CONFIRMAÇÃO e a NOVA SENHA devem ser iguais');</script>", false);
                    return;
                }


                Util.Cryptography cript = new Util.Cryptography(Util.EncryptionAlgorithm.TripleDes);
                string SenhaCript = "";
                SenhaCript = Convert.ToBase64String(cript.Encrypt(Encoding.ASCII.GetBytes(txtSenhaAtual.Text.ToUpper()), Util.Cryptography.Key, Util.Cryptography.Vector));

                if (!usuarioLogado.SenhaUsuario.Equals(SenhaCript))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('A senha atual esta incorreta.');</script>", false);
                    return;
                }

                Negocios.Cadastro.Usuarios negUsu = new Negocios.Cadastro.Usuarios();
                Entidades.Usuario userAlteracao = new Entidades.Usuario();

                userAlteracao.SenhaUsuario = Convert.ToBase64String(cript.Encrypt(Encoding.ASCII.GetBytes(txtNovaSenha.Text.ToUpper()), Util.Cryptography.Key, Util.Cryptography.Vector)); ;
                userAlteracao.IdUsuario = usuarioLogado.IdUsuario;

                bool retAlteracao = negUsu.AlterarSenha(usuarioLogado.IdUsuario, userAlteracao);

                if (retAlteracao)
                {
                    usuarioLogado.SenhaUsuario = SenhaCript;
                    Session["UsuarioLogado"] = usuarioLogado;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('Senha alterada com sucesso.');</script>", false);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msgAlerta", "<script>alert('A senha não foi alterada. Entrem em contato com o administrador do sistema.');</script>", false);
                }
                
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnSalvarSenha_Click", nomeModuloLog, HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        private void SetJavaScript()
        {
            string _script = "<script type=\"text/javascript\" language=\"javascript\">";
            _script += " window.onload = function(){";
            _script += "document.getElementById('" + txtObservacao.ClientID + "').readOnly = true;";
            _script += "document.getElementById('" + txtProdutosUsuario.ClientID + "').readOnly = true;";
            _script += "document.getElementById('" + txtObservacaoUsuario.ClientID + "').readOnly = true;";
            _script += "document.getElementById('" + btnCancelarSenha.ClientID + "').click = true;";
            _script += "}</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CamposSomenteLeitura", _script);
        }

    }
}