using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WEB
{
    public class RastreamentoSearchPJ
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.Cadastral.ResponseSearchPJ> PesquisaSearchPJ(Entidades.Cadastral.FiltroPesquisaSearchPJ filtro)
        {
            try
            {
                List<Entidades.Cadastral.ResponseSearchPJ> listRet = new List<Entidades.Cadastral.ResponseSearchPJ>();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchPJ neg = new Dados.Cadastral.WS.RastreamentoSearchPJ();

                neg.PesquisaSearchPJ(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchPJ retResponse = new Entidades.Cadastral.ResponseSearchPJ();

                        retResponse.CNPJ = dr["CNPJ"].ToString();
                        retResponse.NomeFantasia = dr["NOME_FANTASIA"].ToString();
                        retResponse.RazaoSocial = dr["RAZAO_SOCIAL"].ToString();
                        retResponse.UF = dr["UF"].ToString();
                        retResponse.Cidade = dr["CIDADE"].ToString();

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
