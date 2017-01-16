using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.IO;

namespace DNA.WebServices.Online
{
    /// <summary>
    /// Summary description for SiscomWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SiscomWS : System.Web.Services.WebService
    {
        string diretorioLog = "../../../";
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        [WebMethod(EnableSession = true)]
        //[return: XmlRoot(ElementName = "testeteste")]
        public Entidades.Cadastral.SISCOM.Response PesquisaPF(string loginUsuario, string senhaUsuario, string numeroCPF)
        {
            try
            {
                //Limpando pontos, barras e espaços do CPF
                numeroCPF = numeroCPF.Replace(".","").Replace(".","").Replace("-","").Replace("/","");
                numeroCPF = numeroCPF.Trim();
                numeroCPF = numeroCPF.PadLeft(11, '0');

                Entidades.Cadastral.SISCOM.Response retResponse = new Entidades.Cadastral.SISCOM.Response();

                #region Parametros de Entrada

                retResponse.Input = new List<Entidades.Cadastral.SISCOM.InputItem>();
                //retResponse.Input.Add(new Entidades.Cadastral.SISCOM.InputItem() { Key = "loginUsuario", Value = loginUsuario });
                //retResponse.Input.Add(new Entidades.Cadastral.SISCOM.InputItem() { Key = "senhaUsuario", Value = senhaUsuario });
                retResponse.Input.Add(new Entidades.Cadastral.SISCOM.InputItem() { Key = "CPF", Value = numeroCPF });
                
                #endregion

                #region Controle de Erros

                if (loginUsuario.Trim().Length == 0)
                {
                    retResponse.ResponseError.ErrorCode = "400";
                    retResponse.ResponseError.Message = "HTTP/1.1 400 Bad Request";
                    retResponse.ResponseError.StackTrace = "";

                    Entidades.Cadastral.SISCOM.Error Erro = new Entidades.Cadastral.SISCOM.Error();
                    Erro.ErrorCode = "400";
                    Erro.FieldName = "loginUsuario";
                    Erro.Message = retResponse.ResponseError.Message;

                    if (retResponse.ResponseError.Errors == null)
                    { retResponse.ResponseError.Errors = new List<Entidades.Cadastral.SISCOM.Error>(); }

                    retResponse.ResponseError.Errors.Add(Erro);

                    retResponse.Status = new Entidades.Cadastral.SISCOM.Status();
                    retResponse.Status.Code = 400;
                    retResponse.Status.DateTime = DataBR;
                    retResponse.Status.Detail = "O login nao foi informado";
                    retResponse.Status.Message = Erro.Message;
                    retResponse.Status.Source = string.Empty;
                    retResponse.Status.Type = string.Empty; 

                }
                
                if (senhaUsuario.Trim().Length == 0)
                {
                    retResponse.ResponseError.ErrorCode = "400";
                    retResponse.ResponseError.Message = "HTTP/1.1 400 Bad Request";
                    retResponse.ResponseError.StackTrace = "";

                    Entidades.Cadastral.SISCOM.Error Erro = new Entidades.Cadastral.SISCOM.Error();
                    Erro.ErrorCode = "400";
                    Erro.FieldName = "senhaUsuario";
                    Erro.Message = retResponse.ResponseError.Message;

                    if (retResponse.ResponseError.Errors == null)
                    { retResponse.ResponseError.Errors = new List<Entidades.Cadastral.SISCOM.Error>(); }

                    retResponse.ResponseError.Errors.Add(Erro);

                    retResponse.Status = new Entidades.Cadastral.SISCOM.Status();
                    retResponse.Status.Code = 400;
                    retResponse.Status.DateTime = DataBR;
                    retResponse.Status.Detail = "A senha nao foi informada";
                    retResponse.Status.Message = Erro.Message;
                    retResponse.Status.Source = string.Empty;
                    retResponse.Status.Type = string.Empty; 

                }
                
                if (numeroCPF.Trim().Length == 0)
                {
                    retResponse.ResponseError.ErrorCode = "400";
                    retResponse.ResponseError.Message = "HTTP/1.1 400 Bad Request";
                    retResponse.ResponseError.StackTrace = "";

                    Entidades.Cadastral.SISCOM.Error Erro = new Entidades.Cadastral.SISCOM.Error();
                    Erro.ErrorCode = "400";
                    Erro.FieldName = "numeroCPF";
                    Erro.Message = retResponse.ResponseError.Message;

                    if (retResponse.ResponseError.Errors == null)
                    { retResponse.ResponseError.Errors = new List<Entidades.Cadastral.SISCOM.Error>(); }

                    retResponse.ResponseError.Errors.Add(Erro);

                    retResponse.Status = new Entidades.Cadastral.SISCOM.Status();
                    retResponse.Status.Code = 400;
                    retResponse.Status.DateTime = DataBR;
                    retResponse.Status.Detail = "O CPF nao foi informado";
                    retResponse.Status.Message = Erro.Message;
                    retResponse.Status.Source = string.Empty;
                    retResponse.Status.Type = string.Empty; 

                }

                //Validando CPF
                if (!numeroCPF.Equals("00000000000") && (!Util.Format.ValidaCPFCNPJ(numeroCPF, false) || numeroCPF.Length != 11))
                {
                    retResponse.ResponseError.ErrorCode = "400";
                    retResponse.ResponseError.Message = "HTTP/1.1 400 Bad Request";
                    retResponse.ResponseError.StackTrace = "";

                    Entidades.Cadastral.SISCOM.Error Erro = new Entidades.Cadastral.SISCOM.Error();
                    Erro.ErrorCode = "400";
                    Erro.FieldName = "numeroCPF";
                    Erro.Message = retResponse.ResponseError.Message;

                    if (retResponse.ResponseError.Errors == null)
                    { retResponse.ResponseError.Errors = new List<Entidades.Cadastral.SISCOM.Error>(); }

                    retResponse.ResponseError.Errors.Add(Erro);

                    retResponse.Status = new Entidades.Cadastral.SISCOM.Status();
                    retResponse.Status.Code = 400;
                    retResponse.Status.DateTime = DataBR;
                    retResponse.Status.Detail = "CPF Invalido";
                    retResponse.Status.Message = Erro.Message;
                    retResponse.Status.Source = string.Empty;
                    retResponse.Status.Type = string.Empty;

                }

                if (retResponse.ResponseError.Errors != null && retResponse.ResponseError.Errors.Count > 0)
                { return retResponse; }

                #endregion

                string NomeInternoProduto = "WEBSERVICE SISCOM PESQUISA PF";

                if (Autenticacao(loginUsuario, senhaUsuario))
                {     
                    //Verificando inicialmente se o usuário tem permissão ao produto 
                    List<Entidades.Produto> listProd = new List<Entidades.Produto>();
                    listProd = ListarProdutoSolicitadoByUsuario(((Entidades.Usuario)Session["ws_siscom_acesso"]).IdUsuario, NomeInternoProduto);

                    if (listProd == null || listProd.Count == 0)
                    {
                        retResponse.ResponseError.ErrorCode = "401";
                        retResponse.ResponseError.Message = "HTTP/1.1 401 Unauthorized";
                        retResponse.ResponseError.StackTrace = "";

                        Entidades.Cadastral.SISCOM.Error Erro = new Entidades.Cadastral.SISCOM.Error();
                        Erro.ErrorCode = "401";
                        Erro.FieldName = "";
                        Erro.Message = retResponse.ResponseError.Message;

                        if (retResponse.ResponseError.Errors == null)
                        { retResponse.ResponseError.Errors = new List<Entidades.Cadastral.SISCOM.Error>(); }

                        retResponse.ResponseError.Errors.Add(Erro);

                        retResponse.Status = new Entidades.Cadastral.SISCOM.Status();
                        retResponse.Status.Code = 401;
                        retResponse.Status.DateTime = DataBR;
                        retResponse.Status.Detail = "Voce nao tem permissao para utilizar este produto";
                        retResponse.Status.Message = Erro.Message;
                        retResponse.Status.Source = string.Empty;
                        retResponse.Status.Type = string.Empty;

                        return retResponse;
                    }
                    else
                    {
                        if (numeroCPF.Trim().Equals("00000000000"))
                        { return TestesDeIntegracao(); }
                        else
                        {
                            Negocios.Cadastral.WS.SISCOM n = new Negocios.Cadastral.WS.SISCOM();

                            Entidades.Cadastral.SISCOM.Response retorno = new Entidades.Cadastral.SISCOM.Response();

                            retorno = n.SISCOMPesquisaPF(numeroCPF);

                            if (retorno.Output.DadosCadastrais.Nome.Trim().Equals("") && retorno.Output.Emails.Count == 0 && retorno.Output.Enderecos.Count == 0 && retorno.Output.Telefones.Count == 0)
                            {
                                string codigoItemProduto = listProd.FirstOrDefault().CodigoProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("N", codigoItemProduto, "", numeroCPF, "CPF");

                                retorno.Input = retResponse.Input;
                                retorno.ResponseError = retResponse.ResponseError;
                                retorno.Status = new Entidades.Cadastral.SISCOM.Status();
                                retorno.Status.Code = 204;
                                retorno.Status.DateTime = DataBR;
                                retorno.Status.Detail = "SOLICITACAO PROCESSADA COM SUCESSO";
                                retorno.Status.Message = "No Content";
                                retorno.Status.Source = ((Entidades.Usuario)Session["ws_siscom_acesso"]).Cliente.NomeFantasia;
                                retorno.Status.Type = "Consulta Siscom PF";
                                retorno.Status.Protocol = hist.ProtocoloRetorno;

                                var xns = new XmlSerializerNamespaces();
                                xns.Add(string.Empty, string.Empty);
                                var xs = new XmlSerializer(retorno.GetType());
                                var xml = new StringWriter();
                                xs.Serialize(xml, retorno, xns);

                                SalvarHistoricoFornecedor("N", hist.IdHistoricoConsulta, xml.ToString(), NomeInternoProduto, "DNA");
                            }
                            else
                            {

                                string codigoItemProduto = listProd.FirstOrDefault().CodigoItemProduto;
                                Entidades.HistoricoPesquisa hist = SalvarHistoricoPesquisa("S", codigoItemProduto, "", numeroCPF, "CPF");

                                retorno.Input = retResponse.Input;
                                retorno.ResponseError = retResponse.ResponseError;
                                retorno.Status = new Entidades.Cadastral.SISCOM.Status();
                                retorno.Status.Code = 200;
                                retorno.Status.DateTime = DataBR;
                                retorno.Status.Detail = "SOLICITACAO PROCESSADA COM SUCESSO";
                                retorno.Status.Message = "OK";
                                retorno.Status.Source = ((Entidades.Usuario)Session["ws_siscom_acesso"]).Cliente.NomeFantasia;
                                retorno.Status.Type = "Consulta Siscom PF";
                                retorno.Status.Protocol = hist.ProtocoloRetorno;

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
                    retResponse.ResponseError.ErrorCode = "401";
                    retResponse.ResponseError.Message = "HTTP/1.1 401 Unauthorized";
                    retResponse.ResponseError.StackTrace = "";

                    Entidades.Cadastral.SISCOM.Error Erro = new Entidades.Cadastral.SISCOM.Error();
                    Erro.ErrorCode = "401";
                    Erro.FieldName = "";
                    Erro.Message = "O LOGIN OU A SENHA INSERIDOS ESTAO INCORRETOS.";

                    if (retResponse.ResponseError.Errors == null)
                    { retResponse.ResponseError.Errors = new List<Entidades.Cadastral.SISCOM.Error>(); }

                    retResponse.Status = new Entidades.Cadastral.SISCOM.Status();
                    retResponse.Status.Code = 401;
                    retResponse.Status.DateTime = DataBR;
                    retResponse.Status.Detail = string.Empty;
                    retResponse.Status.Message = Erro.Message;
                    retResponse.Status.Source = string.Empty;
                    retResponse.Status.Type = string.Empty; 

                    retResponse.ResponseError.Errors.Add(Erro);

                    return retResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Entidades.Cadastral.SISCOM.Response TestesDeIntegracao()
        {
            Entidades.Cadastral.SISCOM.Response ret = new Entidades.Cadastral.SISCOM.Response();

            ret.Input.Add(new Entidades.Cadastral.SISCOM.InputItem() { Key = "CPF", Value = "00000000000" });

            ret.Output.DadosCadastrais.CPF = "00000000000";
            ret.Output.DadosCadastrais.Nome = "MARIA DA SILVA";
            ret.Output.DadosCadastrais.RG = "123456789";

            ret.Output.Emails.Add(new Entidades.Cadastral.SISCOM.Email() { Endereco = "email1@aol.com.br" });
            ret.Output.Emails.Add(new Entidades.Cadastral.SISCOM.Email() { Endereco = "email2@americanas.com.br" });
            ret.Output.Emails.Add(new Entidades.Cadastral.SISCOM.Email() { Endereco = "email3@globo.com" });

            ret.Output.Enderecos.Add(new Entidades.Cadastral.SISCOM.Endereco() { Bairro = "JARDIM SAO PAULO", CEP = "01234567", Cidade = "SAO PAULO", Complemento = "Casa 02", Logradouro = "RUA JORGE GOUVEIA", Numero = "123", UF = "SP" });
            ret.Output.Enderecos.Add(new Entidades.Cadastral.SISCOM.Endereco() { Bairro = "JARDIM PRIMAVERA", CEP = "12345678", Cidade = "DIADEMA", Complemento = "AP 1 B2", Logradouro = "AV CABRAL XX", Numero = "10", UF = "SP" });
            ret.Output.Enderecos.Add(new Entidades.Cadastral.SISCOM.Endereco() { Bairro = "PARQUE SAO JUDAS TADEU", CEP = "23456789", Cidade = "ITU", Complemento = "", Logradouro = "RUA PRACA DA ARVORE", Numero = "86", UF = "SP" });
            ret.Output.Enderecos.Add(new Entidades.Cadastral.SISCOM.Endereco() { Bairro = "VILA CARIOCA", CEP = "34567890", Cidade = "SAO BERNARDO DO CAMPO", Complemento = "Casa 1", Logradouro = "BECO MARIA BONITA", Numero = "11203", UF = "SP" });

            ret.Output.Telefones.Add(new Entidades.Cadastral.SISCOM.Telefone() { DDD = 11, Numero = 33335555 });
            ret.Output.Telefones.Add(new Entidades.Cadastral.SISCOM.Telefone() { DDD = 13, Numero = 23556698 });
            ret.Output.Telefones.Add(new Entidades.Cadastral.SISCOM.Telefone() { DDD = 11, Numero = 987156630 });

            ret.Status.Code = 200;
            ret.Status.DateTime = DateTime.Now;
            ret.Status.Detail = "SOLICITACAO PROCESSADA COM SUCESSO";
            ret.Status.Message = "OK";
            ret.Status.Protocol = Guid.NewGuid().ToString();
            ret.Status.Source = "DNA CONSULTORIA";
            ret.Status.Type = "Consulta Siscom PF";

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

                u.LoginUsuario = loginUsuario.Trim().ToUpper();
                u.SenhaUsuario = senhaUsuario.Trim().ToUpper();

                lRetUser = n.Listar(u);

                if (lRetUser.Count > 0 && lRetUser.FirstOrDefault().FlagAtivo.Equals("S"))
                {
                    Session.Add("ws_siscom_acesso", lRetUser.FirstOrDefault());
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

        private Entidades.HistoricoPesquisa SalvarHistoricoPesquisa(string pesquisaSucesso, string codigoItemProduto, string Observacao, string parametroUsadoPesquisa, string tipoParametroUsadoPesquisa)
        {
            try
            {
                Entidades.HistoricoPesquisa hist = new Entidades.HistoricoPesquisa();
                Negocios.HistoricoPesquisa n = new Negocios.HistoricoPesquisa();

                hist.CodigoItemProduto = codigoItemProduto;
                hist.FiltroUtilizadoPesquisa = parametroUsadoPesquisa;
                hist.IpOrigemConsulta = HttpContext.Current.Request.UserHostAddress.ToString();
                hist.IdUsuarioConsulta = ((Entidades.Usuario)Session["ws_siscom_acesso"]).IdUsuario;
                hist.Observacao = Observacao;
                hist.FlagSucesso = pesquisaSucesso;
                hist.TipoFiltroUtilizadoPesquisa = tipoParametroUsadoPesquisa;
                hist.DataConsulta = DataBR;

                return n.Salvar(hist);
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoPesquisa", "SiscomWS", HttpContext.Current.Server.MapPath(diretorioLog));

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
                h.IdUsuarioConsulta = ((Entidades.Usuario)Session["ws_siscom_acesso"]).IdUsuario;
                h.HTMLRetornadoFornecedor = HTMLRetornado;
                h.FlagSucesso = pesquisaSucesso;
                h.DataConsulta = DataBR;

                n.SalvarHistoricoFornecedor(h);
            }
            catch (Exception ex)
            {
                Util.Log.Save("ex:" + ex.Message, "SalvarHistoricoFornecedor", "SiscomWS", HttpContext.Current.Server.MapPath(diretorioLog));
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
                Util.Log.Save("ex:" + ex.Message, "ListarOrigemProdutoConsultado", "SiscomWS", HttpContext.Current.Server.MapPath(diretorioLog));
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

                return l.Where(p=>p.NomeInterno.Trim().ToUpper().Equals(nomeProduto.ToUpper())).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
