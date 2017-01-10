using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Relatorio
{
    public class RelatorioAnaliticoCliente
    {
        public int IdHistoricoConsulta { get; set; }
        public string ParametroPesquisado { get; set; }
        public string TipoParametroPesquisado { get; set; }
        public string PlacaPesquisada { get; set; }
        public string ChassiPesquisado { get; set; }
        public string NumeroMotorPesquisado { get; set; }
        public string NumeroCambioPesquisado { get; set; }
        public int IdCliente { get; set; }
        public int IdProdutoPrecoPesquisado { get; set; }
        public string NomeFantasiaCliente { get; set; }
        public string RazaoSocialCliente { get; set; }
        public string NomeProdutoConsultado { get; set; }
        public string NomeUsuarioSolicitante { get; set; }
        public string LoginUsuarioSolicitante { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string StatusPesquisa { get; set; }
        public string NomeInternoProdutoConsultado { get; set; }
        public bool? StatusHistoricoPesquisa { get; set; }

        public RelatorioAnaliticoCliente()
        { }
    }
}
