using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

namespace DNA.Web.Sistema.Produto.Cadastral
{
    public partial class ConsultaWebRastreamentoSearchPJ : System.Web.UI.Page
    {
        string diretorioLog = "../../../";

        string codigoItemProduto = string.Empty;
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        protected void Page_Load(object sender, EventArgs e)
        {
            //Remover
            //Entidades.Usuario usu = new Entidades.Usuario() { IdUsuario = 1 };
            //Session["UsuarioLogado"] = usu;
            //Session["codigoItemProdutoAcessoWEB"] = 3;

            try
            {
                this.Form.Attributes.Add("autocomplete", "off");

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];
                codigoItemProduto = Session["codigoItemProdutoAcessoWEB"].ToString();

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-Search PJ";

                if (!Page.IsPostBack)
                {
                    ddlCidade.Enabled = false;
                    txtNome.Focus();
                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    //codigoItemProduto = Session["codigoItemProdutoAcessoWEB"].ToString();
                }

                this.Form.DefaultButton = btnPesquisar.UniqueID;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text.Trim().Length < 3)
                {
                    string msg = string.Empty;
                    msg = "ESTE NOME É MUITO CURTO PARA EFETUAR A PESQUISA.";
                    txtNome.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (ddlUF.SelectedIndex == 0)
                {
                    string msg = string.Empty;
                    msg = "SELECIONE O ESTADO (UF).";
                    txtNome.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (ddlCidade.SelectedIndex == 0)
                {
                    string msg = string.Empty;
                    msg = "SELECIONE A CIDADE.";
                    txtNome.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else
                {
                    Consultar();
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));

                //Response.Redirect("../../Home.aspx", false);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('" + ex.Message +"')</script>", false);
            }
        }

