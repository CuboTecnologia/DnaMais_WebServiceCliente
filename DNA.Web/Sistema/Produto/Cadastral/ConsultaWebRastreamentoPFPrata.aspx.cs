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
    public partial class ConsultaWebRastreamentoPFPrata : System.Web.UI.Page
    {
        string diretorioLog = "../../../";

        string codigoItemProduto = string.Empty;
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
                        this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-PF Prata";
                        tblFiltro.Visible = false;
                        divTituloFiltro.Visible = false;
                        return;
                    }
                }

                if (codigoItemProduto == string.Empty)
                { codigoItemProduto = Session["codigoItemProdutoAcessoWEB"].ToString(); }

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-PF Prata";

                if (!Page.IsPostBack)
                {
                    txtParametroInformado.Focus();
                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    //codigoItemProduto = Session["codigoItemProdutoAcessoWEB"].ToString();
                }

                this.Form.DefaultButton = btnPesquisar.UniqueID;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string numeroCPF = txtParametroInformado.Text.Trim();
                numeroCPF = numeroCPF.Replace(".","").Replace(".","").Replace("-","").Replace("/","");
                numeroCPF = numeroCPF.Trim();
                numeroCPF = numeroCPF.PadLeft(11, '0');

                if (!Util.Format.ValidaCPFCNPJ(numeroCPF, false) || numeroCPF.Length != 11)
                {
                    string msg = string.Empty;
                    msg = "CPF INVÁLIDO.";
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

                        if (ddlFiltro.Value.Trim().ToUpper().Equals("CPF"))
                        {
                            msg = "INFORME O CPF.";
                        }

                        lblMensagemRetorno.Visible = true;
                        lblMensagemRetorno.Text = msg + "<br/><br/>";

                        return;
                    }

                    Consultar(numeroCPF);

                    txtParametroInformado.Text = "";
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));

                //Response.Redirect("../../Home.aspx", false);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('" + ex.Message +"')</script>", false);
            }
        }

        private void LimparCampos()
        {
            this.lblNumeroConsulta.Text = "";
            this.lblDataConsulta.Text = "";
            this.lblNomeCompleto.Text = "";
            this.lblNomeMae.Text = "";
            this.lblCPF.Text = "";
            this.lblStatusCPF.Text = "";
            this.lblRG.Text = "";
            this.lblTituloEleitor.Text = "";
            this.lblIdade.Text = "";
            this.lblDataNascimento.Text = "";
            this.lblSexo.Text = "";
            this.lblSigno.Text = "";
            this.lblEscolaridade.Text = "";
            this.lblRendaEstimada.Text = "";
            this.lblEstadoCivil.Text = "";
            this.lblClasseSocial.Text = "";
            this.lblObito.Text = "";
            this.lblDtObito.Text = "";
        }

        private void Consultar(string numeroCPF)
        {
            try
            {
                string HTMLRetornado = string.Empty;

                lblMensagemRetorno.Text = "";
                lblMensagemRetorno.Visible = false;
                divEspacoBranco.Visible = false;
                divResultado.Visible = false;
                divImprimirMensagemErro.Attributes.Add("style", "display:none;");

                Negocios.Cadastral.WEB.RastreamentoPFPrata n = new Negocios.Cadastral.WEB.RastreamentoPFPrata();
                Entidades.Cadastral.ResponsePFPrata retorno = new Entidades.Cadastral.ResponsePFPrata();

                LimparCampos();
                retorno = n.PesquisaPFPrata(numeroCPF);

                if (retorno != null)
                {
                    divResultado.Visible = true;

                    lblNomeCompleto.Text = retorno.DadosCadastrais.Nome;
                    lblNomeMae.Text = retorno.DadosCadastrais.NomeMae.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.NomeMae; 

                    lblCPF.Text = retorno.DadosCadastrais.CPF.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.CPF;

                    if (retorno.DadosCadastrais.CPF.Trim().Equals(""))
                    { lblCPF.Text = "INDISPONÍVEL"; }
                    else
                    { lblCPF.Text = Util.Format.FormatString(retorno.DadosCadastrais.CPF.PadLeft(11, '0'), Util.Format.TypeString.CPF); }

                    lblStatusCPF.Text = retorno.DadosCadastrais.StatusCPF.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.StatusCPF;
                    lblRG.Text = retorno.DadosCadastrais.RG.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.RG; 
                    lblTituloEleitor.Text = retorno.DadosCadastrais.TituloEleitoral.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.TituloEleitoral; 
                    lblIdade.Text = retorno.DadosCadastrais.Idade.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.Idade;
                    
                    lblSexo.Text = retorno.DadosCadastrais.Sexo.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.Sexo;
                    lblSexo.Text = lblSexo.Text.Trim().Equals("M") ? "MASCULINO" : "FEMININO";

                    lblSigno.Text = retorno.DadosCadastrais.Signo.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.Signo;
                    lblEscolaridade.Text = retorno.DadosCadastrais.Escolaridade.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.Escolaridade;
                    lblRendaEstimada.Text = retorno.DadosCadastrais.RendaEstimada.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.RendaEstimada;
                    lblEstadoCivil.Text = retorno.DadosCadastrais.EstadoCivil.Replace("0", "").Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.EstadoCivil;
                    lblClasseSocial.Text = retorno.DadosCadastrais.ClasseSocial.Trim().Equals("") ? "INDISPONÍVEL" : retorno.DadosCadastrais.ClasseSocial;

                    lblObito.Text = retorno.DadosCadastrais.Obito.Trim().Equals("") ? " - " : retorno.DadosCadastrais.Obito;
                    lblDtObito.Text = retorno.DadosCadastrais.DataObito.Trim().Equals("") ? " - " : retorno.DadosCadastrais.DataObito;

                    if (!retorno.DadosCadastrais.DataObito.Trim().Equals(""))
                    {
                        try
                        {
                            lblDtObito.Text = DateTime.Parse(retorno.DadosCadastrais.DataObito).ToString("dd/MM/yyyy");
                        }
                        catch { lblDtObito.Text = " - "; }
                    }
                    else
                    { lblDtObito.Text = " - "; }

                    if (!retorno.DadosCadastrais.DataNascimento.Trim().Equals(""))
                    {
                        try
                        {
                            lblDataNascimento.Text = DateTime.Parse(retorno.DadosCadastrais.DataNascimento).ToString("dd/MM/yyyy");
                        }
                        catch { lblDataNascimento.Text = "INDISPONÍVEL"; }
                    }
                    else
                    { lblDataNascimento.Text = "INDISPONÍVEL"; }



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


                    if (retorno.Emails != null || retorno.Emails.Count > 0)
                    {
                        gridResultEmails.DataSource = retorno.Emails;
                        gridResultEmails.DataBind();
                    }
                    else
                    {
                        gridResultEmails.DataSource = null;
                        gridResultEmails.EmptyDataText = "NÃO HÁ INFORMAÇÕES SOBRE EMAIL.";
                        gridResultEmails.DataBind();
                    }

                    if (retorno.QSA != null && retorno.QSA.Count > 0)
                    {
                        gridResultQSA.DataSource = retorno.QSA;
                        gridResultQSA.DataBind();

                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 3);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 4);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultQSA, 5);
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

                    string NomeInternoProduto = "WEB RASTREAMENTO PF PRATA";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", codigoItemProduto, "", numeroCPF, "CPF");
                    SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                }
                else
                {
                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = "";

                    lblMensagemRetorno.Text = "CPF NÃO LOCALIZADO.<br/><br/>";

                    string mensagemExibir = "<span id='lblTexto30DiasTexto1' class='texto' style='display:inline-block;font-weight:normal'>";
                    mensagemExibir += ddlFiltro.Value.Trim().ToUpper() + ": <b>" + txtParametroInformado.Text + "</b>";
                    mensagemExibir += "&nbsp;</span><br/><br/>";

                    lblMensagemRetorno.Text += mensagemExibir;
                    divImprimirMensagemErro.Attributes.Add("style", "display:block;");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    LimparCampos();

                    string NomeInternoProduto = "WEB RASTREAMENTO PF PRATA";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", codigoItemProduto, "", numeroCPF, "CPF");
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "CPF NÃO LOCALIZADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        private bool ExibirResultadoRedirect()
        {
            try
            {
                bool ProdutoPrecoEncontrado = false;
                bool CPFEncontrado = false;
                string numeroCPFQueryString = "";

                for (int i = 0; i < Request.QueryString.Count; i++)
                {
                    switch (Request.QueryString.Keys[i].ToString())
                    {
                        case "PRODUTOPRECO":
                            {
                                //TODO: Analisar e ajustar o retorno QueryString["PRODUTOPRECO"] 
                                codigoItemProduto = Request.QueryString["PRODUTOPRECO"].ToString();
                                ProdutoPrecoEncontrado = true;
                                
                                break;
                            }
                        case "CPF":
                            {
                                numeroCPFQueryString = Request.QueryString["CPF"].ToString();
                                CPFEncontrado = true;
                                
                                break;
                            }
                    }
                }

                if (ProdutoPrecoEncontrado && CPFEncontrado)
                {
                    txtParametroInformado.Text = Util.Format.FormatString(numeroCPFQueryString, Util.Format.TypeString.CPF);
                    Consultar(numeroCPFQueryString);
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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));
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
                        string codigoProdutoPrecoPFPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO MORADORES MESMO ENDERECO")).FirstOrDefault().CodigoItemProduto; 

                        string strCEP = e.Row.Cells[4].Text;
                        string strCepFormatado = Util.Format.FormatString(strCEP, Util.Format.TypeString.CEP).Replace(".", "");

                        string strNumero = e.Row.Cells[1].Text;
                        string strUF = e.Row.Cells[6].Text;
                        string strCidade = Util.Format.RemoverAcentos(e.Row.Cells[5].Text);
                        string strBairro = Util.Format.RemoverAcentos(e.Row.Cells[3].Text);
                        string strLogradouro = Util.Format.RemoverAcentos(e.Row.Cells[0].Text);
                        
                        e.Row.Cells[4].Text = strCepFormatado;

                        ((HyperLink)e.Row.Cells[7].FindControl("linkMoradores")).NavigateUrl = "ConsultaWebRastreamentoMoradoresMesmoEndereco.aspx?" +
                                                                                               "PRODUTOPRECO=" + codigoProdutoPrecoPFPRATA + 
                                                                                               "&CEP=" + strCEP.Replace("-", "") + 
                                                                                               "&UF=" + strUF +
                                                                                               "&CIDADE=" + strCidade +
                                                                                               "&BAIRRO=" + strBairro +
                                                                                               "&LOGRADOURO=" + strLogradouro + 
                                                                                               "&NUMERO=" + strNumero;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResultEnderecos_RowDataBound", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "gridResultTelefones_RowDataBound", "ConsultaWebRastreamentoPFPrata", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void gridResultQSA_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[3].Text).Trim().Equals(""))
                    {
                        string codigoProdutoPrecoPJPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PJ PRATA")).FirstOrDefault().CodigoItemProduto; ;

                        string numeroCNPJFormatado = "";
                        string numeroCNPJ = e.Row.Cells[3].Text;
                        numeroCNPJ = numeroCNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                        numeroCNPJ = numeroCNPJ.PadLeft(14, '0');

                        numeroCNPJFormatado = Util.Format.FormatString(numeroCNPJ, Util.Format.TypeString.CNPJ);

                        ((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).Text = numeroCNPJFormatado;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + codigoProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;
                        //((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).Attributes.Add("onclick", "return confirm('Essa operação irá gerar uma nova fatura. Deseja continuar?');");

                        string RazaoSocial = Server.HtmlDecode(e.Row.Cells[4].Text);
                        if (RazaoSocial.Trim().Length > 65)
                        {
                            RazaoSocial = RazaoSocial.Substring(0, 65) + "...";
                        }
                        ((HyperLink)e.Row.Cells[1].FindControl("linkRazaoSocial")).Text = RazaoSocial.Trim().Equals("") ? "-" : RazaoSocial;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkRazaoSocial")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + codigoProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;

                        string NomeFantasia = Server.HtmlDecode(e.Row.Cells[5].Text);
                        if (NomeFantasia.Trim().Length > 40)
                        {
                            NomeFantasia = NomeFantasia.Substring(0, 40) + "...";
                        }
                        ((HyperLink)e.Row.Cells[2].FindControl("linkNomeFantasia")).Text = NomeFantasia.Trim().Equals("") ? "-" : NomeFantasia;
                        ((HyperLink)e.Row.Cells[2].FindControl("linkNomeFantasia")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + codigoProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoSearchPJ", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }
    }
}