using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DNA.Web.Sistema
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogado"] == null)
            { Response.Redirect("../Home.aspx", false); return; }

            this.Page.Title = "DNA+ - Produtos Online";

            if (!Page.IsPostBack)
            { SetarClickBotoes(); }
        }


        protected void imgLinkBtnVeicular_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Produto/Veicular/Home.aspx", false);
        }




        protected void imgLinkBtnCadastralPF_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Produto/Cadastral/Home.aspx?FiltroProdutosHome=PF", false);
        }

        protected void linkDescProdutosPF_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto/Cadastral/Home.aspx?FiltroProdutosHome=PF", false);
        }

        protected void linkNomeProdutoPF_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto/Cadastral/Home.aspx?FiltroProdutosHome=PF", false);
        }

        protected void imgLinkBtnCadastralPJ_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Produto/Cadastral/Home.aspx?FiltroProdutosHome=PJ", false);
        }

        protected void linkDescProdutosPJ_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto/Cadastral/Home.aspx?FiltroProdutosHome=PJ", false);
        }

        protected void linkNomeProdutoPJ_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto/Cadastral/Home.aspx?FiltroProdutosHome=PJ", false);
        }

        private void SetarClickBotoes()
        {
            btnDivPrincipalCadastralPF.Attributes.Add("onclick", "window.location.replace('Produto/Cadastral/Home.aspx?FiltroProdutosHome=PF');");
            divPrincipalDescProdutoCadastralPF.Attributes.Add("onclick", "window.location.replace('Produto/Cadastral/Home.aspx?FiltroProdutosHome=PF');");
            divPrincipalNomeProdutoCadastralPF.Attributes.Add("onclick", "window.location.replace('Produto/Cadastral/Home.aspx?FiltroProdutosHome=PF');");

            btnDivPrincipalCadastralPJ.Attributes.Add("onclick", "window.location.replace('Produto/Cadastral/Home.aspx?FiltroProdutosHome=PJ');");
            divPrincipalDescProdutoCadastralPJ.Attributes.Add("onclick", "window.location.replace('Produto/Cadastral/Home.aspx?FiltroProdutosHome=PJ');");
            divPrincipalNomeProdutoCadastralPJ.Attributes.Add("onclick", "window.location.replace('Produto/Cadastral/Home.aspx?FiltroProdutosHome=PJ');");

            //btnDivPrincipalVeicular.Attributes.Add("onclick", "window.location.replace('Produto/Veicular/Home.aspx');");
            //divPrincipalDescProdutoVeicular.Attributes.Add("onclick", "window.location.replace('Produto/Veicular/Home.aspx');");
            //divPrincipalNomeProdutoVeicular.Attributes.Add("onclick", "window.location.replace('Produto/Veicular/Home.aspx');");

            if (!Request.UserAgent.ToUpper().Contains("CHROME") &&
                !Request.UserAgent.ToUpper().Contains("FIREFOX") &&
                !Request.UserAgent.ToUpper().Contains("SAFARI"))
            {

                System.Web.HttpBrowserCapabilities validaBrowser = Request.Browser;

                if (validaBrowser.Browser == "IE" && validaBrowser.MajorVersion < 9)
                {
                    btnDivPrincipalVeicular.Attributes.Add("onclick", "window.location.replace('http://www.motordata.com.br');");
                    divPrincipalDescProdutoVeicular.Attributes.Add("onclick", "window.location.replace('http://www.motordata.com.br');");
                    divPrincipalNomeProdutoVeicular.Attributes.Add("onclick", "window.location.replace('http://www.motordata.com.br');");
                }
            }
            else
            {
                btnDivPrincipalVeicular.Attributes.Add("onclick", "window.open('http://www.motordata.com.br', '_blank');");
                divPrincipalDescProdutoVeicular.Attributes.Add("onclick", "window.open('http://www.motordata.com.br', '_blank');");
                divPrincipalNomeProdutoVeicular.Attributes.Add("onclick", "window.open('http://www.motordata.com.br', '_blank');");
            }

           
            btnDivPrincipalFTP.Attributes.Add("onclick", "window.location.replace('Produto/FTP/GerenciarArquivos.aspx');");
            divPrincipalDescProdutoFTP.Attributes.Add("onclick", "window.location.replace('Produto/FTP/GerenciarArquivos.aspx');");
            divPrincipalNomeProdutoFTP.Attributes.Add("onclick", "window.location.replace('Produto/FTP/GerenciarArquivos.aspx');");
        }

        protected void linkDescFTP_Click(object sender, EventArgs e)
        {
            Response.Redirect("Produto/FTP/GerenciarArquivos.aspx", false);
        }

        protected void imgLinkBtnFTP_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Produto/FTP/GerenciarArquivos.aspx", false);
        }
    }
}