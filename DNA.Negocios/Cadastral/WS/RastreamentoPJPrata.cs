using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class RastreamentoPJPrata
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.ResponsePJPrata PesquisaPJPrata(string CNPJ)
        {
            try
            {
                Entidades.Cadastral.ResponsePJPrata retResponse = new Entidades.Cadastral.ResponsePJPrata();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoPJPrata neg = new Dados.Cadastral.WS.RastreamentoPJPrata();

                neg.PesquisaPJ(CNPJ, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Dados Cadastrais
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        retResponse.DadosCadastrais = new Entidades.Cadastral.DadosCadastraisPJ();
                        retResponse.DadosCadastrais.CNPJ = dr["CNPJ"].ToString();
                        retResponse.DadosCadastrais.RazaoSocial = dr["RAZAO_SOCIAL"].ToString();
                        retResponse.DadosCadastrais.MatrizFilial = dr["MATRIZ_FILIAL"].ToString();
                        retResponse.DadosCadastrais.DataAbertura = dr["DATA_ABERTURA"].ToString();
                        retResponse.DadosCadastrais.NomeFantasia = dr["NOME_FANTASIA"].ToString();
                        retResponse.DadosCadastrais.NaturezaJuridica = dr["NATUREZA_JURIDICA"].ToString();
                        retResponse.DadosCadastrais.SituacaoCadastral = dr["SITUACAO_CADASTRAL"].ToString();
                        retResponse.DadosCadastrais.DataSituacaoDastral = dr["DATA_SITUACAO_CADASTRAL"].ToString();
                    }

                    // Tabela 2 -> Dados de Telefones
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        if (retResponse.Telefones == null)
                        { retResponse.Telefones = new List<Entidades.Cadastral.Telefone>(); }

                        Entidades.Cadastral.Telefone tel = new Entidades.Cadastral.Telefone();

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

                        retResponse.Telefones.Add(tel);
                    }

                    // Tabela 3 -> Dados de Endereços
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        if (retResponse.Enderecos == null)
                        { retResponse.Enderecos = new List<Entidades.Cadastral.Endereco>(); }

                        Entidades.Cadastral.Endereco ende = new Entidades.Cadastral.Endereco();

                        ende.Logradouro = dr["LOGRADOURO"].ToString();
                        ende.Numero = dr["NUMERO_ENDERECO"].ToString();
                        ende.Complemento = dr["COMPLEMENTO_ENDERECO"].ToString();
                        ende.Bairro = dr["BAIRRO"].ToString();
                        ende.Cidade = dr["MUNICIPIO"].ToString();
                        ende.UF = dr["UF"].ToString();
                        ende.CEP = dr["CEP"].ToString();

                        retResponse.Enderecos.Add(ende);
                    }

                    // Tabela 4 -> Dados de CNAE
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        if (retResponse.CNAE == null)
                        { retResponse.CNAE = new List<Entidades.Cadastral.CNAE>(); }

                        Entidades.Cadastral.CNAE cnae = new Entidades.Cadastral.CNAE();

                        cnae.Codigo = dr["CODIGO_CNAE"].ToString();
                        cnae.Ordem = dr["ORDEM_CNAE"].ToString();
                        cnae.OrdemDescricao = dr["ORDEM_DESC"].ToString();
                        cnae.Descricao = dr["DESCRICAO_CNAE"].ToString();
                        cnae.Grupo = dr["GRUPO_CNAE"].ToString();
                        cnae.Industria = dr["INDUSTRIA"].ToString();
                        cnae.ComercioServico = dr["COMERCIO_SERVICO"].ToString();
                        cnae.Flag = dr["FLAG"].ToString();

                        retResponse.CNAE.Add(cnae);
                    }

                    // Tabela 5 -> Dados de QSA
                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        if (retResponse.QSA == null)
                        { retResponse.QSA = new List<Entidades.Cadastral.QSA>(); }

                        Entidades.Cadastral.QSA qsa = new Entidades.Cadastral.QSA();

                        qsa.Cnpj = dr["CNPJ"].ToString();
                        qsa.DocumentoSocio = dr["DOCUMENTO_SOCIO"].ToString();
                        qsa.NomeSocio = dr["NOME_SOCIO"].ToString();
                        qsa.Qualificacao = dr["QUALIFICACAO"].ToString();
                        qsa.DataEntradaSociedade = dr["DATA_ENTRADA_SOCIEDADE"].ToString();
                        qsa.ValorParticipacao = dr["VALOR_PARTICIPACAO"].ToString();

                        if (!qsa.DocumentoSocio.Trim().Equals(""))
                        { qsa.TipoPessoa = qsa.DocumentoSocio.Trim().Length > 11 ? "PJ" : "PF"; }
                        
                        retResponse.QSA.Add(qsa);
                    }
                }

                return retResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
