using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class RastreamentoSearchPJ
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.ResponseSearchPJ_WS PesquisaSearchPF(Entidades.Cadastral.FiltroPesquisaSearchPJ filtro)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchPJ_WS retResponse = new Entidades.Cadastral.ResponseSearchPJ_WS();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchPJ neg = new Dados.Cadastral.WS.RastreamentoSearchPJ();

                neg.PesquisaSearchPJ(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchPJDadosEmpresa dadosE = new Entidades.Cadastral.ResponseSearchPJDadosEmpresa();

                        dadosE.CNPJ = dr["CNPJ"].ToString();
                        dadosE.NomeFantasia = dr["NOME_FANTASIA"].ToString();
                        dadosE.RazaoSocial = dr["RAZAO_SOCIAL"].ToString();
                        dadosE.UF = dr["UF"].ToString();
                        dadosE.Cidade = dr["CIDADE"].ToString();

                        if(retResponse.ListResponseSearchPFDadosEmpresa == null)
                        { retResponse.ListResponseSearchPFDadosEmpresa = new List<Entidades.Cadastral.ResponseSearchPJDadosEmpresa>(); }

                        retResponse.ListResponseSearchPFDadosEmpresa.Add(dadosE);
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
