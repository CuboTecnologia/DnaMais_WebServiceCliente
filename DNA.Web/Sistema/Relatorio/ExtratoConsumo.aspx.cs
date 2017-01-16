using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DNA.Web.Sistema.Relatorio
{
    public partial class ExtratoConsumo : System.Web.UI.Page
    {
        string diretorioLog = "../../";
        Entidades.Usuario usuarioLogado = new Entidades.Usuario();
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("../../Home.aspx", false); return; }

                usuarioLogado = (Entidades.Usuario)Session["UsuarioLogado"];

                IncluirJavascript();
                SelecionaMenuMasterPage();
                this.Form.DefaultButton = btnPesquisar.UniqueID;

                if (!Page.IsPostBack)
                {
                    ddlStatus.SelectedIndex = 1;
                    txtDataInicial.Text = "01/" + DataBR.ToString("MM/yyyy");
                    txtDataFinal.Text = DataBR.ToString("dd/MM/yyyy");

                    divEspacoBranco.Visible = true;
                    divListarSolicitacoes.Visible = false;

                    ListarProdutosByUsuario();
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ExtratoConsumo", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ListarRelatorio();
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ExtratoConsumo", HttpContext.Current.Server.MapPath(diretorioLog));
                throw;
            }
        }

        protected void gridResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string IdHistoricoConsulta = "";
                    HyperLink linkIdHistoricoConsulta = e.Row.FindControl("linkIdHistoricoConsulta") as HyperLink;
                    IdHistoricoConsulta = linkIdHistoricoConsulta.Text;
                    linkIdHistoricoConsulta.Text = Server.HtmlDecode(linkIdHistoricoConsulta.Text).ToString().PadLeft(5, '0');

                    string ParametroPesquisado = "";
                    HyperLink linkParametroPesquisado = e.Row.FindControl("linkParametroPesquisado") as HyperLink;
                    ParametroPesquisado = linkParametroPesquisado.Text;

                    if (Server.HtmlDecode(e.Row.Cells[13].Text).Trim().Equals(""))
                    {
                        if (Server.HtmlDecode(ParametroPesquisado).Trim().Length > 0)
                        {
                            ParametroPesquisado = ParametroPesquisado.Replace("-", "");

                            if (Server.HtmlDecode(ParametroPesquisado).Trim().Length == 7)
                            { linkParametroPesquisado.Text = "Placa: " + Server.HtmlDecode(ParametroPesquisado).ToString().ToUpper().Trim().Substring(0, 3) + "-" + Server.HtmlDecode(ParametroPesquisado).ToString().ToUpper().Trim().Substring(3, 4); }
                            else if (Server.HtmlDecode(ParametroPesquisado).Trim().Length == 17)
                            { linkParametroPesquisado.Text = "Chassi: " + Server.HtmlDecode(ParametroPesquisado).ToString(); }
                            else
                            { linkParametroPesquisado.Text = "Outro: " + Server.HtmlDecode(ParametroPesquisado).ToString(); }

                        }
                    }
                    else
                    {
                        linkParametroPesquisado.Text = Server.HtmlDecode(e.Row.Cells[13].Text) + ": " + Server.HtmlDecode(ParametroPesquisado).ToString();
                    }

                    HyperLink linkDataHoraPesquisa = e.Row.FindControl("linkDataHoraPesquisa") as HyperLink;

                    if (Server.HtmlDecode(linkDataHoraPesquisa.Text).Trim().Length > 0)
                    {
                        DateTime dataSolicitacao = DateTime.Parse(Server.HtmlDecode(linkDataHoraPesquisa.Text));
                        linkDataHoraPesquisa.Text = dataSolicitacao.ToString("dd/MM/yyyy") + " às " + dataSolicitacao.ToString("HH:mm");
                    }

                    Image imgCheckOk = e.Row.FindControl("imgCheckOk") as Image;
                    Image imgError = e.Row.FindControl("imgError") as Image;

                    HyperLink linkNomeProdutoConsultado = e.Row.FindControl("linkNomeProdutoConsultado") as HyperLink;

                    imgCheckOk.Visible = false;
                    imgError.Visible = false;

                    string textToolTip = "";

                    if (Server.HtmlDecode(e.Row.Cells[10].Text).Equals("PROCESSADO") && Server.HtmlDecode(e.Row.Cells[12].Text).Equals("True"))
                    {
                        imgCheckOk.Visible = true;
                        //imgCheckOk.ImageUrl = "~/images/check18x18.png";
                        imgCheckOk.ToolTip = "Solicitação processada com sucesso";
                        imgCheckOk.Attributes.Add("cursor", "pointer");

                        textToolTip = "Clique para visualizar a pesquisa";
                        string montarLink = "../Produtos/Veiculares/";
                        string nomePagina = "";

                        switch (e.Row.Cells[11].Text.ToUpper().ToString())
                        {
                            case "CONSULTAR BASE NACIONAL":
                                {
                                    nomePagina = "ConsultaBIN.aspx";
                                    break;
                                }
                            case "CONSULTAR AGREGADO SERVIDOR CHECKLOG":
                                {
                                    nomePagina = "ConsultarAgregado.aspx";
                                    break;
                                }
                            case "PESQUISA ESPECIAL ECV":
                                {
                                    nomePagina = "ConsultaEspecialECVResultado.aspx";
                                    break;
                                }
                            case "PESQUISA ESPECIAL ECV CONCESSIONARIA":
                                {
                                    nomePagina = "ConsultaEspecialConcessionariaResultado.aspx";
                                    break;
                                }
                            default:
                                { break; }
                        }

                        montarLink += nomePagina;
                        montarLink += "?NumeroConsulta=" + IdHistoricoConsulta;
                        montarLink += "&codigoItemProdutoPesquisado=" + Server.HtmlDecode(e.Row.Cells[14].Text).Trim();

                        // APENAS DECOMENTAR QUANDO FOR SOLICITADO EXIBIÇÃO DOS DADOS DETALHADOS DA PESQUISA COMO NO SITE CHECKLOG
                        //linkIdHistoricoConsulta.NavigateUrl = montarLink;
                        //linkParametroPesquisado.NavigateUrl = montarLink;
                        //linkDataHoraPesquisa.NavigateUrl = montarLink;
                        //linkNomeProdutoConsultado.NavigateUrl = montarLink;
                        textToolTip = "Pesquisa processada com sucesso";

                    }
                    else
                    {
                        textToolTip = "Erro ao processar a solicitação";

                        imgError.Visible = true;
                        //imgError.ImageUrl = "~/images/Error18x18.png";
                        imgError.ToolTip = "Erro ao processar a solicitação";
                        imgError.Attributes.Add("cursor", "pointer");

                        linkIdHistoricoConsulta.Attributes.Add("style", "color:red;");
                        linkParametroPesquisado.Attributes.Add("style", "color:red;");
                        linkDataHoraPesquisa.Attributes.Add("style", "color:red;");
                        linkNomeProdutoConsultado.Attributes.Add("style", "color:red;");

                        //linkHora.ToolTip = "Aguarde enquanto o sistema processa seu pedido";
                    }

                    linkIdHistoricoConsulta.ToolTip = textToolTip;
                    linkParametroPesquisado.ToolTip = textToolTip;
                    linkDataHoraPesquisa.ToolTip = textToolTip;
                    linkNomeProdutoConsultado.ToolTip = textToolTip;
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ExtratoConsumo", HttpContext.Current.Server.MapPath(diretorioLog));

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("/Home.aspx", false); }
                else
                { Response.Redirect("../Home.aspx", false); }
            }
        }

        private void SelecionaMenuMasterPage()
        {
            this.Page.Title = "DNA+ - Extrato da Conta";
            //this.Master.m = "Anunciar";
            //this.Form.DefaultButton = ((Button)this.Login1.FindControl("Button1")).UniqueID;
            this.Master.MenuAtual = PrincipalAutenticada.menuSelecionado.ExtratoConta;
        }

        private void ListarProdutosByUsuario()
        {
            try
            {
                ddlProdutos.Items.Clear();
                ddlProdutos.Items.Add(new ListItem("TODOS", "0"));

                List<Entidades.Produto> SortedList = usuarioLogado.Produtos.OrderBy(o => o.NomeProduto).ToList();

                foreach (Entidades.Produto p in SortedList)
                {
                    ddlProdutos.Items.Add(new ListItem(p.NomeProduto, p.CodigoItemProduto.ToString()));
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "ListarProdutosByUsuario", "ExtratoConsumo", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        private void ListarRelatorio()
        {
            try
            {
                if (DateTime.Compare(DateTime.Parse(txtDataInicial.Text), DateTime.Parse(txtDataFinal.Text)) <= 0)
                {
                    Negocios.Relatorio.Relatorios rel = new Negocios.Relatorio.Relatorios();
                    Entidades.Relatorio.FiltroPesquisa filtro = new Entidades.Relatorio.FiltroPesquisa();
                    List<Entidades.Relatorio.RelatorioAnaliticoUsuario> listRet = new List<Entidades.Relatorio.RelatorioAnaliticoUsuario>();

                    filtro.IdUsuarioLogado = usuarioLogado.IdUsuario;
                    filtro.DataInicialPesquisa = DateTime.Parse(txtDataInicial.Text + " 00:00:00");
                    filtro.DataFinalPesquisa = DateTime.Parse(txtDataFinal.Text + " 23:59:59");
                    filtro.CodigoItemProduto = ddlProdutos.SelectedItem.Value;

                    listRet = rel.ListarRelatorioAnaliticoUsuario(filtro);

                    gridResult.DataSource = null;

                    if (listRet != null && listRet.Count > 0)
                    {
                        int qtdeRegistros = 0;
                        if (ddlStatus.SelectedIndex == 1)
                        {
                            gridResult.DataSource = listRet.Where(p => p.StatusPesquisa.Equals("PROCESSADO") && (bool)p.StatusHistoricoPesquisa);
                            qtdeRegistros = listRet.Where(p => p.StatusPesquisa.Equals("PROCESSADO") && (bool)p.StatusHistoricoPesquisa).Count();
                        }
                        else if (ddlStatus.SelectedIndex == 2)
                        {
                            gridResult.DataSource = listRet.Where(p => (bool)!p.StatusHistoricoPesquisa);
                            qtdeRegistros = listRet.Where(p => (bool)!p.StatusHistoricoPesquisa).Count();
                        }
                        else
                        {
                            gridResult.DataSource = listRet;
                            qtdeRegistros = listRet.Count;
                        }

                        gridResult.Visible = true;

                        divMensagemRetorno.Visible = false;
                        lblMensagemRetorno.Visible = false;
                        divEspacoBranco.Visible = true;
                        divListarSolicitacoes.Visible = true;
                        divDetalhesRetorno.Visible = true;

                        lblTotalPesquisas.Visible = true;
                        lblTotalPesquisas.Text = "TOTAL DE PESQUISAS PARA O PERÍODO INFORMADO: <b>" + qtdeRegistros.ToString() + "</b>";
                    }
                    else
                    {
                        lblTotalPesquisas.Visible = false;
                        divListarSolicitacoes.Visible = true;
                        divMensagemRetorno.Visible = true;
                        lblMensagemRetorno.Visible = true;
                        divEspacoBranco.Visible = true;
                        divDetalhesRetorno.Visible = false;
                        lblMensagemRetorno.Text = "NÃO HÁ INFORMAÇÕES PARA O PERÍODO INFORMADO.";
                    }

                    gridResult.DataBind();

                    if (ddlStatus.SelectedIndex > 0)
                    { Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 0); }

                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 4);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 5);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 6);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 7);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 9);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 10);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 11);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 12);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 13);
                    Util.Format.OcultaColunaEspecificaGrid(ref gridResult, 14);
                }
                else
                {
                    gridResult.DataSource = null;
                    gridResult.DataBind();
                    gridResult.Visible = false;

                    divMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Visible = true;
                    divEspacoBranco.Visible = true;
                    lblMensagemRetorno.Text = "A DATA FINAL NÃO PODE SER MAIOR DO QUE A DATA INCIAL.";
                }

            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "ListarRelatorio", "ExtratoConsumo", HttpContext.Current.Server.MapPath(diretorioLog));

                if (Session["UsuarioLogado"] == null)
                { Response.Redirect("/Home.aspx", false); }
                else
                { Response.Redirect("../Home.aspx", false); }
            }
        }

        protected void IncluirJavascript()
        {
            string _script = "<script type=\"text/javascript\" language=\"javascript\">";
            _script += "var dp_cal1;";
            _script += "var dp_cal2;";
            _script += " window.onload = function(){";
            _script += "dp_cal1 = new Epoch('epoch_popup1','popup',document.getElementById('" + txtDataInicial.ClientID + "'));";
            _script += "dp_cal2 = new Epoch('epoch_popup2','popup',document.getElementById('" + txtDataFinal.ClientID + "'));";
            _script += "document.getElementById('" + txtDataInicial.ClientID + "').readOnly = true;";
            _script += "document.getElementById('" + txtDataFinal.ClientID + "').readOnly = true;";
            _script += "}</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "DateInputs", _script);
        }

        protected void imgExportExcel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Extrato_" + DataBR.ToString("dd-MM-yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gridResult.AllowPaging = false;

                //this.BindGrid();
                //ListarSolicitacoes();

                gridResult.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in gridResult.HeaderRow.Cells)
                {
                    cell.BackColor = gridResult.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridResult.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridResult.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridResult.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gridResult.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}