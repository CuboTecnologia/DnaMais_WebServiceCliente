using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Relatorio
{
    public class RelatorioSinteticoCliente
    {
        public int QtdePesquisada { get; set; }
        public int IdCliente { get; set; }
        public string NomeFantasiaCliente { get; set; }
        public string RazaoSocialCliente { get; set; }
        public string NomeProdutoConsultado { get; set; }
        public string NomeInternoProdutoConsultado { get; set; }
        public string NomeUsuarioSolicitante { get; set; }
        public string LoginUsuarioSolicitante { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string StatusPesquisa { get; set; }
        public bool? StatusHistoricoPesquisa { get; set; }

        public RelatorioSinteticoCliente()
        { }
    }
}
