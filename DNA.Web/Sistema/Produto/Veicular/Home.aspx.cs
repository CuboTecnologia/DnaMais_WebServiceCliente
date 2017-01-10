using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNA.Web.Sistema.Produto.Veicular
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SelecionaMenuMasterPage();
                ucProdutosVeiculares1.idUsuario = ((Entidades.Usuario)Session["UsuarioLogado"]).IdUsuario;
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Sessão expirada.');window.location='../../Home.aspx';</script>", false);
            }
        }

        private void SelecionaMenuMasterPage()
        {
            this.Page.Title = "DNA+ - Produtos Veiculares";
        }
    }
}