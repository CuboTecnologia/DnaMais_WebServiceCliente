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
    public partial class ConsultaWebRastreamentoSearchTelefonePJ : System.Web.UI.Page
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

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-Search Telefone PJ";

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
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));

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
                    if (!Server.HtmlDecode(e.Row.Cells[3].Text).Trim().Equals(""))
                    {
                        int idProdutoPrecoPJPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PJ PRATA")).FirstOrDefault().IdPrecoProduto; ;

                        string numeroCNPJFormatado = "";
                        string numeroCNPJ = e.Row.Cells[3].Text;
                        numeroCNPJ = numeroCNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                        numeroCNPJ = numeroCNPJ.PadLeft(14, '0');

                        numeroCNPJFormatado = Util.Format.FormatString(numeroCNPJ, Util.Format.TypeString.CNPJ);

                        ((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).Text = numeroCNPJFormatado;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;
                        //((HyperLink)e.Row.Cells[0].FindControl("linkCNPJ")).Attributes.Add("onclick", "return confirm('Essa operação irá gerar uma nova fatura. Deseja continuar?');");

                        string RazaoSocial = Server.HtmlDecode(e.Row.Cells[4].Text);
                        if (RazaoSocial.Trim().Length > 65)
                        {
                            RazaoSocial = RazaoSocial.Substring(0, 65) + "...";
                        }
                        ((HyperLink)e.Row.Cells[1].FindControl("linkRazaoSocial")).Text = RazaoSocial.Trim().Equals("") ? "-" : RazaoSocial;
                        ((HyperLink)e.Row.Cells[1].FindControl("linkRazaoSocial")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;

                        string NomeFantasia = Server.HtmlDecode(e.Row.Cells[5].Text);
                        if (NomeFantasia.Trim().Length > 40)
                        {
                            NomeFantasia = NomeFantasia.Substring(0, 40) + "...";
                        }
                        ((HyperLink)e.Row.Cells[2].FindControl("linkNomeFantasia")).Text = NomeFantasia.Trim().Equals("") ? "-" : NomeFantasia;
                        ((HyperLink)e.Row.Cells[2].FindControl("linkNomeFantasia")).NavigateUrl = "ConsultaWebRastreamentoPJPrata.aspx?PRODUTOPRECO=" + idProdutoPrecoPJPRATA + "&CNPJ=" + numeroCNPJ;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));
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

                Negocios.Cadastral.WEB.RastreamentoSearchTelefonePJ n = new Negocios.Cadastral.WEB.RastreamentoSearchTelefonePJ();
                List<Entidades.Cadastral.ResponseSearchTelefonePJ> listRet = new List<Entidades.Cadastral.ResponseSearchTelefonePJ>();
                Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ filtro = new Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ();

                filtro.DDD = txtDDD.Text.Trim();
                filtro.NumeroTel = txtTelefone.Text.Trim().Replace("-", "");

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

                    string parametrosPesquisado = "(" + filtro.DDD + ") " + filtro.NumeroTel;

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH TELEFONE PJ";
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

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH TELEFONE PJ";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", parametrosPesquisado, "TELEFONE");
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "CNENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoSearchTelefonePJ", HttpContext.Current.Server.MapPath(diretorioLog));
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