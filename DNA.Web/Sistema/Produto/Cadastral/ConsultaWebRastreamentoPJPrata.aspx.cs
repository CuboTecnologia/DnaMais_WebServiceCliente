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
    public partial class ConsultaWebRastreamentoPJPrata : System.Web.UI.Page
    {
        string diretorioLog = "../../../";

        int idProdutoPreco = 0;
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Form.Attributes.Add("autocomplete", "off");

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];

                if (!Page.IsPostBack)
                {
                    if (ExibirResultadoRedirect())
                    {
                        this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-PJ Prata";
                        tblFiltro.Visible = false;
                        divTituloFiltro.Visible = false;
                        return;
                    }
                }

                if (idProdutoPreco == 0)
                { idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString()); }

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-PJ Prata";

                if (!Page.IsPostBack)
                {
                    txtParametroInformado.Focus();
                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    //idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());
                }

                this.Form.DefaultButton = btnPesquisar.UniqueID;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string numeroCNPJ = txtParametroInformado.Text.Trim();
                numeroCNPJ = numeroCNPJ.Replace(".", "").Replace(".", "").Replace("-", "").Replace("/", "");
                numeroCNPJ = numeroCNPJ.Trim();
                numeroCNPJ = numeroCNPJ.PadLeft(14, '0');

                if (!Util.Format.ValidaCPFCNPJ(numeroCNPJ, false) || numeroCNPJ.Length != 14)
                {
                    string msg = string.Empty;
                    msg = "CNPJ INVÁLIDO.";
                    txtParametroInformado.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else
                {
                    if (txtParametroInformado.Text.Trim().Length == 0)
                    {
                        string msg = string.Empty;

                        if (ddlFiltro.Value.Trim().ToUpper().Equals("CNPJ"))
                        {
                            msg = "INFORME O CNPJ.";
                        }

                        lblMensagemRetorno.Visible = true;
                        lblMensagemRetorno.Text = msg + "<br/><br/>";

                        return;
                    }

                    Consultar(numeroCNPJ);

                    txtParametroInformado.Text = "";
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));

                //Response.Redirect("../../Home.aspx", false);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('" + ex.Message + "')</script>", false);
            }
        }

        private void LimparCampos()
        {
            this.lblNumeroConsulta.Text = "";
            this.lblDataConsulta.Text = "";
            this.lblCNPJ.Text = "";
            this.lblRazaoSocial.Text = "";
            this.lblMatrizFilial.Text = "";
            this.lblDataAbertura.Text = "";
            this.lblNomeFantasia.Text = "";
            this.lblNaturezaJuridica.Text = "";
            this.lblSituacaoCadastral.Text = "";
            this.lblDataSituacaoCadastral.Text = "";
        }

        private void Consultar(string numeroCNPJ)
        {
            try
            {
                string HTMLRetornado = string.Empty;

                lblMensagemRetorno.Text = "";
                lblMensagemRetorno.Visible = false;
                divEspacoBranco.Visible = false;
                divResultado.Visible = false;
                divImprimirMensagemErro.Attributes.Add("style", "display:none;");

                Negocios.Cadastral.WEB.RastreamentoPJPrata n = new Negocios.Cadastral.WEB.RastreamentoPJPrata();
                Entidades.Cadastral.ResponsePJPrata retorno = new Entidades.Cadastral.ResponsePJPrata();

                LimparCampos();
                retorno = n.PesquisaPJPrata(numeroCNPJ);

                if (retorno != null)
                {
                    divResultado.Visible = true;

                    if (retorno.DadosCadastrais.CNPJ.Trim().Equals(""))
                    { lblCNPJ.Text = "INDISPONÍVEL"; }
                    else
                    { lblCNPJ.Text = Util.Format.FormatString(retorno.DadosCadastrais.CNPJ.PadLeft(14, '0'), Util.Format.TypeString.CNPJ); }

                    lblRazaoSocial.Text = retorno.DadosCadastrais.RazaoSocial.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.RazaoSocial;
                    lblMatrizFilial.Text = retorno.DadosCadastrais.MatrizFilial.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.MatrizFilial;

                    if (!retorno.DadosCadastrais.DataAbertura.Trim().Equals(""))
                    {
                        try
                        {
                            lblDataAbertura.Text = DateTime.Parse(retorno.DadosCadastrais.DataAbertura).ToString("dd/MM/yyyy");
                        }
                        catch { lblDataAbertura.Text = "INDISPONÍVEL"; }
                    }
                    else
                    { lblDataSituacaoCadastral.Text = "INDISPONÍVEL"; }

                    lblNomeFantasia.Text = retorno.DadosCadastrais.NomeFantasia.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.NomeFantasia;
                    lblNaturezaJuridica.Text = retorno.DadosCadastrais.NaturezaJuridica.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.NaturezaJuridica;
                    lblSituacaoCadastral.Text = retorno.DadosCadastrais.SituacaoCadastral.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.SituacaoCadastral;

                    if (!retorno.DadosCadastrais.DataSituacaoDastral.Trim().Equals(""))
                    {
                        try
                        {
                            lblDataSituacaoCadastral.Text = DateTime.Parse(retorno.DadosCadastrais.DataSituacaoDastral).ToString("dd/MM/yyyy");
                        }
                        catch { lblDataSituacaoCadastral.Text = "INDISPONÍVEL"; }
                    }
                    else
                    { lblDataSituacaoCadastral.Text = "INDISPONÍVEL"; }



                    if (retorno.Enderecos != null || retorno.Enderecos.Count > 0)
                    {
                        gridResultEnderecos.DataSource = retorno.Enderecos;
                        gridResultEnderecos.DataBind();
                    }
                    else
                    {
                        gridResultEnderecos.DataSource = null;
                        gridResultEnderecos.EmptyDataText = "NÃO HÁ INFORMAÇÕES SOBRE ENDEREÇO.";
                        gridResultEnderecos.DataBind();
                    }


                    if (retorno.Telefones != null || retorno.Telefones.Count > 0)
                    {
                        gridResultTelefones.DataSource = retorno.Telefones;
                        gridResultTelefones.DataBind();
                    }
                    else
                    {
                        gridResultTelefones.DataSource = null;
                        gridResultTelefones.EmptyDataText = "NÃO HÁ INFORMAÇÕES SOBRE TELEFONE.";
                        gridResultTelefones.DataBind();
                    }


                    if (retorno.CNAE != null || retorno.CNAE.Count > 0)
                    {
                        gridResultCNAEs.DataSource = retorno.CNAE;
                        gridResultCNAEs.DataBind();
                    }
                    else
                    {
                        gridResultCNAEs.DataSource = null;
                        gridResultCNAEs.EmptyDataText = "NÃO HÁ INFORMAÇÕES SOBRE CNAE.";
                        gridResultCNAEs.DataBind();
                    }

                    if (retorno.QSA != null && retorno.QSA.Count > 0)
                    {
                        gridResultQSA.DataSource = retorno.QSA;
                        gridResultQSA.DataBind();

                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 5);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 6);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 7);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 8);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 9);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 10);
                    }
                    else
                    {
                        gridResultQSA.DataSource = null;
                        gridResultQSA.EmptyDataText = "NENHUM REGISTRO ENCONTRADO.";
                        gridResultQSA.DataBind();
                    }

                    //Transformando o Retorno em XML para gravar no banco
                    var xns = new XmlSerializerNamespaces();
                    xns.Add(string.Empty, string.Empty);
                    var xs = new XmlSerializer(retorno.GetType());
                    var xml = new StringWriter();
                    xs.Serialize(xml, retorno, xns);

                    HTMLRetornado = xml.ToString();

                    string NomeInternoProduto = "WEB RASTREAMENTO PJ PRATA";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", numeroCNPJ, "CNPJ");
                    SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                }
                else
                {
                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = "";

                    lblMensagemRetorno.Text = "CNPJ NÃO LOCALIZADO.<br/><br/>";

                    string mensagemExibir = "<span id='lblTexto30DiasTexto1' class='texto' style='display:inline-block;font-weight:normal'>";
                    mensagemExibir += ddlFiltro.Value.Trim().ToUpper() + ": <b>" + txtParametroInformado.Text + "</b>";
                    mensagemExibir += "&nbsp;</span><br/><br/>";

                    lblMensagemRetorno.Text += mensagemExibir;
                    divImprimirMensagemErro.Attributes.Add("style", "display:block;");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    LimparCampos();

                    string NomeInternoProduto = "WEB RASTREAMENTO PJ PRATA";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", numeroCNPJ, "CNPJ");
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "CNPJ NÃO LOCALIZADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        private bool ExibirResultadoRedirect()
        {
            try
            {
                bool ProdutoPrecoEncontrado = false;
                bool CNPJEncontrado = false;
                string numeroCNPJQueryString = "";

                for (int i = 0; i < Request.QueryString.Count; i++)
                {
                    switch (Request.QueryString.Keys[i].ToString())
                    {
                        case "PRODUTOPRECO":
                            {
                                idProdutoPreco = int.Parse(Request.QueryString["PRODUTOPRECO"].ToString());
                                ProdutoPrecoEncontrado = true;

                                break;
                            }
                        case "CNPJ":
                            {
                                numeroCNPJQueryString = Request.QueryString["CNPJ"].ToString();
                                CNPJEncontrado = true;

                                break;
                            }
                    }
                }

                if (ProdutoPrecoEncontrado && CNPJEncontrado)
                {
                    txtParametroInformado.Text = Util.Format.FormatString(numeroCNPJQueryString, Util.Format.TypeString.CNPJ);
                    Consultar(numeroCNPJQueryString);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region MÉTODOS PARA CONTROLE DAS CONSULTAS

        private Entidades.HistoricoPesquisa SalvarHistoricoPesquisa(string pesquisaSucesso, int idProdutoPreco, string Observacao, string parametroUsadoPesquisa, string tipoParametroUsadoPesquisa)
        {
            try
            {
                Entidades.HistoricoPesquisa hist = new Entidades.HistoricoPesquisa();
                Negocios.HistoricoPesquisa n = new Negocios.HistoricoPesquisa();

                hist.IdProdutoPreco = idProdutoPreco;
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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));
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

        protected void gridResultEnderecos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[4].Text).Trim().Equals(""))
                    {
                        e.Row.Cells[4].Text = Util.Format.FormatString(e.Row.Cells[4].Text, Util.Format.TypeString.CEP).Replace(".", "");
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultEnderecos_RowDataBound", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));

                //if (Session["UsuarioLogado"] == null)
                //{ Response.Redirect("/Home.aspx", false); }
                //else
                //{ Response.Redirect("../Home.aspx", false); }
            }
        }

        protected void gridResultTelefones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[1].Text).Trim().Equals(""))
                    {
                        e.Row.Cells[1].Text = Util.Format.FormatString(e.Row.Cells[1].Text, Util.Format.TypeString.Telephone);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultTelefones_RowDataBound", "ConsultaWebRastreamentoPJPrata", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void gridResultQSA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[5].Text).Trim().Equals(""))
                    {
                        string strDocumentoSocioFormatado = "";
                        string strDocumentoSocio = e.Row.Cells[5].Text;
                        string strNome = Server.HtmlDecode(e.Row.Cells[6].Text);
                        string strQualificacao = Server.HtmlDecode(e.Row.Cells[7].Text); ;
                        string strDataEntradaSociedade = Server.HtmlDecode(e.Row.Cells[8].Text);
                        string strParticipacao = Server.HtmlDecode(e.Row.Cells[9].Text);
                        string strTipoPessoa = Server.HtmlDecode(e.Row.Cells[10].Text).Trim();

                        if (strDocumentoSocio.Trim().Equals(""))
                        { strDocumentoSocio = "-"; }

                        if (strNome.Trim().Equals(""))
                        { strNome = "-"; }

                        if (strQualificacao.Trim().Equals(""))
                        { strQualificacao = "-"; }

                        if (strDataEntradaSociedade.Trim().Equals(""))
                        { strDataEntradaSociedade = "-"; }

                        if (strParticipacao.Trim().Equals(""))
                        { strParticipacao = "-"; }
                        else
                        {
                            strParticipacao = strParticipacao.PadLeft(2, '0') + "%";
                        }

                        strDocumentoSocio = strDocumentoSocio.Replace(".", "").Replace(".", "").Replace("-", "").Replace("/", "").Replace("-", "").Replace("-", "").Replace("-", "");

                        if (strTipoPessoa.Equals("PJ"))
                        {
                            int idProdutoPrecoPJPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PJ PRATA")).FirstOrDefault().IdPrecoProduto; ;

                            strDocumentoSocio = strDocumentoSocio.PadLeft(14, '0');
                            strDocumentoSocioFormatado = Util.Format.FormatString(strDocumentoSocio, Util.Format.TypeString.CNPJ);

                            ((HyperLink)e.Row.Cells[0].FindControl("linkCPFCNPJ")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkNOME")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkQualificacao")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkDataEntradaSociedade")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkParticipacao")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + strDocumentoSocio;
                        }
                        else
                        {
                            int idProdutoPrecoPFPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PF PRATA")).FirstOrDefault().IdPrecoProduto; ;

                            strDocumentoSocio = strDocumentoSocio.PadLeft(11, '0');
                            strDocumentoSocioFormatado = Util.Format.FormatString(strDocumentoSocio, Util.Format.TypeString.CPF);

                            //((HyperLink)e.Row.Cells[0].FindControl("linkCPF")).Attributes.Add("onclick", "return confirm('Essa operação irá gerar uma nova fatura. Deseja continuar?');");
                            ((HyperLink)e.Row.Cells[0].FindControl("linkCPFCNPJ")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkNOME")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkQualificacao")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkDataEntradaSociedade")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + strDocumentoSocio;
                            ((HyperLink)e.Row.Cells[0].FindControl("linkParticipacao")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + strDocumentoSocio;
                        }

                        ((HyperLink)e.Row.Cells[0].FindControl("linkCPFCNPJ")).Text = strDocumentoSocioFormatado;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkNOME")).Text = strNome;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkQualificacao")).Text = strQualificacao;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkDataEntradaSociedade")).Text = strDataEntradaSociedade;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkParticipacao")).Text = strParticipacao;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }
    }
}