        protected void ddlUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUF.SelectedItem.Value == "00")
                {
                    ddlCidade.Items.Clear();
                    ddlCidade.Enabled = false;
                    ddlCidade.DataSource = null;
                    ddlCidade.Items.Add(new ListItem() { Text = "SELECIONE...", Value = "00" });
                    ddlCidade.DataBind();
                }
                else
                {
                    Negocios.Cadastral.WEB.Listas n = new Negocios.Cadastral.WEB.Listas();
                    List<Entidades.Cadastral.Cidade> listCidades = new List<Entidades.Cadastral.Cidade>();

                    listCidades = n.ListarCidadesPorIdUF(int.Parse(ddlUF.SelectedItem.Value), "", 0, "");

                    if (listCidades.Count > 0)
                    {
                        ddlCidade.Enabled = true;
                        ddlCidade.Items.Clear();
                        ddlCidade.Items.Add(new ListItem("SELECIONE...", "00"));

                        if (ddlUF.SelectedItem.Text.Equals("RJ - RIO DE JANEIRO"))
                        { ddlCidade.Items.Add(new ListItem("RIO DE JANEIRO", "RIO DE JANEIRO")); }
                        else if (ddlUF.SelectedItem.Text.Equals("SP - SÃO PAULO"))
                        { ddlCidade.Items.Add(new ListItem("SAO PAULO", "SAO PAULO")); }
                        else if (ddlUF.SelectedItem.Text.Equals("AC - ACRE"))
                        { ddlCidade.Items.Add(new ListItem("RIO BRANCO", "RIO BRANCO")); }
                        else if (ddlUF.SelectedItem.Text.Equals("AL - ALAGOAS"))
                        { ddlCidade.Items.Add(new ListItem("MACEIO", "MACEIO")); }
                        else if (ddlUF.SelectedItem.Text.Equals("AP - AMAPÁ"))
                        { ddlCidade.Items.Add(new ListItem("MACAPA", "MACAPA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("AM - AMAZONAS"))
                        { ddlCidade.Items.Add(new ListItem("MANAUS", "MANAUS")); }
                        else if (ddlUF.SelectedItem.Text.Equals("BA - BAHIA"))
                        { ddlCidade.Items.Add(new ListItem("SALVADOR", "SALVADOR")); }
                        else if (ddlUF.SelectedItem.Text.Equals("CE - CEARÁ"))
                        { ddlCidade.Items.Add(new ListItem("FORTALEZA", "FORTALEZA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("DF - DISTRITO FEDERAL"))
                        { ddlCidade.Items.Add(new ListItem("BRASILIA", "BRASILIA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("ES - ESPÍRITO SANTO"))
                        { ddlCidade.Items.Add(new ListItem("VITORIA", "VITORIA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("GO - GOIÁS"))
                        { ddlCidade.Items.Add(new ListItem("GOIANIA", "GOIANIA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("MA - MARANHÃO"))
                        { ddlCidade.Items.Add(new ListItem("SAO LUIS", "SAO LUIS")); }
                        else if (ddlUF.SelectedItem.Text.Equals("MT - MATO GROSSO"))
                        { ddlCidade.Items.Add(new ListItem("CUIABA", "CUIABA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("MS - MATO GROSSO DO SUL"))
                        { ddlCidade.Items.Add(new ListItem("CAMPO GRANDE", "CAMPO GRANDE")); }
                        else if (ddlUF.SelectedItem.Text.Equals("MG - MINAS GERAIS"))
                        { ddlCidade.Items.Add(new ListItem("BELO HORIZONTE", "BELO HORIZONTE")); }
                        else if (ddlUF.SelectedItem.Text.Equals("PA - PARÁ"))
                        { ddlCidade.Items.Add(new ListItem("BELEM", "BELEM")); }
                        else if (ddlUF.SelectedItem.Text.Equals("PB - PARAÍBA"))
                        { ddlCidade.Items.Add(new ListItem("JOAO PESSOA", "JOAO PESSOA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("PR - PARANÁ"))
                        { ddlCidade.Items.Add(new ListItem("CURITIBA", "CURITIBA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("PE - PERNAMBUCO"))
                        { ddlCidade.Items.Add(new ListItem("RECIFE", "RECIFE")); }
                        else if (ddlUF.SelectedItem.Text.Equals("PI - PIAUÍ"))
                        { ddlCidade.Items.Add(new ListItem("TEREZINHA", "TEREZINHA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("RN - RIO GRANDE DO NORTE"))
                        { ddlCidade.Items.Add(new ListItem("NATAL", "NATAL")); }
                        else if (ddlUF.SelectedItem.Text.Equals("RS - RIO GRANDE DO SUL"))
                        { ddlCidade.Items.Add(new ListItem("PORTO ALEGRE", "PORTO ALEGRE")); }
                        else if (ddlUF.SelectedItem.Text.Equals("RO - RONDÔNIA"))
                        { ddlCidade.Items.Add(new ListItem("PORTO VELHO", "PORTO VELHO")); }
                        else if (ddlUF.SelectedItem.Text.Equals("RR - RORAIMA"))
                        { ddlCidade.Items.Add(new ListItem("BOA VISTA", "BOA VISTA")); }
                        else if (ddlUF.SelectedItem.Text.Equals("SC - SANTA CATARINA"))
                        { ddlCidade.Items.Add(new ListItem("FLORIANOPOLIS", "FLORIANOPOLIS")); }
                        else if (ddlUF.SelectedItem.Text.Equals("SE - SERGIPE"))
                        { ddlCidade.Items.Add(new ListItem("ARACAJU", "ARACAJU")); }
                        else if (ddlUF.SelectedItem.Text.Equals("TO - TOCANTINS"))
                        { ddlCidade.Items.Add(new ListItem("PALMAS", "PALMAS")); }

                        ddlCidade.Items.Add(new ListItem("--------", "00"));

                        foreach (Entidades.Cadastral.Cidade u in listCidades)
                        {
                            ddlCidade.Items.Add(new ListItem(u.Nome.ToUpper(), u.Nome.ToUpper()));
                        }

                        ddlCidade.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "ddlUF_SelectedIndexChanged", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void gridResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[3].Text).Trim().Equals(""))
                    {
                        string CodigoProdutoPrecoPJPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PJ PRATA")).FirstOrDefault().CodigoItemProduto; ;

                        string numeroCNPJFormatado = "";
                        string numeroCNPJ = e.Row.Cells[3].Text;
                        numeroCNPJ = numeroCNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                        numeroCNPJ = numeroCNPJ.PadLeft(14, '0');

                        numeroCNPJFormatado = Util.Format.FormatString(numeroCNPJ, Util.Format.TypeString.CNPJ);

                        ((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).Text = numeroCNPJFormatado;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + CodigoProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;
                        //((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).Attributes.Add("onclick", "return confirm('Essa operação irá gerar uma nova fatura. Deseja continuar?');");

                        string RazaoSocial = Server.HtmlDecode(e.Row.Cells[4].Text);
                        if (RazaoSocial.Trim().Length > 65)
                        {
                            RazaoSocial = RazaoSocial.Substring(0, 65) + "...";
                        }
                        ((HyperLink)e.Row.Cells[1].FindControl("linkRazaoSocial")).Text = RazaoSocial.Trim().Equals("") ? "-" : RazaoSocial;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkRazaoSocial")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + CodigoProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;

                        string NomeFantasia = Server.HtmlDecode(e.Row.Cells[5].Text);
                        if(NomeFantasia.Trim().Length > 40)
                        {
                            NomeFantasia = NomeFantasia.Substring(0, 40) + "...";
                        }
                        ((HyperLink)e.Row.Cells[2].FindControl("linkNomeFantasia")).Text = NomeFantasia.Trim().Equals("") ? "-" : NomeFantasia; 
                        ((HyperLink)e.Row.Cells[2].FindControl("linkNomeFantasia")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + CodigoProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        private void LimparCampos()
        {
            this.lblNumeroConsulta.Text = "";
            this.lblDataConsulta.Text = "";
            
        }

        private void Consultar()
        {
            try
            {
                string HTMLRetornado = string.Empty;

                lblMensagemRetorno.Text = "";
                lblMensagemRetorno.Visible = false;
                divEspacoBranco.Visible = false;
                divResultado.Visible = false;
                divImprimirMensagemErro.Attributes.Add("style", "display:none;");

                Negocios.Cadastral.WEB.RastreamentoSearchPJ n = new Negocios.Cadastral.WEB.RastreamentoSearchPJ();
                List<Entidades.Cadastral.ResponseSearchPJ> listRet = new List<Entidades.Cadastral.ResponseSearchPJ>();
                Entidades.Cadastral.FiltroPesquisaSearchPJ filtro = new Entidades.Cadastral.FiltroPesquisaSearchPJ();

                filtro.Nome = txtNome.Text.ToUpper();
                filtro.UF = ddlUF.SelectedItem.Text.Split(new Char[] { '-' })[0].ToString().Trim(); ;
                filtro.Cidade = Util.Format.RemoverAcentos(ddlCidade.SelectedItem.Text);

                listRet = n.PesquisaSearchPJ(filtro);

                if (listRet != null)
                {
                    divResultado.Visible = true;

                    if (listRet.Count > 0)
                    {
                        gridResult.DataSource = listRet;
                        gridResult.DataBind();

                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 3);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 4);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 5);
                    }
                    else
                    {
                        gridResult.DataSource = null;
                        gridResult.EmptyDataText = "NENHUM REGISTRO ENCONTRADO.";
                        gridResult.DataBind();
                    }


                    //Transformando o Retorno em XML para gravar no banco
                    var xns = new XmlSerializerNamespaces();
                    xns.Add(string.Empty, string.Empty);
                    var xs = new XmlSerializer(listRet.GetType());
                    var xml = new StringWriter();
                    xs.Serialize(xml, listRet, xns);

                    HTMLRetornado = xml.ToString();

                    string parametrosPesquisado = filtro.Nome + " | " + filtro.UF + " | " + filtro.Cidade;

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH PJ";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", codigoItemProduto, "", parametrosPesquisado, "NOME | UF | CIDADE");
                    SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                }
                else
                {
                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = "";

                    lblMensagemRetorno.Text = "NENHUM REGISTRO ENCONTRADO.<br/><br/>";

                    string mensagemExibir = "<span id='lblTexto30DiasTexto1' class='texto' style='display:inline-block;font-weight:normal'>";
                    //mensagemExibir += ddlFiltro.Value.Trim().ToUpper() + ": <b>" + txtParametroInformado.Text + "</b>";
                    mensagemExibir += "&nbsp;</span><br/><br/>";

                    lblMensagemRetorno.Text += mensagemExibir;
                    //divImprimirMensagemErro.Attributes.Add("style", "display:block;");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    LimparCampos();

                    string parametrosPesquisado = filtro.Nome + " | " + filtro.UF + " | " + filtro.Cidade;

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH PJ";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", codigoItemProduto, "", parametrosPesquisado, "NOME | UF | CIDADE");
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "CNENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        #region MÉTODOS PARA CONTROLE DAS CONSULTAS

        private Entidades.HistoricoPesquisa SalvarHistoricoPesquisa(string pesquisaSucesso, string codigoItemProduto, string Observacao, string parametroUsadoPesquisa, string tipoParametroUsadoPesquisa)
        {
            try
            {
                Entidades.HistoricoPesquisa hist = new Entidades.HistoricoPesquisa();
                Negocios.HistoricoPesquisa n = new Negocios.HistoricoPesquisa();

                hist.CodigoItemProduto = codigoItemProduto;
                hist.FiltroUtilizadoPesquisa = parametroUsadoPesquisa;
                hist.IpOrigemConsulta = HttpContext.Current.Request.UserHostAddress.ToString();
                hist.IdUsuarioConsulta = usuarioLogado.IdUsuario;
                hist.Observacao = Observacao;
                hist.FlagSucesso = pesquisaSucesso;
                hist.TipoFiltroUtilizadoPesquisa = tipoParametroUsadoPesquisa;
                hist.DataConsulta = DataBR;

                return n.Salvar(hist);
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));

                throw ex;
            }
        }

        private void SalvarHistoricoFornecedor(string pesquisaSucesso, int IdHistoricoConsulta, string HTMLRetornado, string NomeProdutoFornecedor, string NomeFornecedor)
        {
            try
            {
                Entidades.FornecedorConsulta retFornecOrigemProd = new Entidades.FornecedorConsulta();
                Entidades.HistoricoPesquisa h = new Entidades.HistoricoPesquisa();

                Negocios.HistoricoPesquisa n = new Negocios.HistoricoPesquisa();

                //Consultando origem da consulta para fins tarifário
                retFornecOrigemProd = ListarOrigemProdutoConsultado(NomeProdutoFornecedor, NomeFornecedor);

                h.IdHistoricoConsulta = IdHistoricoConsulta;
                h.IdOrigemProdutoConsultado = retFornecOrigemProd.Produtos.Where(p => p.NomeProduto.Trim().Equals(NomeProdutoFornecedor)).FirstOrDefault().IdOrigemProdutoConsultado;
                h.IdUsuarioConsulta = usuarioLogado.IdUsuario;
                h.HTMLRetornadoFornecedor = HTMLRetornado;
                h.FlagSucesso = pesquisaSucesso;
                h.DataConsulta = DataBR;

                n.SalvarHistoricoFornecedor(h);
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        private Entidades.FornecedorConsulta ListarOrigemProdutoConsultado(string nomeProduto, string nomeFornecedor)
        {
            try
            {
                Negocios.Fornecedor n = new Negocios.Fornecedor();

                List<Entidades.FornecedorConsulta> list = new List<Entidades.FornecedorConsulta>();
                Entidades.FornecedorConsulta ent = new Entidades.FornecedorConsulta();

                ent.NomeFantasia = nomeFornecedor;
                ent.FlagAtivo = "S";
                ent.Produtos = new List<Entidades.OrigemProdutoConsultado>();
                ent.Produtos.Add(new Entidades.OrigemProdutoConsultado() { NomeProduto = nomeProduto });

                list = n.Listar(ent);

                return list.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        private List<Entidades.Produto> ListarProdutoSolicitadoByUsuario(int idUsuario, string nomeProduto)
        {
            try
            {
                List<Entidades.Produto> l = new List<Entidades.Produto>();
                Negocios.Produtos n = new Negocios.Produtos();
                Entidades.Usuario u = new Entidades.Usuario();

                u.IdUsuario = idUsuario;

                l = n.ListarByIdUsuario(u);

                return l.Where(p => p.NomeInterno.Trim().ToUpper().Equals(nomeProduto.ToUpper())).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion       


    }
}