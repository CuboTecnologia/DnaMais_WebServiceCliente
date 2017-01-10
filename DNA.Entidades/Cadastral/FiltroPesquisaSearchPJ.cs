using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class FiltroPesquisaSearchPJ
    {
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }

        public FiltroPesquisaSearchPJ()
        {
            this.Nome = string.Empty;
            this.UF = string.Empty;
            this.Cidade = string.Empty;
        }
    }
}
