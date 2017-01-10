using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Relatorio
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

        public List<Entidades.Relatorio.RelatorioAnaliticoCliente> ListarSolicitacoesByUsuario(Entidades.Relatorio.FiltroPesquisa filtro)
        {
            try
            {
                //Linq.MotorDataDBDataContext dc = new Linq.MotorDataDBDataContext(Linq.ConnectionString.GetStringConnMotorData);

                //var q = from h in dc.HISTORICO_CONSULTAs
                //        where
                //            h.ID_USUARIO_INCLUSAO == filtro.IdUsuarioLogado
                //            && h.DATA_INCLUSAO >= filtro.DataInicialPesquisa
                //            && h.DATA_INCLUSAO <= filtro.DataFinalPesquisa
                //            && h.ID_PRODUTO_PRECO == (filtro.IdProdutoPreco == 0 ? h.ID_PRODUTO_PRECO : filtro.IdProdutoPreco)
                //        orderby h.DATA_INCLUSAO descending
                //        select new Entidades.Relatorios.AnaliticoCliente
                //        {
                //            IdHistoricoConsulta = (int)h.ID,
                //            ParametroPesquisado = h.FILTRO_ENTRADA_PESQUISA,
                //            PlacaPesquisada = "",
                //            ChassiPesquisado = "",
                //            NumeroMotorPesquisado = "",
                //            NumeroCambioPesquisado = "",
                //            DataSolicitacao = h.DATA_INCLUSAO,
                //            IdCliente = h.USUARIO_INCLUSAO.RELACIONA_USUARIO_CLIENTEs.Where(p => p.ID_USUARIO == filtro.IdUsuarioLogado).FirstOrDefault().CLIENTE.ID,
                //            LoginUsuarioSolicitante = h.USUARIO_INCLUSAO.LOGIN,
                //            NomeUsuarioSolicitante = h.USUARIO_INCLUSAO.NOME,
                //            NomeFantasiaCliente = h.USUARIO_INCLUSAO.RELACIONA_USUARIO_CLIENTEs.Where(p => p.ID_USUARIO == filtro.IdUsuarioLogado).FirstOrDefault().CLIENTE.NOME_FANTASIA,
                //            RazaoSocialCliente = h.USUARIO_INCLUSAO.RELACIONA_USUARIO_CLIENTEs.Where(p => p.ID_USUARIO == filtro.IdUsuarioLogado).FirstOrDefault().CLIENTE.NOME_RAZAO_SOCIAL,
                //            NomeProdutoConsultado = h.PRODUTO_PRECO.PRODUTO.NOME,
                //            NomeInternoProdutoConsultado = h.PRODUTO_PRECO.PRODUTO.NOME_INTERNO,
                //            StatusHistoricoPesquisa = h.FLAG_SUCESSO,
                //            TipoParametroPesquisado = h.TIPO_FILTRO_ENTRADA_PESQUISA,
                //            IdProdutoPrecoPesquisado = h.ID_PRODUTO_PRECO,
                //            StatusPesquisa = ConsultarStatusSolicitacao(new Entidades.ConsultaEspecialECV.FiltrosPesquisa() { IdHitoricoPesquisa = h.ID }).StatusConsulta
                //        };

                //List<Entidades.Relatorios.AnaliticoCliente> l = new List<Entidades.Relatorios.AnaliticoCliente>();
                //l = q.ToList();

                //return l;

                return new List<Entidades.Relatorio.RelatorioAnaliticoCliente>();
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
