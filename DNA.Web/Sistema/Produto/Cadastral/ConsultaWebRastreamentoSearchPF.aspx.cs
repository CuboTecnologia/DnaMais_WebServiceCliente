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
    public partial class ConsultaWebRastreamentoSearchPF : System.Web.UI.Page
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
                IncluirJavascript();

                this.Form.Attributes.Add("autocomplete", "off");

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];
                idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-Search PF";

                if (!Page.IsPostBack)
                {
                    ddlCidade.Enabled = false;
                    txtNome.Focus();
                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    //idProdutoPreco = int.Parse(Session["idProdutoPrecoAcessoWEB"].ToString());
                }

                this.Form.DefaultButton = btnPesquisar.UniqueID;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNome.Text.Trim().Length < 5)
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
                else if (txtNome.Text.Trim().Split(new Char[] { ' ' }).Count() < 2)
                {
                    string msg = string.Empty;
                    msg = "INFORME O NOME E O SOBRENOME.";
                    txtNome.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (ddlUF.SelectedIndex == 0 && ddlCidade.SelectedIndex == 0 && txtDataNascimento.Text.Trim().Equals("") && txtNomeMae.Text.Trim().Equals(""))
                {
                    string msg = string.Empty;
                    msg = "PELO MENOS A DATA DE NASCIMENTO, NOME DA MAE OU UF+MUNICIPIO DEVEM SER INFORMADOS.";
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
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "ddlUF_SelectedIndexChanged", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));
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
                        int idProdutoPrecoPFPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PF PRATA")).FirstOrDefault().IdPrecoProduto; 

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
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        private void LimparCampos()
        {
            this.lblNumeroConsulta.Text = "";
            this.lblDataConsulta.Text = "";
            
        }

        protected void IncluirJavascript()
        {
            string _script = "<script type=\"text/javascript\" language=\"javascript\">";
            _script += "var dp_cal1;";
            _script += " window.onload = function(){";
            _script += "dp_cal1 = new Epoch('epoch_popup1','popup',document.getElementById('" + txtDataNascimento.ClientID + "'));";
            _script += "document.getElementById('" + txtDataNascimento.ClientID + "').readOnly = true;";
            _script += "}</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "DateInputs", _script);
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

                Negocios.Cadastral.WEB.RastreamentoSearchPF n = new Negocios.Cadastral.WEB.RastreamentoSearchPF();
                List<Entidades.Cadastral.ResponseSearchPF> listRet = new List<Entidades.Cadastral.ResponseSearchPF>();
                Entidades.Cadastral.FiltroPesquisaSearchPF filtro = new Entidades.Cadastral.FiltroPesquisaSearchPF();

                filtro.Nome = txtNome.Text.ToUpper();
                filtro.UF = ddlUF.SelectedItem.Text.Split(new Char[] { '-' })[0].ToString().Trim(); ;
                filtro.Cidade = Util.Format.RemoverAcentos(ddlCidade.SelectedItem.Text);
                filtro.DataNascimento = txtDataNascimento.Text;
                filtro.NomeMae = txtNomeMae.Text;

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

                    string parametrosPesquisado = filtro.Nome + " | " + filtro.UF + " | " + filtro.Cidade;

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH PF";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", parametrosPesquisado, "NOME | UF | CIDADE");
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

                    string NomeInternoProduto = "WEB RASTREAMENTO SEARCH PF";
                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", parametrosPesquisado, "NOME | UF | CIDADE");
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "NENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoSearchPF", HttpContext.Current.Server.MapPath(diretorioLog));
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