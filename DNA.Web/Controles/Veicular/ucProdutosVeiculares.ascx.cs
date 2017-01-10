using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNA.Web.Controles.Veicular
{
    public partial class ucProdutosVeiculares : System.Web.UI.UserControl
    {
        public int idUsuario { get; set; }

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
                        case "CONSULTAR BASE ESTADUAL":
                            Response.Redirect("/Paginas/Produtos/Veiculares/ConsultarBaseEstadual.aspx", false);
                            break;

                        case "CONSULTAR BASE ESTADUAL SÃO PAULO":
                            Response.Redirect("/Paginas/Produtos/Veiculares/ConsultarBaseEstadualSP.aspx", false);
                            break;

                        case "CONSULTAR BASE NACIONAL":
                            Response.Redirect("/Paginas/Produtos/Veiculares/ConsultaBIN.aspx", false);
                            break;

                        case "CONSULTAR LEILÃO INFOCAR":

                            break;

                        case "CONSULTA COMPLETA ECV":

                            break;

                        case "CONSULTAR AGREGADO SERVIDOR CHECKLOG":
                            Response.Redirect("/Paginas/Produtos/Veiculares/ConsultarAgregado.aspx", false);

                            break;

                        case "PESQUISA ESPECIAL ECV":
                            Response.Redirect("/Paginas/Produtos/Veiculares/ConsultaEspecialECV.aspx", false);

                            break;

                        case "PESQUISA ESPECIAL ECV CONCESSIONARIA":
                            Response.Redirect("/Paginas/Produtos/Veiculares/ConsultaEspecialConcessionaria.aspx", false);

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

                l = n.ListarByIdUsuario(clie);
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