using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class RastreamentoSearchTelefonePJ
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.ResponseSearchTelefonePJ_WS PesquisaSearchTelefonePF(Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ filtro)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchTelefonePJ_WS retResponse = new Entidades.Cadastral.ResponseSearchTelefonePJ_WS();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchTelefonePJ neg = new Dados.Cadastral.WS.RastreamentoSearchTelefonePJ();

                neg.PesquisaSearchTelefonePJ(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchTelPJDadosEmpresa dadosE = new Entidades.Cadastral.ResponseSearchTelPJDadosEmpresa();

                        dadosE.CNPJ = dr["CNPJ"].ToString();
                        dadosE.RazaoSocial = dr["RAZAO_SOCIAL"].ToString();
                        dadosE.NomeFantasia = dr["NOME_FANTASIA"].ToString();

                        if (retResponse.ListResponseSearchTelPJDadosEmpresa == null)
                        { retResponse.ListResponseSearchTelPJDadosEmpresa = new List<Entidades.Cadastral.ResponseSearchTelPJDadosEmpresa>(); }

                        retResponse.ListResponseSearchTelPJDadosEmpresa.Add(dadosE);
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
