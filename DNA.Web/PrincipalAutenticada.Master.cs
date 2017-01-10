using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace DNA.Web
{
    public partial class PrincipalAutenticada : System.Web.UI.MasterPage
    {
        public enum menuSelecionado
        {
            MeusProdutos,
            ExtratoConta,
            PerfilUsuario,
            PainelControle
        }
        private menuSelecionado menuAtual;

        public menuSelecionado MenuAtual
        {
            set { this.menuAtual = value; }
            get { return menuAtual; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SelecionaMenu();

            if (!Request.UserAgent.ToUpper().Contains("CHROME") &&
                !Request.UserAgent.ToUpper().Contains("FIREFOX") &&
                !Request.UserAgent.ToUpper().Contains("SAFARI"))
            {

                System.Web.HttpBrowserCapabilities validaBrowser = Request.Browser;

                if (validaBrowser.Browser == "IE" && validaBrowser.MajorVersion < 9)
                {
                    divMPPrincipal.Attributes.Add("style", "border: 1px solid #000;");
                }
            }
        }

        private void SelecionaMenu()
        {
            ((HtmlControl)this.FindControl("menuMeusProdutos")).Attributes.Add("class", "");
            ((HtmlControl)this.FindControl("menuExtratoConta")).Attributes.Add("class", "");
            ((HtmlControl)this.FindControl("menuPerfilUsuario")).Attributes.Add("class", "");
            ((HtmlControl)this.FindControl("menuPainelControle")).Attributes.Add("class", "");

            switch (menuAtual)
            {
                case menuSelecionado.MeusProdutos:
                    {
                        ((HtmlControl)this.FindControl("menuMeusProdutos")).Attributes.Add("class", "active");
                        break;
                    }

                case menuSelecionado.ExtratoConta:
                    {
                        ((HtmlControl)this.FindControl("menuExtratoConta")).Attributes.Add("class", "active");
                        break;
                    }

                case menuSelecionado.PerfilUsuario:
                    {
                        ((HtmlControl)this.FindControl("menuPerfilUsuario")).Attributes.Add("class", "active");
                        break;
                    }

                case menuSelecionado.PainelControle:
                    {
                        ((HtmlControl)this.FindControl("menuPainelControle")).Attributes.Add("class", "active");
                        break;
                    }

            }
        }
    }
}