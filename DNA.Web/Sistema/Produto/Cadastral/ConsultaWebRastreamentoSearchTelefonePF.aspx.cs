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
    public partial class ConsultaWebRastreamentoSearchTelefonePF : System.Web.UI.Page
    {
        string diretorioLog = "../../../";

        int idProdutoPreco = 0;
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        protected void Page_Load(object sender, EventArgs e)
        {
            //Remover
            //Entidades.Usuario usu = new Entidades.Usuario() { IdUsuario = 1 };
            //Session["UsuarioLogado"] = usu;
            //Session["idProdutoPrecoAcessoWEB"] = 3;

            try
            {
                this.Form.Attributes.Add("autocomplete", "off");

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];
                idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-Search Telefone PF";

                if (!Page.IsPostBack)
                {
                    txtDDD.Focus();
                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    //idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());
                }

                this.Form.DefaultButton = btnPesquisar.UniqueID;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDDD.Text.Trim().Equals(""))
                {
                    string msg = string.Empty;
                    msg = "INFORME O DDD.";
                    txtDDD.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (txtDDD.Text.Trim().Length < 2)
                {
                    string msg = string.Empty;
                    msg = "DDD INVÁLIDO.";
                    txtDDD.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (txtTelefone.Text.Trim().Equals(""))
                {
                    string msg = string.Empty;
                    msg = "INFORME O NÚMERO DO TELEFONE.";
                    txtDDD.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (txtTelefone.Text.Replace("-", "").Trim().Length < 8)
                {
                    string msg = string.Empty;
                    msg = "TELEFONE INVÁLIDO.";
                    txtDDD.Focus();

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
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));

                //Response.Redirect("../../Home.aspx", false);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('" + ex.Message +"')</script>", false);
            }
        }

        protected void gridResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[4].Text).Trim().Equals(""))
                    {
                        int idProdutoPrecoPFPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PF PRATA")).FirstOrDefault().IdPrecoProduto; ;

                        string strNome = "";
                        string strDataNascimento = "";
                        string strNomeMae = "";
                        string numeroCPFFormatado = "";
                        string numeroCPF = e.Row.Cells[4].Text;
                        numeroCPF = numeroCPF.Replace(".", "").Replace("-", "");
                        numeroCPF = numeroCPF.PadLeft(11, '0');

                        numeroCPFFormatado = Util.Format.FormatString(numeroCPF, Util.Format.TypeString.CPF);

                        ((HyperLink)e.Row.Cells[0].FindControl("linkCPF")).Text = numeroCPFFormatado;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkCPF")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + numeroCPF;
                        //((HyperLink)e.Row.Cells[0].FindControl("linkCPF")).Attributes.Add("onclick", "return confirm('Essa operação irá gerar uma nova fatura. Deseja continuar?');");

                        strNome = Server.HtmlDecode(e.Row.Cells[5].Text);

                        ((HyperLink)e.Row.Cells[1].FindControl("linkNOME")).Text = strNome;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkNOME")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + numeroCPF;

                        strDataNascimento = Server.HtmlDecode(e.Row.Cells[6].Text);
                        if (strDataNascimento.Trim().Equals(""))
                        { strDataNascimento = "-"; }
                        else
                        {
                            try
                            {
                                strDataNascimento = DateTime.Parse(strDataNascimento).ToString("dd/MM/yyyy");
                            }
                            catch { strDataNascimento = "-"; }
                        }

                        ((HyperLink)e.Row.Cells[1].FindControl("linkDataNascimento")).Text = strDataNascimento;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkDataNascimento")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + numeroCPF;

                        strNomeMae = Server.HtmlDecode(e.Row.Cells[7].Text);
                        if (strNomeMae.Trim().Equals(""))
                        { strNomeMae = "-"; }

                        ((HyperLink)e.Row.Cells[1].FindControl("linkNOMEMAE")).Text = strNomeMae;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkNOMEMAE")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPFPRATA + "&CPF=" + numeroCPF;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));
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

                Negocios.Cadastral.WEB.RastreamentoSearchTelefonePF n = new Negocios.Cadastral.WEB.RastreamentoSearchTelefonePF();
                List<Entidades.Cadastral.ResponseSearchTelefonePF> listRet = new List<Entidades.Cadastral.ResponseSearchTelefonePF>();
                Entidades.Cadastral.FiltroPesquisaSearchTelefonePF filtro = new Entidades.Cadastral.FiltroPesquisaSearchTelefonePF();

                filtro.DDD = txtDDD.Text.Trim();
                filtro.NumeroTel = txtTelefone.Text.Trim().Replace("-", "");

                listRet = n.PesquisaSearchPF(filtro);

                if (listRet != null)
                {
                    divResultado.Visible = true;

                    if (listRet.Count > 0)
                    {
                        gridResult.DataSource = listRet;
                        gridResult.DataBind();

                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 4);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 5);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 6);
                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResult, 7);
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

                    string parametrosPesquisado = "(" + filtro.DDD + ") " + filtro.NumeroTel;

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH TELEFONE PF";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", parametrosPesquisado, "TELEFONE");
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

                    string parametrosPesquisado = "(" + filtro.DDD + ") " + filtro.NumeroTel;

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH TELEFONE PF";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", parametrosPesquisado, "TELEFONE");
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "CNENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoSearchTelefonePF", HttpContext.Current.Server.MapPath(diretorioLog));
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