using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class FiltroPesquisaMoradoresMesmoEndereco
    {
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public FiltroPesquisaMoradoresMesmoEndereco()
        {
            this.Cep = string.Empty;
            this.UF = string.Empty;
            this.Cidade = string.Empty;

            this.Bairro = string.Empty;
            this.Logradouro = string.Empty;
            this.Numero = string.Empty;
        }
    }
}
