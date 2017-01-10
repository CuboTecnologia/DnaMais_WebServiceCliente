using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastral.WS
{
    public class RastreamentoSearchTelefonePF
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public Entidades.Cadastral.ResponseSearchTelefonePF_WS PesquisaSearchTelefonePF(Entidades.Cadastral.FiltroPesquisaSearchTelefonePF filtro)
        {
            try
            {
                Entidades.Cadastral.ResponseSearchTelefonePF_WS retResponse = new Entidades.Cadastral.ResponseSearchTelefonePF_WS();

                DataSet ds = new DataSet();

                Dados.Cadastral.WS.RastreamentoSearchTelefonePF neg = new Dados.Cadastral.WS.RastreamentoSearchTelefonePF();

                neg.PesquisaSearchTelefonePF(filtro, ref ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    // Tabela 1 -> Resultado
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entidades.Cadastral.ResponseSearchTelPFDadosPessoais dadosP = new Entidades.Cadastral.ResponseSearchTelPFDadosPessoais();

                        dadosP.CPF = dr["CPF"].ToString();
                        dadosP.Nome = dr["NOME"].ToString();
                        dadosP.DataNascimento = dr["DATA_NASCIMENTO"].ToString();
                        dadosP.NomeMae = dr["NOME_MAE"].ToString();

                        if (retResponse.ListResponseSearchTelPFDadosPessoais == null)
                        { retResponse.ListResponseSearchTelPFDadosPessoais = new List<Entidades.Cadastral.ResponseSearchTelPFDadosPessoais>(); }

                        retResponse.ListResponseSearchTelPFDadosPessoais.Add(dadosP);
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
