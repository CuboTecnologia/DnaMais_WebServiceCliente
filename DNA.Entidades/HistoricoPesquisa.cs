using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class HistoricoPesquisa
    {
        public int IdHistoricoConsulta { get; set; }
        public int IdClienteEmpresa { get; set; }
        public int IdContratoEmpresa { get; set; }
        public string CodigoItemProduto { get; set; }
        public string FiltroUtilizadoPesquisa { get; set; }
        public string TipoFiltroUtilizadoPesquisa { get; set; }
        public string IpOrigemConsulta { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string DataConsultaFormatada { get; set; }
        public int IdUsuarioConsulta { get; set; }
        public string FlagSucesso { get; set; }
        public int IdOrigemProdutoConsultado { get; set; }
        public string Observacao { get; set; }
        public int IdUsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string FlagSessaoExpirada { get; set; }
        public string FlagSessaoIdProdutoPrecoExpirada { get; set; }
        public string FlagPesquisaEncontrada { get; set; }
        public string NomeProdutoFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string HTMLRetornadoFornecedor { get; set; }
        public string ProtocoloRetorno { get; set; }


        public HistoricoPesquisa()
        {
            this.IdUsuarioAlteracao = 0;
            this.Observacao = string.Empty;
            this.IdClienteEmpresa = 0;
            this.IdContratoEmpresa = 0;
            this.IdHistoricoConsulta = 0;
            this.CodigoItemProduto = string.Empty;
            this.FiltroUtilizadoPesquisa = string.Empty;
            this.TipoFiltroUtilizadoPesquisa = string.Empty;
            this.IpOrigemConsulta = string.Empty;
            this.DataConsulta = null;
            this.IdUsuarioConsulta = 0;
            this.FlagSucesso = string.Empty;
            this.IdOrigemProdutoConsultado = 0;
            this.FlagSessaoExpirada = string.Empty;
            this.FlagSessaoIdProdutoPrecoExpirada = string.Empty;
            this.FlagPesquisaEncontrada = string.Empty;
            this.DataConsultaFormatada = string.Empty;
            this.HTMLRetornadoFornecedor = string.Empty;
            this.ProtocoloRetorno = string.Empty;
        }

        public HistoricoPesquisa(int idHistoricoConsulta, int idClienteEmpresa, int idContratoEmpresa, string codigoItemProduto, string filtroUtilizadoPesquisa, string ipOrigemConsulta,
                                 DateTime? dataConsulta, int idUsuarioConsulta, string flagSucesso, int idOrigemProdutoConsultado,
                                 string tipoFiltroUtilizadoPesquisa, string flagSessaoExpirada, string flagSessaoIdProdutoPrecoExpirada,
                                 string flagPesquisaEncontrada, string htmlRetornadoFornecedor, string protocoloRetorno)
        {
            this.IdHistoricoConsulta = 0;
            this.IdClienteEmpresa = 0;
            this.IdContratoEmpresa = 0;
            this.CodigoItemProduto = string.Empty;
            this.FiltroUtilizadoPesquisa = string.Empty;
            this.IpOrigemConsulta = string.Empty;
            this.DataConsulta = null;
            this.IdUsuarioConsulta = 0;
            this.FlagSucesso = string.Empty;
            this.IdOrigemProdutoConsultado = 0;
            this.TipoFiltroUtilizadoPesquisa = string.Empty;
            this.FlagSessaoExpirada = string.Empty;
            this.FlagSessaoIdProdutoPrecoExpirada = string.Empty;
            this.FlagPesquisaEncontrada = string.Empty;
            this.HTMLRetornadoFornecedor = string.Empty;
            this.ProtocoloRetorno = string.Empty;

            this.IdHistoricoConsulta = idHistoricoConsulta;
            this.IdClienteEmpresa = IdClienteEmpresa;
            this.IdContratoEmpresa = IdContratoEmpresa;
            this.CodigoItemProduto = codigoItemProduto;
            this.FiltroUtilizadoPesquisa = filtroUtilizadoPesquisa;
            this.IpOrigemConsulta = ipOrigemConsulta;
            this.DataConsulta = dataConsulta;
            this.IdUsuarioConsulta = idUsuarioConsulta;
            this.FlagSucesso = flagSucesso;
            this.IdOrigemProdutoConsultado = idOrigemProdutoConsultado;
            this.TipoFiltroUtilizadoPesquisa = tipoFiltroUtilizadoPesquisa;
            this.FlagSessaoExpirada = flagSessaoExpirada;
            this.FlagSessaoIdProdutoPrecoExpirada = flagSessaoIdProdutoPrecoExpirada;
            this.FlagPesquisaEncontrada = flagPesquisaEncontrada;
            this.HTMLRetornadoFornecedor = htmlRetornadoFornecedor;
            this.ProtocoloRetorno = protocoloRetorno;
        }
    }
}
