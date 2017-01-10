using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNA.Web.Sistema.Produto.Cadastral
{
    public partial class Home : System.Web.UI.Page
    {
        string UsarFiltroProdutosCategoria = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                this.Page.Title = "DNA+ - Produtos Cadastrais";

                if (VerificaFiltroCategoria())
                { ucProdutosCadastrais1.usarFiltroCategoria = UsarFiltroProdutosCategoria; }

                ucProdutosCadastrais1.idUsuario = ((Entidades.Usuario)Session["UsuarioLogado"]).IdUsuario;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Sessão expirada.');window.location='../../Home.aspx';</script>", false);
            }
        }

        private bool VerificaFiltroCategoria()
        {
            try
            {
                bool FiltroProdutosCategoriaEncontrado = false;

                for (int i = 0; i < Request.QueryString.Count; i++)
                {
                    switch (Request.QueryString.Keys[i].ToString().ToUpper())
                    {
                        case "FILTROPRODUTOSHOME":
                            {
                                UsarFiltroProdutosCategoria = Request.QueryString["FiltroProdutosHome"].ToString();
                                FiltroProdutosCategoriaEncontrado = true;

                                break;
                            }
                    }
                }

                return FiltroProdutosCategoriaEncontrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}