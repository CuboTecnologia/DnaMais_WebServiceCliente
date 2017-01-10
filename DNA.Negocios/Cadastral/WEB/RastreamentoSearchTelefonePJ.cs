using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WEB
{
    public class RastreamentoSearchTelefonePJ
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.Cadastral.ResponseSearchTelefonePJ> PesquisaSearchPJ(Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ filtro)
        {
            try
            {
                List<Entidades.Cadastral.ResponseSearchTelefonePJ> listRet = new List<Entidades.Cadastral.ResponseSearchTelefonePJ>();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchTelefonePJ neg = new Dados.Cadastral.WS.RastreamentoSearchTelefonePJ();

                neg.PesquisaSearchTelefonePJ(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchTelefonePJ retResponse = new Entidades.Cadastral.ResponseSearchTelefonePJ();

                        retResponse.CNPJ = dr["CNPJ"].ToString();
                        retResponse.RazaoSocial = dr["RAZAO_SOCIAL"].ToString();
                        retResponse.NomeFantasia = dr["NOME_FANTASIA"].ToString();
                        retResponse.DDD = dr["DDD"].ToString();
                        retResponse.Telefone = dr["TELEFONE"].ToString();

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
