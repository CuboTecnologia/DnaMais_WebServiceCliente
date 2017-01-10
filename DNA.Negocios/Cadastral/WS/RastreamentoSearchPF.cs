using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class RastreamentoSearchPF
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.ResponseSearchPF_WS PesquisaSearchPF(Entidades.Cadastral.FiltroPesquisaSearchPF filtro)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchPF_WS retResponse = new Entidades.Cadastral.ResponseSearchPF_WS();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchPF neg = new Dados.Cadastral.WS.RastreamentoSearchPF();

                neg.PesquisaSearchPF(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchPFDadosPessoais dadosP = new Entidades.Cadastral.ResponseSearchPFDadosPessoais();

                        dadosP.CPF = dr["CPF"].ToString();
                        dadosP.Nome = dr["NOME"].ToString();
                        dadosP.UF = dr["UF"].ToString();
                        dadosP.Cidade = dr["CIDADE"].ToString();
                        dadosP.DataNascimento = dr["DATA_NASCIMENTO"].ToString();
                        dadosP.NomeMae = dr["NOME_MAE"].ToString();

                        if(retResponse.ListResponseSearchPFDadosPessoais == null)
                        { retResponse.ListResponseSearchPFDadosPessoais = new List<Entidades.Cadastral.ResponseSearchPFDadosPessoais>(); }

                        retResponse.ListResponseSearchPFDadosPessoais.Add(dadosP);
                    }

                    if (ds.Tables[0].Rows.Count == 0)
                    { return null; }
                    else
                    { return retResponse; }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
