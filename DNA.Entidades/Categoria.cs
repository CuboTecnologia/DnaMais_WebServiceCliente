using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FlagAtivo { get; set; }
        public DateTime? DataInclusao{ get; set; }
        public int? IdUsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }

        public Categoria()
        {
            this.IdCategoria = 0;
            this.Nome = string.Empty;
            this.Descricao = string.Empty;
            this.FlagAtivo = string.Empty;
        }
    }

}
