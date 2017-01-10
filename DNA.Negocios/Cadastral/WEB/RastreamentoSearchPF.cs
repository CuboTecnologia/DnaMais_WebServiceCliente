using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WEB
{
    public class RastreamentoSearchPF
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.Cadastral.ResponseSearchPF> PesquisaSearchPF(Entidades.Cadastral.FiltroPesquisaSearchPF filtro)
        {
            try
            {
                List<Entidades.Cadastral.ResponseSearchPF> listRet = new List<Entidades.Cadastral.ResponseSearchPF>();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchPF neg = new Dados.Cadastral.WS.RastreamentoSearchPF();

                neg.PesquisaSearchPF(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchPF retResponse = new Entidades.Cadastral.ResponseSearchPF();

                        retResponse.CPF = dr["CPF"].ToString();
                        retResponse.Nome = dr["NOME"].ToString();
                        retResponse.UF = dr["UF"].ToString();
                        retResponse.Cidade = dr["CIDADE"].ToString();
                        retResponse.DataNascimento = dr["DATA_NASCIMENTO"].ToString();
                        retResponse.NomeMae = dr["NOME_MAE"].ToString();

                        listRet.Add(retResponse);
                    }

                    if (ds.Tables[0].Rows.Count == 0)
                    { return null; }
                    else
                    { return listRet; }
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
