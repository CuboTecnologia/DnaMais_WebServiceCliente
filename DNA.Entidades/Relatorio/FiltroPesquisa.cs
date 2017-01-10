using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Relatorio
{
    public class FiltroPesquisa
    {
        public int IdUsuarioLogado { get; set; }
        public int IdCliente { get; set; }
        public int IdHitoricoPesquisa { get; set; }
        public int IdProdutoPreco { get; set; }
        public DateTime? DataInicialPesquisa { get; set; }
        public DateTime? DataFinalPesquisa { get; set; }
        public string ParametroPesquisado { get; set; }
        public string TipoParametroPesquisado { get; set; }

        public FiltroPesquisa()
        {
            this.IdCliente = 0;
            this.IdUsuarioLogado = 0;
            this.IdHitoricoPesquisa = 0;
            this.IdProdutoPreco = 0;
            this.ParametroPesquisado = string.Empty;
            this.TipoParametroPesquisado = string.Empty;
        }
    }
}
