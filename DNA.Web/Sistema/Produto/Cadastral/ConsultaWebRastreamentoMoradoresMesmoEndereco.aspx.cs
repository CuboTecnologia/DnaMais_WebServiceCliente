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
    public partial class ConsultaWebRastreamentoMoradoresMesmoEndereco : System.Web.UI.Page
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

                if (!Page.IsPostBack)
                {
                    if (ExibirResultadoRedirect())
                    {
                        this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-Moradores do Mesmo Endereço";
                        tblFiltro.Visible = false;
                        divTituloFiltro.Visible = false;
                        return;
                    }
                }

                if (codigoItemProduto == string.Empty)
                { codigoItemProduto = Session["codigoItemProdutoAcessoWEB"].ToString(); }

                this.Page.Title = "DNA+ - Produtos Cadastrais - DNA-Moradores do Mesmo Endereço";

                if (!Page.IsPostBack)
                {
                    ddlCidade.Enabled = false;
                    txtCEP.Focus();
                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                    //codigoItemProduto = Session["codigoItemProdutoAcessoWEB"].ToString();
                }

                this.Form.DefaultButton = btnPesquisar.UniqueID;
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Page_Load", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));

                Response.Redirect("../../Home.aspx", false);
            }
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static Entidades.EnderecoByCEP ConsualtaEnderecoByCEP(string CEP)
        {
            try
            {
                CEP = CEP.Replace("-", "").Trim();
                //Negocios.ConsultaEndereco c = new Negocios.ConsultaEndereco();
                //Entidades.EnderecoByCEP e = new Entidades.EnderecoByCEP();
                //e = c.ByCEP(CEP);

                Entidades.EnderecoByCEP e = new Entidades.EnderecoByCEP();

                string logradouro = "";
                string bairro = "";
                string cidade = "";
                string estado = "";
                string uf = "";
                string erro = "";

                Util.CEP.ConsultaOnline(CEP, ref logradouro, ref bairro, ref cidade, ref estado, ref uf, ref erro);

                if (erro.Trim().Length == 0)
                {
                    e.Logradouro = logradouro.ToUpper().Trim();
                    e.Bairro = bairro.ToUpper().Trim();
                    e.Cidade = Util.Format.RemoverAcentos(cidade.ToUpper().Trim());
                    e.Estado = estado.ToUpper().Trim();
                    e.UF = uf.ToUpper().Trim();
                    e.CEP = CEP;
                }

                return e == null ? new Entidades.EnderecoByCEP() : e;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCEP.Text.Trim().Length < 9)
                {
                    string msg = string.Empty;
                    msg = "CEP INVÁLIDO.";
                    txtCEP.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (ddlUF.SelectedItem.Text == "SELECIONE..." && hdnUfEstado.Value.Trim().Equals(""))
                {
                    string msg = string.Empty;
                    msg = "SELECIONE O ESTADO (UF).";

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (ddlCidade.SelectedItem.Text == "SELECIONE..." && hdnCidade.Value.Trim().Equals(""))
                {
                    string msg = string.Empty;
                    msg = "SELECIONE A CIDADE.";

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (txtBairro.Text.Length == 0)
                {
                    string msg = string.Empty;
                    msg = "INFORME O BAIRRO.";
                    txtBairro.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else if (txtLogradouro.Text.Length == 0)
                {
                    string msg = string.Empty;
                    msg = "INFORME O LOGRADOURO.";
                    txtLogradouro.Focus();

                    lblMensagemRetorno.Visible = true;
                    lblMensagemRetorno.Text = msg + "<br/><br/>";

                    lblMensagemRetorno.ForeColor = System.Drawing.Color.Red;
                    lblMensagemRetorno.Attributes.Add("style", "font-weight:normal");

                    divEspacoBranco.Visible = true;
                    divResultado.Visible = false;
                }
                else
                {
                    string ufSelecionado = hdnUfEstado.Value;
                    string cidadeSelecionada = hdnCidade.Value;
                    Consultar();

                    for (int i = 0; i < ddlUF.Items.Count; i++)
                    {
                        if (ddlUF.Items[i].Text.Contains(ufSelecionado + " - "))
                        {
                            ddlUF.SelectedIndex = i;

                            Negocios.Cadastral.WEB.Listas n = new Negocios.Cadastral.WEB.Listas();
                            List<Entidades.Cadastral.Cidade> listCidades = new List<Entidades.Cadastral.Cidade>();

                            listCidades = n.ListarCidadesPorIdUF(int.Parse(ddlUF.SelectedItem.Value), "", 0, "");

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

                            for (int j = 0; j < ddlCidade.Items.Count; j++)
                            {
                                if (ddlCidade.Items[j].Text.Equals(cidadeSelecionada))
                                {
                                    ddlCidade.SelectedIndex = j;
                                    break;
                                }
                            }
                            
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "btnPesquisar_Click", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "ddlUF_SelectedIndexChanged", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));
            }
        }

        protected void gridResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (!Server.HtmlDecode(e.Row.Cells[1].Text).Trim().Equals(""))
                    {
                        string codigoProdutoPrecoPFPRATA = usuarioLogado.Produtos.Where(p => p.NomeInterno.ToUpper().Equals("WEB RASTREAMENTO PF PRATA")).FirstOrDefault().CodigoItemProduto; ;

                        string strNome = "";
                        string strDataNascimento = "";
                        string strNomeMae = "";
                        string numeroCPFFormatado = "";
                        string numeroCPF = e.Row.Cells[1].Text;
                        numeroCPF = numeroCPF.Replace(".", "").Replace("-", "");
                        numeroCPF = numeroCPF.PadLeft(11, '0');

                        numeroCPFFormatado = Util.Format.FormatString(numeroCPF, Util.Format.TypeString.CPF);

                        ((HyperLink)e.Row.Cells[0].FindControl("linkCPF")).Text = numeroCPFFormatado;
                        ((HyperLink)e.Row.Cells[0].FindControl("linkCPF")).NavigateUrl = "ConsultaWebRastreamentoPFPrata.aspx?PRODUTOPRECO=" + codigoProdutoPrecoPFPRATA + "&CPF=" + numeroCPF;

                        strDataNascimento = ((Label)e.Row.Cells[0].FindControl("lblDataNascimentoMorador")).Text;
                        
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

                        ((Label)e.Row.Cells[0].FindControl("lblDataNascimentoMorador")).Text = strDataNascimento;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "gridResult_RowDataBound", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));
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

                Negocios.Cadastral.WEB.RastreamentoMoradoresMesmoEndereco n = new Negocios.Cadastral.WEB.RastreamentoMoradoresMesmoEndereco();
                List<Entidades.Cadastral.ResponseMoradoresMesmoEndereco> listRet = new List<Entidades.Cadastral.ResponseMoradoresMesmoEndereco>();
                Entidades.Cadastral.FiltroPesquisaMoradoresMesmoEndereco filtro = new Entidades.Cadastral.FiltroPesquisaMoradoresMesmoEndereco();

                filtro.Cep = txtCEP.Text.ToUpper().Replace("-", "");

                if (ddlUF.SelectedItem.Text == "SELECIONE...")
                { filtro.UF = hdnUfEstado.Value.Trim(); }
                else
                { filtro.UF = ddlUF.SelectedItem.Text.Split(new Char[] { '-' })[0].ToString().Trim(); }

                if (ddlCidade.SelectedItem.Text == "SELECIONE...")
                { filtro.Cidade = hdnCidade.Value.Trim(); }
                else
                { filtro.Cidade = Util.Format.RemoverAcentos(ddlCidade.SelectedItem.Text); }

                string strLogradouro = Util.Format.RemoverAcentos(txtLogradouro.Text);
                strLogradouro = strLogradouro.Substring(strLogradouro.IndexOf(" "), strLogradouro.Length - strLogradouro.IndexOf(" ")).Trim();

                filtro.Bairro = Util.Format.RemoverAcentos(txtBairro.Text);
                filtro.Logradouro = strLogradouro;
                filtro.Numero = txtNumero.Text;

                listRet = n.PesquisaMoradoresMesmoEndereco(filtro);

                hdnUfEstado.Value = "";
                hdnCidade.Value = "";

                if (listRet != null)
                {
                    divResultado.Visible = true;

                    if (listRet.Count > 0)
                    {
                        gridResultMoradores.DataSource = listRet;
                        gridResultMoradores.DataBind();

                        Util.Format.OcultaColunaEspecificaGrid(ref  gridResultMoradores, 1);
                    }
                    else
                    {
                        gridResultMoradores.DataSource = null;
                        gridResultMoradores.EmptyDataText = "NENHUM REGISTRO ENCONTRADO.";
                        gridResultMoradores.DataBind();
                    }


                    //Transformando o Retorno em XML para gravar no banco
                    var xns = new XmlSerializerNamespaces();
                    xns.Add(string.Empty, string.Empty);
                    var xs = new XmlSerializer(listRet.GetType());
                    var xml = new StringWriter();
                    xs.Serialize(xml, listRet, xns);

                    HTMLRetornado = xml.ToString();

                    string parametrosPesquisado = ""; 
                    string valorParametrosPesquisado = "";

                    if (!filtro.Cep.Trim().Equals(""))
                    { 
                        parametrosPesquisado = "CEP | ";
                        valorParametrosPesquisado = filtro.Cep + " | ";
                    }

                    parametrosPesquisado += "UF | CIDADE | BAIRRO | LOGRADOURO | NUMERO";
                    valorParametrosPesquisado += ddlUF.SelectedItem.Text + " | " + ddlCidade.SelectedItem.Text + " | " + txtBairro.Text + " | " + txtLogradouro.Text + " | " + txtNumero.Text;

                    string NomeInternoProduto = "WEB RASTREAMENTO MORADORES MESMO ENDERECO";

                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", codigoItemProduto, "", valorParametrosPesquisado, parametrosPesquisado);
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

                    string parametrosPesquisado = ""; 
                    string valorParametrosPesquisado = "";

                    if (!filtro.Cep.Trim().Equals(""))
                    {
                        parametrosPesquisado = "CEP | ";
                        valorParametrosPesquisado = filtro.Cep + " | ";
                    }

                    parametrosPesquisado += "UF | CIDADE | BAIRRO | LOGRADOURO | NUMERO";
                    valorParametrosPesquisado += ddlUF.SelectedItem.Text + " | " + ddlCidade.SelectedItem.Text + " | " + txtBairro.Text + " | " + txtLogradouro.Text + " | " + txtNumero.Text;


                    string NomeInternoProduto = "WEB RASTREAMENTO MORADORES MESMO ENDERECO";

                    Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", codigoItemProduto, "", valorParametrosPesquisado, parametrosPesquisado);
                    SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "NENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");

                    lblDataConsulta.Text = DataBR.ToString("dd/MM/yyyy") + " às " + DataBR.ToString("HH:mm");
                    lblNumeroConsulta.Text = hist.IdHistoricoConsulta.ToString().PadLeft(5, '0');

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "<script>alert('Veículo não encontrado.')</script>", false);
                }
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "Consultar", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));
                throw ex;
            }
        }

        private bool ExibirResultadoRedirect()
        {
            try
            {
                bool ProdutoPrecoEncontrado = false;

                bool CEPEncontrado = false;
                bool UFEncontrado = false;
                bool CidadeEncontrado = false;
                bool BairroEncontrado = false;
                bool LogradouroEncontrado = false;
                bool NumeroEncontrado = false;

                string CEPQueryString = "";
                string UFQueryString = "";
                string CidadeQueryString = "";
                string BairroQueryString = "";
                string LogradouroQueryString = "";
                string NumeroQueryString = "";

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
                        case "CEP":
                            {
                                CEPQueryString = Request.QueryString["CEP"].ToString();
                                CEPEncontrado = true;

                                break;
                            }
                        case "UF":
                            {
                                UFQueryString = Request.QueryString["UF"].ToString();
                                UFEncontrado = true;

                                break;
                            }
                        case "CIDADE":
                            {
                                CidadeQueryString = Request.QueryString["CIDADE"].ToString();
                                CidadeEncontrado = true;

                                break;
                            }
                        case "BAIRRO":
                            {
                                BairroQueryString = Request.QueryString["BAIRRO"].ToString();
                                BairroEncontrado = true;

                                break;
                            }
                        case "LOGRADOURO":
                            {
                                LogradouroQueryString = Request.QueryString["LOGRADOURO"].ToString();
                                LogradouroEncontrado = true;

                                break;
                            }
                        case "NUMERO":
                            {
                                NumeroQueryString = Request.QueryString["NUMERO"].ToString();
                                NumeroEncontrado = true;

                                break;
                            }
                    }
                }

                if (ProdutoPrecoEncontrado && CEPEncontrado && NumeroEncontrado)
                {
                    txtCEP.Text = Util.Format.FormatString(CEPQueryString, Util.Format.TypeString.CEP).Replace(".", "");
                    txtNumero.Text = NumeroQueryString;
                    ddlUF.SelectedItem.Text = UFQueryString;
                    ddlCidade.SelectedItem.Text = CidadeQueryString;
                    txtBairro.Text = BairroQueryString;
                    txtLogradouro.Text = LogradouroQueryString;

                    Consultar();

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));

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
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "ConsultaWebRastreamentoMoradoresMesmoEndereco", HttpContext.Current.Server.MapPath(diretorioLog));
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