using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;
using Microsoft.VisualBasic;

namespace DNA.WebServices.Online
{
    /// <summary>
    /// Summary description for WSIntegracaoDNAOnline
    /// </summary>
    [WebService(Description = "WebService DNAMais", Namespace = "http://www.dnamais.com.br/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSIntegracaoDNAOnline : System.Web.Services.WebService
    {
        string diretorioLog = "../../../";
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        //[return: XmlRoot(ElementName = "testeteste")]
        //[return: XmlElement(Namespace = "http://www.cohowinery.com2", ElementName = "BookOrder2")
        [WebMethod(Description = "Retorna os dados cadastrais do CPF informado", EnableSession = true)]
        public Entidades.Cadastral.ResponsePFPrata RastreamentoPFPrata(string loginUsuario, string senhaUsuario, string numeroCPF)
        {
            try
            {
                //Limpando pontos, barras e espaços do CPF
                numeroCPF = numeroCPF.Replace(".", "").Replace(".", "").Replace("-", "").Replace("/", "");
                numeroCPF = numeroCPF.Trim();
                numeroCPF = numeroCPF.PadLeft(11, '0');

                Entidades.Cadastral.ResponsePFPrata retResponse = new Entidades.Cadastral.ResponsePFPrata();
                retResponse.ResponseStatus = new Entidades.Cadastral.ResponseStatus();

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "loginUsuario";
                    ResponseError.Message = "O login nao foi informado";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "senhaUsuario";
                    ResponseError.Message = "A senha nao foi informada";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (numeroCPF.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroCPF";
                    ResponseError.Message = "O CPF nao foi informado";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                //Validando CPF
                if (!numeroCPF.Equals("00000000000") && (!Util.Format.ValidaCPFCNPJ(numeroCPF, false) || numeroCPF.Length != 11))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroCPF";
                    ResponseError.Message = "CPF Invalido";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (retResponse.ResponseStatus.Errors != null && retResponse.ResponseStatus.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE RASTREAMENTO PF PRATA";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.Controle.Codigo = "401";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "";
                        ResponseError.Message = "Voce nao tem permissao para utilizar este produto";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);

                        return retResponse;
                    }
                    else
                    {
                        if (numeroCPF.Trim().Equals("00000000000"))
                        { return TestesDeIntegracaoPF(); }
                        else
                        {
                            Negocios.Cadastral.WS.RastreamentoPFPrata n = new Negocios.Cadastral.WS.RastreamentoPFPrata();

                            Entidades.Cadastral.ResponsePFPrata retorno = new Entidades.Cadastral.ResponsePFPrata();

                            retorno = n.PesquisaPFPrata(numeroCPF);

                            if (retorno.DadosCadastrais.Nome.Trim().Equals("") && retorno.Emails.Count == 0 && retorno.Enderecos.Count == 0 && retorno.Telefones.Count == 0 && retorno.Vinculos.Count == 0)
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", numeroCPF, "CPF");

                                retorno.Controle.Codigo = "204";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "No Content";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", numeroCPF, "CPF");

                                retorno.Controle.Codigo = "200";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "OK";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }

                            

                            return retorno;
                        }
                    }
                }
                else
                {
                    retResponse.Controle.Codigo = "401";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "";
                    ResponseError.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod(Description = "Retorna os dados cadastrais do CNPJ informado", EnableSession = true)]
        public Entidades.Cadastral.ResponsePJPrata RastreamentoPJPrata(string loginUsuario, string senhaUsuario, string numeroCNPJ)
        {
            try
            {
                numeroCNPJ = numeroCNPJ.Replace(".", "").Replace(".", "").Replace("-", "").Replace("/", "");
                numeroCNPJ = numeroCNPJ.Trim();
                numeroCNPJ = numeroCNPJ.PadLeft(14, '0');

                Entidades.Cadastral.ResponsePJPrata retResponse = new Entidades.Cadastral.ResponsePJPrata();
                retResponse.ResponseStatus = new Entidades.Cadastral.ResponseStatus();

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "loginUsuario";
                    ResponseError.Message = "O login nao foi informado";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "senhaUsuario";
                    ResponseError.Message = "A senha nao foi informada";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (numeroCNPJ.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroCNPJ";
                    ResponseError.Message = "O CNPJ nao foi informado";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                //Validando CNPJ
                if (!numeroCNPJ.Equals("00000000000000") && (!Util.Format.ValidaCPFCNPJ(numeroCNPJ, false) || numeroCNPJ.Length != 14))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroCNPJ";
                    ResponseError.Message = "CNPJ Invalido";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (retResponse.ResponseStatus.Errors != null && retResponse.ResponseStatus.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE RASTREAMENTO PJ PRATA";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.Controle.Codigo = "401";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "";
                        ResponseError.Message = "Voce nao tem permissao para utilizar este produto";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);

                        return retResponse;
                    }
                    else
                    {
                        if (numeroCNPJ.Trim().Equals("00000000000000"))
                        { return TestesDeIntegracaoPJ(); }
                        else
                        {
                            Negocios.Cadastral.WS.RastreamentoPJPrata n = new Negocios.Cadastral.WS.RastreamentoPJPrata();

                            Entidades.Cadastral.ResponsePJPrata retorno = new Entidades.Cadastral.ResponsePJPrata();

                            retorno = n.PesquisaPJPrata(numeroCNPJ);

                            if (retorno.CNAE.Count == 0 && retorno.Enderecos.Count == 0 && retorno.Telefones.Count == 0)
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", numeroCNPJ, "CNPJ");

                                retorno.Controle.Codigo = "204";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "No Content";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", numeroCNPJ, "CNPJ");

                                retorno.Controle.Codigo = "200";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "OK";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }

                            return retorno;
                        }
                    }
                }
                else
                {
                    retResponse.Controle.Codigo = "401";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "";
                    ResponseError.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [return: XmlRoot(ElementName = "ResponseSearchTelefonePF")]
        [WebMethod(Description = "Retorna os dados do proprietário do telefone informado", EnableSession = true)]
        public Entidades.Cadastral.ResponseSearchTelefonePF_WS RastreamentoSearchTelefonePF(string loginUsuario, string senhaUsuario, string numeroDDD, string numeroTelefone)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchTelefonePF_WS retResponse = new Entidades.Cadastral.ResponseSearchTelefonePF_WS();
                retResponse.ResponseStatus = new Entidades.Cadastral.ResponseStatus();

                numeroTelefone = numeroTelefone.Replace(".", "").Replace("-", "");
                numeroTelefone = numeroTelefone.Trim();

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "loginUsuario";
                    ResponseError.Message = "O LOGIN NAO FOI INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "senhaUsuario";
                    ResponseError.Message = "A SENHA NAO FOI INFORMADA";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (numeroDDD.Trim().Equals(""))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroDDD";
                    ResponseError.Message = "O DDD DEVE SER INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (numeroDDD.Trim().Length > 2)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroDDD";
                    ResponseError.Message = "O DDD DEVE CONTER APENAS 02 DIGITOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (numeroTelefone.Trim().Equals(""))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroTelefone";
                    ResponseError.Message = "INFORME O NUMERO DE TELEFONE QUE DESEJA PESQUISAR";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (numeroTelefone.Trim().Length > 9)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroTelefone";
                    ResponseError.Message = "QUANTIDADE DE DIGITOS DO TELEFONE SUPERIOR A PERMITIDA (LIMITE DE DIGITOS: 9 DIGITOS).";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }
                

                if (retResponse.ResponseStatus.Errors != null && retResponse.ResponseStatus.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE SEARCH TELEFONE PF";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.Controle.Codigo = "401";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "";
                        ResponseError.Message = "VOCE NAO TEM PERMISSAO PARA UTILIZAR ESTE PRODUTO";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);

                        return retResponse;
                    }
                    else
                    {
                        //if (numeroCPF.Trim().Equals("00000000000"))
                        if (0 == 1)
                        { return null; } //TestesDeIntegracaoPF(); }
                        else
                        {
                            Negocios.Cadastral.WS.RastreamentoSearchTelefonePF n = new Negocios.Cadastral.WS.RastreamentoSearchTelefonePF();
                            Entidades.Cadastral.ResponseSearchTelefonePF_WS retorno = new Entidades.Cadastral.ResponseSearchTelefonePF_WS();
                            Entidades.Cadastral.FiltroPesquisaSearchTelefonePF filtro = new Entidades.Cadastral.FiltroPesquisaSearchTelefonePF();

                            filtro.DDD = numeroDDD.Trim();
                            filtro.NumeroTel = numeroTelefone.Trim();

                            retorno = n.PesquisaSearchTelefonePF(filtro);

                            string ParametrosUtilizadosPesquisa = "TELEFONE: ";
                            string ValorParametrosUtilizadosPesquisa = "(" + numeroDDD + ") " + numeroTelefone;


                            if (retorno != null)
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", ValorParametrosUtilizadosPesquisa, ParametrosUtilizadosPesquisa);

                                retorno.Controle.Codigo = "200";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "OK";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", ValorParametrosUtilizadosPesquisa, ParametrosUtilizadosPesquisa);

                                retorno = new Entidades.Cadastral.ResponseSearchTelefonePF_WS();
                                retorno.Controle.Codigo = "204";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "No Content";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "NENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");
                            }

                            return retorno;
                        }
                    }
                }
                else
                {
                    retResponse.Controle.Codigo = "401";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "";
                    ResponseError.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }

        [return: XmlRoot(ElementName = "ResponseSearchTelefonePJ")]
        [WebMethod(Description = "Retorna os dados da empresa proprietária do telefone informado", EnableSession = true)]
        public Entidades.Cadastral.ResponseSearchTelefonePJ_WS RastreamentoSearchTelefonePJ(string loginUsuario, string senhaUsuario, string numeroDDD, string numeroTelefone)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchTelefonePJ_WS retResponse = new Entidades.Cadastral.ResponseSearchTelefonePJ_WS();
                retResponse.ResponseStatus = new Entidades.Cadastral.ResponseStatus();

                numeroTelefone = numeroTelefone.Replace(".", "").Replace("-", "");
                numeroTelefone = numeroTelefone.Trim();

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "loginUsuario";
                    ResponseError.Message = "O LOGIN NAO FOI INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "senhaUsuario";
                    ResponseError.Message = "A SENHA NAO FOI INFORMADA";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (numeroDDD.Trim().Equals(""))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroDDD";
                    ResponseError.Message = "O DDD DEVE SER INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (numeroDDD.Trim().Length > 2)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroDDD";
                    ResponseError.Message = "O DDD DEVE CONTER APENAS 02 DIGITOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (numeroTelefone.Trim().Equals(""))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroTelefone";
                    ResponseError.Message = "INFORME O NUMERO DE TELEFONE QUE DESEJA PESQUISAR";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (numeroTelefone.Trim().Length > 9)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroTelefone";
                    ResponseError.Message = "QUANTIDADE DE DIGITOS DO TELEFONE SUPERIOR A PERMITIDA (LIMITE DE DIGITOS: 9 DIGITOS).";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (!Information.IsNumeric(numeroDDD.Trim()))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroDDD";
                    ResponseError.Message = "DIGITE APENAS NUMEROS NO CAMPO numeroDDD E SO SERAO ACEITOS DOIS DIGITOS.";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (!Information.IsNumeric(numeroTelefone.Trim()))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "numeroTelefone";
                    ResponseError.Message = "DIGITE APENAS NUMEROS NO CAMPO numeroTelefone.";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }


                if (retResponse.ResponseStatus.Errors != null && retResponse.ResponseStatus.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE SEARCH TELEFONE PJ";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.Controle.Codigo = "401";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "";
                        ResponseError.Message = "VOCE NAO TEM PERMISSAO PARA UTILIZAR ESTE PRODUTO";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);

                        return retResponse;
                    }
                    else
                    {
                        //if (numeroCPF.Trim().Equals("00000000000"))
                        if (0 == 1)
                        { return null; } //TestesDeIntegracaoPF(); }
                        else
                        {
                            Negocios.Cadastral.WS.RastreamentoSearchTelefonePJ n = new Negocios.Cadastral.WS.RastreamentoSearchTelefonePJ();
                            Entidades.Cadastral.ResponseSearchTelefonePJ_WS retorno = new Entidades.Cadastral.ResponseSearchTelefonePJ_WS();
                            Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ filtro = new Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ();

                            filtro.DDD = numeroDDD.Trim();
                            filtro.NumeroTel = numeroTelefone.Trim();

                            retorno = n.PesquisaSearchTelefonePF(filtro);

                            string ParametrosUtilizadosPesquisa = "TELEFONE: ";
                            string ValorParametrosUtilizadosPesquisa = "(" + numeroDDD + ") " + numeroTelefone;


                            if (retorno != null)
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", ValorParametrosUtilizadosPesquisa, ParametrosUtilizadosPesquisa);

                                retorno.Controle.Codigo = "200";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "OK";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", ValorParametrosUtilizadosPesquisa, ParametrosUtilizadosPesquisa);

                                retorno = new Entidades.Cadastral.ResponseSearchTelefonePJ_WS();
                                retorno.Controle.Codigo = "204";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "No Content";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "NENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");
                            }

                            return retorno;
                        }
                    }
                }
                else
                {
                    retResponse.Controle.Codigo = "401";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "";
                    ResponseError.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [return: XmlRoot(ElementName = "ResponseSearchPF")]
        [WebMethod(Description = "Retorna os dados cadastrais dos dados informados no filtro", EnableSession = true)]
        public Entidades.Cadastral.ResponseSearchPF_WS RastreamentoSearchPF(string loginUsuario, string senhaUsuario, string nomeCompleto, 
                                                                            string UF, string nomeMunicipio, string dataNascimento, string nomeMae)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchPF_WS retResponse = new Entidades.Cadastral.ResponseSearchPF_WS();
                retResponse.ResponseStatus = new Entidades.Cadastral.ResponseStatus();

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "loginUsuario";
                    ResponseError.Message = "O LOGIN NAO FOI INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "senhaUsuario";
                    ResponseError.Message = "A SENHA NAO FOI INFORMADA";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (nomeCompleto.Trim().Length == 0 || nomeCompleto.Trim().Split(new Char[] { ' ' }).Count() < 2)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "nomeCompleto";
                    ResponseError.Message = "O NOME COMPLETO DEVE SER INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }

                if (UF.Trim().Equals("") && nomeMunicipio.Trim().Equals("") && dataNascimento.Trim().Equals("") && nomeMae.Trim().Equals(""))
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "UF, MUNICIPIO, DATA NASCIMENTO OU NOME DA MAE";
                    ResponseError.Message = "PELO MENOS A DATA DE NASCIMENTO, NOME DA MAE OU UF+MUNICIPIO DEVEM SER INFORMADOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);
                }
                else
                {
                    if (!UF.Trim().Equals("") &&
                        !UF.Trim().Equals("SP") && !UF.Trim().Equals("RJ") && !UF.Trim().Equals("AC") && !UF.Trim().Equals("AL") &&
                        !UF.Trim().Equals("AM") && !UF.Trim().Equals("AP") && !UF.Trim().Equals("BA") && !UF.Trim().Equals("CE") &&
                        !UF.Trim().Equals("DF") && !UF.Trim().Equals("ES") && !UF.Trim().Equals("GO") && !UF.Trim().Equals("MA") &&
                        !UF.Trim().Equals("MG") && !UF.Trim().Equals("MS") && !UF.Trim().Equals("MT") && !UF.Trim().Equals("PA") &&
                        !UF.Trim().Equals("PB") && !UF.Trim().Equals("PE") && !UF.Trim().Equals("PI") && !UF.Trim().Equals("PR") &&
                        !UF.Trim().Equals("RN") && !UF.Trim().Equals("RO") && !UF.Trim().Equals("RR") && !UF.Trim().Equals("RS") &&
                        !UF.Trim().Equals("SC") && !UF.Trim().Equals("SE") && !UF.Trim().Equals("TO"))
                    {
                        retResponse.Controle.Codigo = "400";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "UF";
                        ResponseError.Message = "A UF INFORMADA É INVÁLIDA";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);
                    }

                    if (!UF.Trim().Equals("") && nomeMunicipio.Trim().Equals(""))
                    {
                        retResponse.Controle.Codigo = "400";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "idMunicipio";
                        ResponseError.Message = "O MUNICIPIO INFORMADO É INVÁLIDO";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);
                    }

                    if (!dataNascimento.Trim().Equals(""))
                    {
                        try
                        {
                            var validaData = DateTime.Parse(dataNascimento);
                        }
                        catch 
                        {
                            retResponse.Controle.Codigo = "400";
                            retResponse.Controle.DataHora = DataBR.ToString();
                            retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                            retResponse.Controle.Protocolo = "";

                            retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                            retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                            retResponse.ResponseStatus.StackTrace = "";

                            Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                            ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                            ResponseStatus.Message = retResponse.ResponseStatus.Message;

                            Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                            if (retResponse.ResponseStatus.Errors == null)
                            { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                            ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                            ResponseError.FieldName = "dataNascimento";
                            ResponseError.Message = "A DATA INFORMADA É INVÁLIDA";

                            retResponse.ResponseStatus.Errors.Add(ResponseError);
                        }
                    }
                }

                if (retResponse.ResponseStatus.Errors != null && retResponse.ResponseStatus.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE RASTREAMENTO SEARCH PF";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.Controle.Codigo = "401";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "";
                        ResponseError.Message = "VOCE NAO TEM PERMISSAO PARA UTILIZAR ESTE PRODUTO";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);

                        return retResponse;
                    }
                    else
                    {
                        //if (numeroCPF.Trim().Equals("00000000000"))
                        if(0==1)
                        { return null;} //TestesDeIntegracaoPF(); }
                        else
                        {
                            Negocios.Cadastral.WS.RastreamentoSearchPF n = new Negocios.Cadastral.WS.RastreamentoSearchPF();
                            Entidades.Cadastral.ResponseSearchPF_WS retorno = new Entidades.Cadastral.ResponseSearchPF_WS();
                            Entidades.Cadastral.FiltroPesquisaSearchPF filtro = new Entidades.Cadastral.FiltroPesquisaSearchPF();

                            filtro.Nome = nomeCompleto.ToUpper();
                            filtro.UF = UF;
                            filtro.Cidade = Util.Format.RemoverAcentos(nomeMunicipio);
                            filtro.DataNascimento = dataNascimento;
                            filtro.NomeMae = nomeMae;

                            retorno = n.PesquisaSearchPF(filtro);

                            string ParametrosUtilizadosPesquisa = "";
                            string ValorParametrosUtilizadosPesquisa = "";

                            if (nomeCompleto.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa = "NOME";
                                ValorParametrosUtilizadosPesquisa = nomeCompleto;
                            }

                            if (UF.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa += " | UF";
                                ValorParametrosUtilizadosPesquisa += " |" + UF;
                            }

                            if (nomeMunicipio.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa += " | MUNICIPIO";
                                ValorParametrosUtilizadosPesquisa += " |" + nomeMunicipio;
                            }

                            if (dataNascimento.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa += " | DATA DE NACIMANETO";
                                ValorParametrosUtilizadosPesquisa += " |" + dataNascimento;
                            }

                            if (nomeMae.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa += " | NOME DA MAE";
                                ValorParametrosUtilizadosPesquisa += " |" + nomeMae;
                            }

                            if (retorno != null)
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", ValorParametrosUtilizadosPesquisa, ParametrosUtilizadosPesquisa);

                                retorno.Controle.Codigo = "200";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "OK";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", ValorParametrosUtilizadosPesquisa, ParametrosUtilizadosPesquisa);

                                retorno = new Entidades.Cadastral.ResponseSearchPF_WS();
                                retorno.Controle.Codigo = "204";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "No Content";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "NENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");
                            }

                            return retorno;
                        }
                    }
                }
                else
                {
                    retResponse.Controle.Codigo = "401";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "";
                    ResponseError.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [return: XmlRoot(ElementName = "ResponseSearchPJ")]
        [WebMethod(Description = "Retorna os dados cadastrais dos dados informados no filtro", EnableSession = true)]
        public Entidades.Cadastral.ResponseSearchPJ_WS RastreamentoSearchPJ(string loginUsuario, string senhaUsuario, string nomeEmpresa, string UF, string nomeMunicipio)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchPJ_WS retResponse = new Entidades.Cadastral.ResponseSearchPJ_WS();
                retResponse.ResponseStatus = new Entidades.Cadastral.ResponseStatus();

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "loginUsuario";
                    ResponseError.Message = "O LOGIN NAO FOI INFORMADO";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.Controle.Codigo = "400";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 400 Bad Request";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "senhaUsuario";
                    ResponseError.Message = "A SENHA NAO FOI INFORMADA";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                }

                if (retResponse.ResponseStatus.Errors != null && retResponse.ResponseStatus.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE RASTREAMENTO SEARCH PJ";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.Controle.Codigo = "401";
                        retResponse.Controle.DataHora = DataBR.ToString();
                        retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                        retResponse.Controle.Protocolo = "";

                        retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                        retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                        retResponse.ResponseStatus.StackTrace = "";

                        Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                        ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseStatus.Message = retResponse.ResponseStatus.Message;

                        Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                        if (retResponse.ResponseStatus.Errors == null)
                        { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                        ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                        ResponseError.FieldName = "";
                        ResponseError.Message = "VOCE NAO TEM PERMISSAO PARA UTILIZAR ESTE PRODUTO";

                        retResponse.ResponseStatus.Errors.Add(ResponseError);

                        return retResponse;
                    }
                    else
                    {
                        //if (numeroCPF.Trim().Equals("00000000000"))
                        if (0 == 1)
                        { return null; } //TestesDeIntegracaoPF(); }
                        else
                        {
                            Negocios.Cadastral.WS.RastreamentoSearchPJ n = new Negocios.Cadastral.WS.RastreamentoSearchPJ();
                            Entidades.Cadastral.ResponseSearchPJ_WS retorno = new Entidades.Cadastral.ResponseSearchPJ_WS();
                            Entidades.Cadastral.FiltroPesquisaSearchPJ filtro = new Entidades.Cadastral.FiltroPesquisaSearchPJ();

                            filtro.Nome = nomeEmpresa.ToUpper();
                            filtro.UF = UF;
                            filtro.Cidade = Util.Format.RemoverAcentos(nomeMunicipio);

                            retorno = n.PesquisaSearchPF(filtro);

                            string ParametrosUtilizadosPesquisa = "";
                            string ValorParametrosUtilizadosPesquisa = "";

                            if (nomeEmpresa.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa = "NOME DA EMPRESA";
                                ValorParametrosUtilizadosPesquisa = nomeEmpresa;
                            }

                            if (UF.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa += " | UF";
                                ValorParametrosUtilizadosPesquisa += " |" + UF;
                            }

                            if (nomeMunicipio.Trim().Length > 0)
                            {
                                ParametrosUtilizadosPesquisa += " | NOME DO MUNICIPIO";
                                ValorParametrosUtilizadosPesquisa += " |" + nomeMunicipio;
                            }

                            if (retorno != null)
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", idProdutoPreco, "", ParametrosUtilizadosPesquisa, ValorParametrosUtilizadosPesquisa);

                                retorno.Controle.Codigo = "200";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "OK";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("S", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {
                                int idProdutoPreco = listProd.FirstOrDefault().IdPrecoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", idProdutoPreco, "", ParametrosUtilizadosPesquisa, ValorParametrosUtilizadosPesquisa);

                                retorno.Controle.Codigo = "204";
                                retorno.Controle.DataHora = DataBR.ToString();
                                retorno.Controle.Mensagem = "No Content";
                                retorno.Controle.Protocolo = hist.ProtocoloRetorno;

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, "NENHUM REGISTRO ENCONTRADO.", NomeInternoProduto, "DNA");
                            }

                            return retorno;
                        }
                    }
                }
                else
                {
                    retResponse.Controle.Codigo = "401";
                    retResponse.Controle.DataHora = DataBR.ToString();
                    retResponse.Controle.Mensagem = "HTTP/1.1 401 Unauthorized";
                    retResponse.Controle.Protocolo = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    retResponse.ResponseStatus.ErrorCode = retResponse.Controle.Codigo;
                    retResponse.ResponseStatus.Message = retResponse.Controle.Mensagem;
                    retResponse.ResponseStatus.StackTrace = "";

                    Entidades.Cadastral.ResponseStatus ResponseStatus = new Entidades.Cadastral.ResponseStatus();
                    ResponseStatus.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseStatus.Message = retResponse.ResponseStatus.Message;

                    Entidades.Cadastral.ResponseError ResponseError = new Entidades.Cadastral.ResponseError();

                    if (retResponse.ResponseStatus.Errors == null)
                    { retResponse.ResponseStatus.Errors = new List<Entidades.Cadastral.ResponseError>(); }

                    ResponseError.ErrorCode = retResponse.ResponseStatus.ErrorCode.ToString();
                    ResponseError.FieldName = "";
                    ResponseError.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS";

                    retResponse.ResponseStatus.Errors.Add(ResponseError);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Entidades.Cadastral.ResponsePFPrata TestesDeIntegracaoPF()
        {
            Entidades.Cadastral.ResponsePFPrata ret = new Entidades.Cadastral.ResponsePFPrata();

            ret.Controle.Codigo = "200";
            ret.Controle.DataHora = DateTime.Now.ToString();
            ret.Controle.Mensagem = "OK";
            ret.Controle.Protocolo = Guid.NewGuid().ToString();

            ret.DadosCadastrais.CPF = "00000000000";
            ret.DadosCadastrais.ClasseSocial = "CLASSE B";
            ret.DadosCadastrais.DataNascimento = "23/03/1980 00:00:00";
            ret.DadosCadastrais.Escolaridade = "EDUCACAO SUPERIOR COMPLETA.";
            ret.DadosCadastrais.EstadoCivil = "0";
            ret.DadosCadastrais.Idade = "35";
            ret.DadosCadastrais.Nome = "MARIA DA SILVA";
            ret.DadosCadastrais.NomeMae = "AURENI MARIA SIMOES FERREIRA";
            ret.DadosCadastrais.RG = "123456789";
            ret.DadosCadastrais.RendaEstimada = "DE NOVE A DEZ SALARIOS MINIMOS";
            ret.DadosCadastrais.Sexo = "M";
            ret.DadosCadastrais.Signo = "ÁRIES";
            ret.DadosCadastrais.StatusCPF = "REGULAR";
            ret.DadosCadastrais.TituloEleitoral = "1234567891234";
            ret.DadosCadastrais.Obito = "NAO";
            ret.DadosCadastrais.DataObito = "";

            ret.Emails.Add(new Entidades.Cadastral.Email() { Endereco = "email1@aol.com.br" });
            ret.Emails.Add(new Entidades.Cadastral.Email() { Endereco = "email2@americanas.com.br" });
            ret.Emails.Add(new Entidades.Cadastral.Email() { Endereco = "email3@globo.com" });

            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "JARDIM SAO PAULO", CEP = "01234567", Cidade = "SAO PAULO", Complemento = "Casa 02", Logradouro = "RUA JORGE GOUVEIA", Numero = "123", UF = "SP" });
            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "JARDIM PRIMAVERA", CEP = "12345678", Cidade = "DIADEMA", Complemento = "AP 1 B2", Logradouro = "AV CABRAL XX", Numero = "10", UF = "SP" });
            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "PARQUE SAO JUDAS TADEU", CEP = "23456789", Cidade = "ITU", Complemento = "", Logradouro = "RUA PRACA DA ARVORE", Numero = "86", UF = "SP" });
            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "VILA CARIOCA", CEP = "34567890", Cidade = "SAO BERNARDO DO CAMPO", Complemento = "Casa 1", Logradouro = "BECO MARIA BONITA", Numero = "11203", UF = "SP" });

            ret.Telefones.Add(new Entidades.Cadastral.Telefone() { DDD = 11, Numero = 33335555 });
            ret.Telefones.Add(new Entidades.Cadastral.Telefone() { DDD = 13, Numero = 23556698 });
            ret.Telefones.Add(new Entidades.Cadastral.Telefone() { DDD = 11, Numero = 987156630 });

            return ret;
        }

        private Entidades.Cadastral.ResponsePJPrata TestesDeIntegracaoPJ()
        {
            Entidades.Cadastral.ResponsePJPrata ret = new Entidades.Cadastral.ResponsePJPrata();

            ret.Controle.Codigo = "200";
            ret.Controle.DataHora = DateTime.Now.ToString();
            ret.Controle.Mensagem = "OK";
            ret.Controle.Protocolo = Guid.NewGuid().ToString();

            ret.DadosCadastrais.CNPJ = "00000000000000";
            ret.DadosCadastrais.RazaoSocial = "DNA MARKETING SOLUTIONS LTDA - EPP";
            ret.DadosCadastrais.MatrizFilial = "MATRIZ";
            ret.DadosCadastrais.DataAbertura = "10/11/1997 00:00:00";
            ret.DadosCadastrais.NomeFantasia = "DNA+ MARKETING SOLUTIONS LTDA";
            ret.DadosCadastrais.NaturezaJuridica = "SOCIEDADE EMPRESARIA LIMITADA";
            ret.DadosCadastrais.SituacaoCadastral = "ATIVA";
            ret.DadosCadastrais.DataSituacaoDastral = "03/11/2015 00:00:00";

            ret.Telefones.Add(new Entidades.Cadastral.Telefone() { DDD = 11, Numero = 33335555 });
            ret.Telefones.Add(new Entidades.Cadastral.Telefone() { DDD = 13, Numero = 23556698 });
            ret.Telefones.Add(new Entidades.Cadastral.Telefone() { DDD = 11, Numero = 987156630 });

            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "JARDIM SAO PAULO", CEP = "01234567", Cidade = "SAO PAULO", Complemento = "Casa 02", Logradouro = "RUA JORGE GOUVEIA", Numero = "123", UF = "SP" });
            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "JARDIM PRIMAVERA", CEP = "12345678", Cidade = "DIADEMA", Complemento = "AP 1 B2", Logradouro = "AV CABRAL XX", Numero = "10", UF = "SP" });
            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "PARQUE SAO JUDAS TADEU", CEP = "23456789", Cidade = "ITU", Complemento = "", Logradouro = "RUA PRACA DA ARVORE", Numero = "86", UF = "SP" });
            ret.Enderecos.Add(new Entidades.Cadastral.Endereco() { Bairro = "VILA CARIOCA", CEP = "34567890", Cidade = "SAO BERNARDO DO CAMPO", Complemento = "Casa 1", Logradouro = "BECO MARIA BONITA", Numero = "11203", UF = "SP" });

            ret.CNAE.Add(new Entidades.Cadastral.CNAE() { Codigo = "8291100", ComercioServico = "1", Descricao = "ATIVIDADES DE COBRANCA E INFORMACOES CADASTRAIS", Flag = "", Grupo = "SERVICOS DE ESCRITORIO", Industria = "1", Ordem = "2", OrdemDescricao = "1" });
            ret.CNAE.Add(new Entidades.Cadastral.CNAE() { Codigo = "6311900", ComercioServico = "1", Descricao = "TRATAMENTO DE DADOS PROVEDORES DE SERVICOS DE APLICACAO E SERVICOS DE HOSPEDAGEM NA INTERNET", Flag = "", Grupo = "PRESTACAO DE SERVICOS DE INFORMACAO", Industria = "1", Ordem = "1", OrdemDescricao = "1" });

            return ret;
        }

        #region MÉTODOS DE AUTENTICAÇÃO

        private bool Autenticacao(string loginUsuario, string senhaUsuario)
        {
            try
            {
                if (Session.Count > 0)
                {
                    int VerificaSessios = 0;

                    for (int i = 0; i < Session.Count; i++)
                    {
                        switch (Session.Keys[i].ToString())
                        {
                            case "ws_siscom_login":
                                {
                                    VerificaSessios = 1;
                                    break;
                                }

                            case "ws_siscom_senha":
                                {
                                    VerificaSessios = 1;
                                    break;
                                }
                        }
                    }

                    if (VerificaSessios > 0)
                    {
                        if (Session["ws_siscom_login"].ToString().ToUpper().Equals(loginUsuario.ToUpper()) &&
                            Session["ws_siscom_senha"].ToString().ToUpper().Equals(senhaUsuario.ToUpper()))
                        { return true; }
                        else
                        { return ValidaUsuario(loginUsuario, senhaUsuario); }
                    }
                    else
                    { return ValidaUsuario(loginUsuario, senhaUsuario); }
                }
                else
                { return ValidaUsuario(loginUsuario, senhaUsuario); }

            }
            catch (Exception ex)
            { throw ex; }
        }

        private bool ValidaUsuario(string loginUsuario, string senhaUsuario)
        {
            try
            {
                Entidades.Usuario u = new Entidades.Usuario();
                List<Entidades.Usuario> lRetUser = new List<Entidades.Usuario>();
                Negocios.Cadastro.Usuarios n = new Negocios.Cadastro.Usuarios();

                u.LoginUsuario = loginUsuario.Trim();
                u.SenhaUsuario = System.Security.Encryption(senhaUsuario.Trim());

                lRetUser = n.Listar(u);

                if (lRetUser.Count > 0 && lRetUser.FirstOrDefault().FlagAtivo.Equals("S"))
                {
                    Session.Add("ws_dnaonline_acesso", lRetUser.FirstOrDefault());
                    Session.Add("ws_siscom_login", lRetUser.FirstOrDefault().LoginUsuario);
                    Session.Add("ws_siscom_senha", senhaUsuario);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

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
                hist.IdUsuarioConsulta = ((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario;
                hist.Observacao = Observacao;
                hist.FlagSucesso = pesquisaSucesso;
                hist.TipoFiltroUtilizadoPesquisa = tipoParametroUsadoPesquisa;
                hist.DataConsulta = DataBR;

                return n.Salvar(hist);
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "WSIntegracaoDNAOnline", HttpContext.Current.Server.MapPath(diretorioLog));

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
                h.IdUsuarioConsulta = ((Entidades.Usuario)Session["ws_dnaonline_acesso"]).IdUsuario;
                h.HTMLRetornadoFornecedor = HTMLRetornado;
                h.FlagSucesso = pesquisaSucesso;
                h.DataConsulta = DataBR;

                n.SalvarHistoricoFornecedor(h);
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "WSIntegracaoDNAOnline", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "WSIntegracaoDNAOnline", HttpContext.Current.Server.MapPath(diretorioLog));
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
