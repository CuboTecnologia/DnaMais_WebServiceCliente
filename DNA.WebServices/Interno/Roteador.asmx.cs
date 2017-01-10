using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;

namespace DNA.WebServices.Interno
{
    /// <summary>
    /// Summary description for Roteador
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Roteador : System.Web.Services.WebService
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        [WebMethod]
        public List<DNA.Entidades.Usuario> ListarUsuarios(string chaveAcessoWSInterno, string idUsuario, string loginUsuario, string senhaUsuario, string flagAtivo)
        {
            string ChaveAcessoWSInterno = ConfigurationManager.AppSettings["ChaveAcessoWSInterno"].ToString();

            List<DNA.Entidades.Usuario> lRetUsu = new List<DNA.Entidades.Usuario>();

            try
            {
                if (ChaveAcessoWSInterno.Trim().Equals(chaveAcessoWSInterno))
                {
                    DataTable dtUsuarios = new DataTable();
                    DataTable dtPerfis = new DataTable();
                    DataTable dtProdutos = new DataTable();

                    Entidades.Usuario e = new Entidades.Usuario();

                    Dados.Cadastro.Usuarios negUsu = new Dados.Cadastro.Usuarios();
                    Dados.Cadastro.PerfilAcesso negPerf = new Dados.Cadastro.PerfilAcesso();

                    e.IdUsuario = idUsuario.Equals("") ? 0 : int.Parse(idUsuario);
                    e.LoginUsuario = loginUsuario;
                    e.SenhaUsuario = senhaUsuario;
                    e.FlagAtivo = flagAtivo;

                    negUsu.Listar(e, ref dtUsuarios);

                    foreach (DataRow drUsu in dtUsuarios.Rows)
                    {
                        List<DNA.Entidades.PerfilAcesso> lRetPerf = new List<DNA.Entidades.PerfilAcesso>();

                        Entidades.Usuario retUsu = new Entidades.Usuario();

                        if (!drUsu["DATA_ALTERACAO"].ToString().Equals(""))
                        { retUsu.DataAlteracao = DateTime.Parse(drUsu["DATA_ALTERACAO"].ToString()); }
                        
                        retUsu.DataInclusao = DateTime.Parse(drUsu["DATA_INCLUSAO"].ToString());
                        retUsu.Email1 = drUsu["EMAIL1"].ToString();
                        retUsu.Email2 = drUsu["EMAIL2"].ToString();
                        retUsu.FlagAtivo = drUsu["FLAG_ATIVO"].ToString();
                        retUsu.IdCliente = int.Parse(drUsu["ID_CLIENTE"].ToString());
                        retUsu.IdUsuario = int.Parse(drUsu["ID"].ToString());

                        if (!drUsu["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                        { retUsu.IdUsuarioAlteracao = int.Parse(drUsu["ID_USUARIO_ALTERACAO"].ToString()); }

                        retUsu.IdUsuarioInclusao = int.Parse(drUsu["ID_USUARIO_INCLUSAO"].ToString());
                        retUsu.IpClienteLogado = "";
                        retUsu.LoginUsuario = drUsu["LOGIN"].ToString();
                        retUsu.NomeUsuario = drUsu["NOME"].ToString();
                        retUsu.Observacao = drUsu["OBESERVACAO"].ToString();
                        retUsu.SenhaUsuario = drUsu["SENHA"].ToString();

                        dtPerfis = new DataTable();
                        Entidades.PerfilAcesso entPA = new Entidades.PerfilAcesso();

                        entPA.IdUsuario = retUsu.IdUsuario;

                        negPerf.ListarPerfilByIdUsuario(entPA, ref dtPerfis);

                        foreach (DataRow drPerf in dtPerfis.Rows)
                        {
                            Entidades.PerfilAcesso retPerf = new Entidades.PerfilAcesso();

                            if (!drPerf["DATA_ALTERACAO"].ToString().Equals(""))
                            { retPerf.DataAlteracaoPerfilAcesso = DateTime.Parse(drPerf["DATA_ALTERACAO"].ToString()); }

                            
                            retPerf.DataInclusaoPerfilAcesso = DateTime.Parse(drPerf["DATA_INCLUSAO"].ToString());
                            retPerf.DescricaoPerfilAcesso = drPerf["DESCRICAO_PERFIL"].ToString();
                            retPerf.FlagAtivoPerfilAcesso = drPerf["FLAG_ATIVO"].ToString();
                            retPerf.IdPerfilAcesso = int.Parse(drPerf["ID"].ToString());
                            retPerf.IdPerfilAcessoUsuario = int.Parse(drPerf["ID_USUARIO"].ToString());

                            if (!drPerf["ID_USUARIO_ALTERACAO"].ToString().Equals(""))
                            { 
                                retPerf.IdUsuarioAlterasaoPerfilAcesso = int.Parse(drPerf["ID_USUARIO_ALTERACAO"].ToString());
                                retPerf.NomeUsuarioAlteracao = drPerf["NOME_USUARIO_ALTERACAO"].ToString();
                            }

                            retPerf.IdUsuarioInclusaoPerfilAcesso = int.Parse(drPerf["ID_USUARIO_INCLUSAO"].ToString());
                            retPerf.NomeUsuarioInclusao = drPerf["NOME_USUARIO_INCLUSAO"].ToString();

                            lRetPerf.Add(retPerf);
                        }

                        if (retUsu.Perfil == null)
                        { retUsu.Perfil = new List<Entidades.PerfilAcesso>(); }

                        retUsu.Perfil.AddRange(lRetPerf);
                        lRetUsu.Add(retUsu);

                    }
                }

                return lRetUsu;
            }
            catch
            {
                return lRetUsu;
            }
        }

        [WebMethod]
        public DNA.Entidades.Cadastral.SISCOM.Response SISCOMPesquisaPF(string chaveAcessoWSInterno, string CPF)
        {
            string ChaveAcessoWSInterno = ConfigurationManager.AppSettings["ChaveAcessoWSInterno"].ToString();

            DNA.Entidades.Cadastral.SISCOM.Response retResponse = new DNA.Entidades.Cadastral.SISCOM.Response();

            try
            {
                if (ChaveAcessoWSInterno.Trim().Equals(chaveAcessoWSInterno))
                {
                    DataSet ds = new DataSet();

                    Dados.Cadastral.SISCOM neg = new Dados.Cadastral.SISCOM();

                    neg.PesquisaPF(CPF, ref ds);

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        // Tabela 1 -> Dados Cadastrais
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            retResponse.Output.DadosCadastrais = new Entidades.Cadastral.SISCOM.DadosCadastrais();
                            retResponse.Output.DadosCadastrais.CPF = dr["CPF"].ToString();
                            retResponse.Output.DadosCadastrais.Nome = dr["NOME"].ToString();
                            retResponse.Output.DadosCadastrais.RG = dr["RG"].ToString();
                        }

                        // Tabela 2 -> Dados de Telefones
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            if (retResponse.Output.Telefones == null)
                            { retResponse.Output.Telefones = new List<Entidades.Cadastral.SISCOM.Telefone>(); }

                            Entidades.Cadastral.SISCOM.Telefone tel = new Entidades.Cadastral.SISCOM.Telefone();

                            if (dr["DDD"].ToString().Trim().Equals(""))
                            {
                                tel.DDD = 0;
                                tel.Numero = 0;
                            }
                            else
                            {
                                try
                                {
                                    tel.DDD = int.Parse(dr["DDD"].ToString());
                                    tel.Numero = int.Parse(dr["TELEFONE"].ToString());
                                }
                                catch
                                {
                                    tel.DDD = 0;
                                    tel.Numero = 0;
                                }
                            }

                            retResponse.Output.Telefones.Add(tel);
                        }

                        // Tabela 3 -> Dados de Endereços
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            if (retResponse.Output.Enderecos == null)
                            { retResponse.Output.Enderecos = new List<Entidades.Cadastral.SISCOM.Endereco>(); }

                            Entidades.Cadastral.SISCOM.Endereco ende = new Entidades.Cadastral.SISCOM.Endereco();

                            ende.Logradouro = dr["LOGRADOURO"].ToString();
                            ende.Numero = dr["NUMERO"].ToString();
                            ende.Complemento = dr["COMPLEMENTO"].ToString();
                            ende.Bairro = dr["BAIRRO"].ToString();
                            ende.Cidade = dr["CIDADE"].ToString();
                            ende.UF = dr["UF"].ToString();
                            ende.CEP = dr["CEP"].ToString();

                            retResponse.Output.Enderecos.Add(ende);
                        }

                        // Tabela 4 -> Dados de Emails
                        foreach (DataRow dr in ds.Tables[3].Rows)
                        {
                            if (retResponse.Output.Emails == null)
                            { retResponse.Output.Emails = new List<Entidades.Cadastral.SISCOM.Email>(); }

                            Entidades.Cadastral.SISCOM.Email email = new Entidades.Cadastral.SISCOM.Email();

                            email.Endereco = dr["EMAIL"].ToString();

                            retResponse.Output.Emails.Add(email);
                        }
                    }
                }

                return retResponse;
            }
            catch
            {
                return new Entidades.Cadastral.SISCOM.Response();
            }
        }
    }
}
