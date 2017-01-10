using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNA.Web.Controles.Cadastral
{
    public partial class ucProdutosCadastrais : System.Web.UI.UserControl
    {
        public int idUsuario { get; set; }
        
        public string usarFiltroCategoria { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("/Home.aspx", false); }

                Session["idProdutoPrecoAcessoWEB"] = "";

                if (hdCodigoProduto.Value.Trim().Length > 0)
                {
                    Session.Add("idProdutoPrecoAcessoWEB", hdCodigoProduto.Value);

                    switch (hdNomeInternoProduto.Value.Trim().ToUpper())
                    {
                        case "WEB RASTREAMENTO PF PRATA":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoPFPrata.aspx", false);
                            break;

                        case "WEB RASTREAMENTO PJ PRATA":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoPJPrata.aspx", false);
                            break;

                        case "WEB RASTREAMENTO SEARCH PF":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoSearchPF.aspx", false);
                            break;

                        case "WEB RASTREAMENTO SEARCH PJ":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoSearchPJ.aspx", false);
                            break;

                        case "WEB RASTREAMENTO SEARCH TELEFONE PF":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoSearchTelefonePF.aspx", false);
                            break;

                        case "WEB RASTREAMENTO SEARCH TELEFONE PJ":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoSearchTelefonePJ.aspx", false);
                            break;

                        case "WEB RASTREAMENTO MORADORES MESMO ENDERECO":
                            Response.Redirect("/Sistema/Produto/Cadastral/ConsultaWebRastreamentoMoradoresMesmoEndereco.aspx", false);
                            break;

                        default:

                            break;
                    }
                }

                if (!Page.IsPostBack)
                {
                    if (idUsuario != null && idUsuario != 0)
                    { ListarProdutosByUsuario(idUsuario); }
                }
            }
            catch (Exception)
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("/Home.aspx", false); }
                else
                { Response.Redirect("../Home.aspx", false); }
            }
        }


        private List<Entidades.Produto> ListarProdutosByUsuario(int idUsuario)
        {
            try
            {
                List<Entidades.Produto> l = new List<Entidades.Produto>();
                Negocios.Cadastro.Produtos n = new Negocios.Cadastro.Produtos();
                Entidades.Cliente clie = new Entidades.Cliente();

                clie.Usuarios = new List<Entidades.Usuario>();
                clie.Usuarios.Add(new Entidades.Usuario() { IdUsuario = idUsuario });

                l = n.ListarByIdUsuario(clie).Where(p=> p.FlagProdutoWebService.Trim().ToUpper().Equals("N")).ToList();

                if (usarFiltroCategoria != null && usarFiltroCategoria.Equals("PF"))
                {
                    List<Entidades.Produto> novaLista = new List<Entidades.Produto>();
                    novaLista = l.Where(p => p.CategoriaProduto.Nome.Trim().ToUpper().Equals("CADASTRAL PF")).ToList();

                    l = new List<Entidades.Produto>();
                    l = novaLista;
                }
                else if(usarFiltroCategoria != null && usarFiltroCategoria.Equals("PJ"))
                {
                    List<Entidades.Produto> novaLista = new List<Entidades.Produto>();
                    novaLista = l.Where(p => p.CategoriaProduto.Nome.Trim().ToUpper().Equals("CADASTRAL PJ")).ToList();

                    l = new List<Entidades.Produto>();
                    l = novaLista;
                }

                dlProdutosVeiculares.DataSource = l;
                dlProdutosVeiculares.DataBind();

                dlProdutosVeiculares.Visible = (l.Count > 0);

                return l;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dlProdutosVeiculares_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                //divProdutosVeiculares
                System.Web.UI.HtmlControls.HtmlGenericControl btnDivPrincipal = e.Item.FindControl("btnDivPrincipal") as System.Web.UI.HtmlControls.HtmlGenericControl;
                System.Web.UI.HtmlControls.HtmlGenericControl divPrincipalDescProduto = e.Item.FindControl("divPrincipalDescProduto") as System.Web.UI.HtmlControls.HtmlGenericControl;
                System.Web.UI.HtmlControls.HtmlGenericControl divPrincipalNomeProduto = e.Item.FindControl("divPrincipalNomeProduto") as System.Web.UI.HtmlControls.HtmlGenericControl;

                System.Web.UI.HtmlControls.HtmlInputHidden hdCodigoProdutoTEMP = e.Item.FindControl("hdCodigoProdutoTEMP") as System.Web.UI.HtmlControls.HtmlInputHidden;
                System.Web.UI.HtmlControls.HtmlInputHidden hdNomeInternoProdutoTEMP = e.Item.FindControl("hdNomeInternoProdutoTEMP") as System.Web.UI.HtmlControls.HtmlInputHidden;

                //Atribuindo ao Hidden o ID do produto preço clicado e o nome interno do mesmo
                btnDivPrincipal.Attributes.Add("onclick", "document.getElementById('" + hdCodigoProduto.ClientID + "').value = document.getElementById('" + hdCodigoProdutoTEMP.ClientID + "').value; document.getElementById('" + hdNomeInternoProduto.ClientID + "').value = document.getElementById('" + hdNomeInternoProdutoTEMP.ClientID + "').value; document.forms[0].submit();");
                divPrincipalDescProduto.Attributes.Add("onclick", "document.getElementById('" + hdCodigoProduto.ClientID + "').value = document.getElementById('" + hdCodigoProdutoTEMP.ClientID + "').value; document.getElementById('" + hdNomeInternoProduto.ClientID + "').value = document.getElementById('" + hdNomeInternoProdutoTEMP.ClientID + "').value;document.forms[0].submit();");
                divPrincipalNomeProduto.Attributes.Add("onclick", "document.getElementById('" + hdCodigoProduto.ClientID + "').value = document.getElementById('" + hdCodigoProdutoTEMP.ClientID + "').value; document.getElementById('" + hdNomeInternoProduto.ClientID + "').value = document.getElementById('" + hdNomeInternoProdutoTEMP.ClientID + "').value; document.forms[0].submit();");

            }
            catch (Exception)
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("/Home.aspx", false); }
                else
                { Response.Redirect("../Home.aspx", false); }
            }
        }
    }
}