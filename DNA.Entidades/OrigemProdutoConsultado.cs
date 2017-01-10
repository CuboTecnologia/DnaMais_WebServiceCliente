using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class OrigemProdutoConsultado
    {
        public int IdOrigemProdutoConsultado { get; set; }
        public string NomeProduto { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime? DataAltercao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public Entidades.FornecedorConsulta FornecedorConsultaVeicular { get; set; }

        public OrigemProdutoConsultado()
        {
            this.IdOrigemProdutoConsultado = 0;
            this.NomeProduto = string.Empty;
            this.Observacao = string.Empty;
            this.DataInclusao = null;
            this.IdUsuarioInclusao = 0;
            this.DataAltercao = null;
            this.IdUsuarioAlteracao = 0;
            this.FornecedorConsultaVeicular = null;
        }
    }
}
