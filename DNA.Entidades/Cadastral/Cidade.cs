using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public Entidades.Cadastral.UF UF { get; set; }

        public Cidade()
        {
            this.IdCidade = 0;
            this.Nome = string.Empty;
            this.UF = new Entidades.Cadastral.UF();
        }
    }
}
