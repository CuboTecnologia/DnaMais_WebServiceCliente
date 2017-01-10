using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class RastreamentoPFPrata
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.ResponsePFPrata PesquisaPFPrata(string CPF)
        {
            try
            {
                Entidades.Cadastral.ResponsePFPrata retResponse = new Entidades.Cadastral.ResponsePFPrata();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoPFPrata neg = new Dados.Cadastral.WS.RastreamentoPFPrata();

                neg.PesquisaPF(CPF, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Dados Cadastrais
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        retResponse.DadosCadastrais = new Entidades.Cadastral.DadosCadastraisPF();
                        retResponse.DadosCadastrais.CPF = dr["CPF"].ToString();
                        retResponse.DadosCadastrais.ClasseSocial = dr["CLASSE_SOCIAL"].ToString();
                        retResponse.DadosCadastrais.DataNascimento = dr["DATA_NASCIMENTO"].ToString();
                        retResponse.DadosCadastrais.Escolaridade = dr["ESCOLARIDADE"].ToString();
                        retResponse.DadosCadastrais.EstadoCivil = dr["ESTADO_CIVIL"].ToString();
                        retResponse.DadosCadastrais.Idade = dr["IDADE"].ToString();
                        retResponse.DadosCadastrais.Nome = dr["NOME"].ToString();
                        retResponse.DadosCadastrais.NomeMae = dr["NOME_MAE"].ToString();
                        retResponse.DadosCadastrais.RG = dr["RG"].ToString();
                        retResponse.DadosCadastrais.RendaEstimada = dr["RENDA_ESTIMADA"].ToString();
                        retResponse.DadosCadastrais.Sexo = dr["SEXO"].ToString();
                        retResponse.DadosCadastrais.Signo = dr["SIGNO"].ToString();
                        retResponse.DadosCadastrais.StatusCPF = dr["STATUS_CPF"].ToString();
                        retResponse.DadosCadastrais.TituloEleitoral = dr["TITULO_ELEITORAL"].ToString();
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
                        ende.Numero = dr["NUMERO"].ToString();
                        ende.Complemento = dr["COMPLEMENTO"].ToString();
                        ende.Bairro = dr["BAIRRO"].ToString();
                        ende.Cidade = dr["CIDADE"].ToString();
                        ende.UF = dr["UF"].ToString();
                        ende.CEP = dr["CEP"].ToString();

                        retResponse.Enderecos.Add(ende);
                    }

                    // Tabela 4 -> Dados de Emails
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        if (retResponse.Emails == null)
                        { retResponse.Emails = new List<Entidades.Cadastral.Email>(); }

                        Entidades.Cadastral.Email email = new Entidades.Cadastral.Email();

                        email.Endereco = dr["EMAIL"].ToString();

                        retResponse.Emails.Add(email);
                    }

                    // Tabela 5 -> Dados de QSA
                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        if (retResponse.QSA == null)
                        { retResponse.QSA = new List<Entidades.Cadastral.QSA_PJ>(); }

                        Entidades.Cadastral.QSA_PJ qsa = new Entidades.Cadastral.QSA_PJ();

                        qsa.Cnpj = dr["CNPJ"].ToString();
                        qsa.RazaoSocial = dr["RAZAO_SOCIAL"].ToString();
                        qsa.NomeFantasia = dr["NOME_FANTASIA"].ToString();
                        //qsa.docu = dr["DOCUMENTO_SOCIO"].ToString();
                        //qsa.nome = dr["NOME_SOCIO"].ToString();
                        qsa.Qualificacao = dr["QUALIFICACAO"].ToString();
                        qsa.DataEntradaSociedade = dr["DATA_ENTRADA_SOCIEDADE"].ToString();
                        qsa.ValorParticipacao = dr["VALOR_PARTICIPACAO"].ToString();

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
