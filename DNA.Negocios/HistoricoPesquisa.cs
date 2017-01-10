using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DNA.Negocios
{
    public class HistoricoPesquisa
    {
        DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public void SalvarHistoricoFornecedor(Entidades.HistoricoPesquisa h)
        {
            try
            {
                Dados.HistoricoPesquisa negHistPesq = new Dados.HistoricoPesquisa();

                DataTable dtRetorno = new DataTable();

                negHistPesq.SalvarHistoricoFornecedor(h, ref dtRetorno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entidades.HistoricoPesquisa Salvar(Entidades.HistoricoPesquisa h)
        {
            try
            {
                Dados.HistoricoPesquisa negHistPesq = new Dados.HistoricoPesquisa();

                DataTable dtRetorno = new DataTable();

                negHistPesq.Salvar(h, ref dtRetorno);

                foreach (DataRow item in dtRetorno.Rows)
                {
                    Entidades.HistoricoPesquisa hist = new Entidades.HistoricoPesquisa();

                    hist.IdHistoricoConsulta = int.Parse(item["ID_HISTORICO_CONSULTA"].ToString());
                    hist.ProtocoloRetorno = item["PROTOCOLO_RETORNO"].ToString();

                    return hist;
                }

                return new Entidades.HistoricoPesquisa();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
