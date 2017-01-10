using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Relatorio
{
    public class Relatorios
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public List<Entidades.Relatorio.RelatorioAnaliticoCliente> ListarRelatorioAnaliticoClientes(Entidades.Relatorio.FiltroPesquisa filtro)
        {
            try
            {
                //Linq.MotorDataDBDataContext dc = new Linq.MotorDataDBDataContext(Linq.ConnectionString.GetStringConnMotorData);

                //var q = from h in dc.HISTORICO_CONSULTAs
                //        join u in dc.USUARIOs on h.ID_USUARIO_INCLUSAO equals u.ID
                //        join relUC in dc.RELACIONA_USUARIO_CLIENTEs on u.ID equals relUC.ID_USUARIO
                //        join cli in dc.CLIENTEs on relUC.ID_CLIENTE equals cli.ID
                //        where
                //            cli.ID == filtro.IdCliente
                //            && h.ID_USUARIO_INCLUSAO == (filtro.IdUsuarioLogado == 0 ? h.ID_USUARIO_INCLUSAO : filtro.IdUsuarioLogado)
                //            && h.DATA_INCLUSAO >= filtro.DataInicialPesquisa
                //            && h.DATA_INCLUSAO <= filtro.DataFinalPesquisa
                //            && h.ID_PRODUTO_PRECO == (filtro.IdProdutoPreco == 0 ? h.ID_PRODUTO_PRECO : filtro.IdProdutoPreco)
                //        orderby h.DATA_INCLUSAO descending
                //        select new Entidades.Veicular.RelatorioAnaliticoCliente
                //        {
                //            IdHistoricoConsulta = (int)h.ID,
                //            ParametroPesquisado = h.FILTRO_ENTRADA_PESQUISA,
                //            PlacaPesquisada = "",
                //            ChassiPesquisado = "",
                //            NumeroMotorPesquisado = "",
                //            NumeroCambioPesquisado = "",
                //            DataSolicitacao = h.DATA_INCLUSAO,
                //            IdCliente = cli.ID,
                //            LoginUsuarioSolicitante = h.USUARIO_INCLUSAO.LOGIN,
                //            NomeUsuarioSolicitante = h.USUARIO_INCLUSAO.NOME,
                //            NomeFantasiaCliente = cli.NOME_FANTASIA,
                //            RazaoSocialCliente = cli.NOME_RAZAO_SOCIAL,
                //            NomeProdutoConsultado = h.PRODUTO_PRECO.PRODUTO.NOME,
                //            StatusPesquisa = ConsultarStatusSolicitacao(new Entidades.FiltroPesquisa() { IdHitoricoPesquisa = h.ID }).StatusConsulta
                //        };

                //List<Entidades.Veicular.RelatorioAnaliticoCliente> l = new List<Entidades.Veicular.RelatorioAnaliticoCliente>();
                //l = q.ToList();

                //return l;

                return new List<Entidades.Relatorio.RelatorioAnaliticoCliente>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.Relatorio.RelatorioSinteticoCliente> ListarRelatorioSinteticoClientes(Entidades.Relatorio.FiltroPesquisa filtro)
        {
            try
            {
                //Linq.MotorDataDBDataContext dc = new Linq.MotorDataDBDataContext(Linq.ConnectionString.GetStringConnMotorData);

                //var q = from h in dc.REL_SINTETICO_CLIENTES(null, filtro.DataInicialPesquisa, filtro.DataFinalPesquisa)
                //        select new Entidades.Relatorios.SinteticoCliente
                //        {
                //            QtdePesquisada = (int)h.QTDE_PESQUISAS,
                //            IdCliente = h.ID_CLIENTE,
                //            NomeFantasiaCliente = h.NOME_FANTASIA,
                //            RazaoSocialCliente = h.RAZAO_SOCIAL
                //        };

                //List<Entidades.Veicular.RelatorioSinteticoCliente> l = new List<Entidades.Veicular.RelatorioSinteticoCliente>();

                //l = q.ToList();

                //return l;

                return new List<Entidades.Relatorio.RelatorioSinteticoCliente>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.Relatorio.RelatorioAnaliticoUsuario> ListarRelatorioAnaliticoUsuario(Entidades.Relatorio.FiltroPesquisa filtro)
        {
            try
            {
                DataTable dtRel = new DataTable();
                Dados.Relatorios.Relatorio dadosRel = new Dados.Relatorios.Relatorio();
                List<Entidades.Relatorio.RelatorioAnaliticoUsuario> listRelUsuario = new List<Entidades.Relatorio.RelatorioAnaliticoUsuario>();

                dadosRel.ListarRelatorioAnaliticoUsuario(filtro, ref dtRel);

                foreach (DataRow dr in dtRel.Rows)
                {
                    Entidades.Relatorio.RelatorioAnaliticoUsuario rel = new Entidades.Relatorio.RelatorioAnaliticoUsuario();

                    rel.IdHistoricoConsulta = int.Parse(dr["HIS_ID"].ToString());
                    rel.ParametroPesquisado = dr["HIS_FILTRO_ENTRADA_PESQUISA"].ToString();
                    rel.DataSolicitacao = DateTime.Parse(dr["HIS_DATA_INCLUSAO"].ToString());
                    rel.IdCliente = int.Parse(dr["ID_CLIENTE"].ToString());
                    rel.LoginUsuarioSolicitante = dr["USU_LOGIN"].ToString();
                    rel.NomeUsuarioSolicitante = dr["USU_NOME"].ToString();
                    rel.NomeFantasiaCliente = dr["CLI_NOME_FANTASIA"].ToString();
                    rel.RazaoSocialCliente = dr["CLI_NOME_RAZAO_SOCIAL"].ToString();
                    rel.NomeProdutoConsultado = dr["PROD_NOME"].ToString();
                    rel.NomeInternoProdutoConsultado = dr["PROD_NOME_INTERNO"].ToString();
                    rel.StatusHistoricoPesquisa = dr["HIS_FLAG_SUCESSO"].ToString().Equals("S") ? true : false;
                    rel.TipoParametroPesquisado = dr["HIS_TP_FILTRO_ENTRADA_PESQUISA"].ToString();
                    rel.IdProdutoPrecoPesquisado = int.Parse(dr["ID_PRODUTO_PRECO"].ToString());

                    // USAR ESSA VARIAVEL QUANDO PRECISAR CONVERTER A PROC PE_CONSULTA_STATUS_SOLICITACAO DA CHECKLOG
                    //rel.StatusPesquisa = dr[""].ToString();
                    rel.StatusPesquisa = "PROCESSADO";

                    listRelUsuario.Add(rel);
                }

                return listRelUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entidades.Relatorio.RetornoStatusPesquisa ConsultarStatusSolicitacao(Entidades.Relatorio.FiltroPesquisa filtro)
        {
            try
            {
                //Linq.MotorDataDBDataContext dc = new Linq.MotorDataDBDataContext(Linq.ConnectionString.GetStringConnMotorData);

                Entidades.Relatorio.RetornoStatusPesquisa ret = new Entidades.Relatorio.RetornoStatusPesquisa();

                //var q = from h in dc.PE_CONSULTA_STATUS_SOLICITACAO(filtro.IdHitoricoPesquisa)
                //        select new Entidades.RetornoStatusPesquisa
                //        {
                //            StatusConsulta = h.STATUS_CONSULTA,
                //            DataSolicitacao = h.DATA_SOLICITACAO
                //        };

                //ret = q.FirstOrDefault();

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
