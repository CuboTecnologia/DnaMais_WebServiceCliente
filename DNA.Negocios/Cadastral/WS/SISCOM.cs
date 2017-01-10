using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class SISCOM
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.SISCOM.Response SISCOMPesquisaPF(string CPF)
        {
            try
            {
                Entidades.Cadastral.SISCOM.Response retResponse = new Entidades.Cadastral.SISCOM.Response();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.SISCOM neg = new Dados.Cadastral.WS.SISCOM();

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

                return retResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
