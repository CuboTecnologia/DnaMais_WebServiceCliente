using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class EnderecoByCEP
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public EnderecoByCEP()
        {
            this.Logradouro = string.Empty;
            this.Bairro = string.Empty;
            this.Cidade = string.Empty;
            this.Estado = string.Empty;
            this.UF = string.Empty;
            this.CEP = string.Empty;
        }

        public EnderecoByCEP(string logradouro, string bairro, string cidade, string estado, string uf, string cep)
        {
            this.Logradouro = string.Empty;
            this.Bairro = string.Empty;
            this.Cidade = string.Empty;
            this.UF = string.Empty;
            this.CEP = string.Empty;
            this.Estado = string.Empty;
            
            this.Logradouro = logradouro;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.UF = uf;
            this.Estado = estado;
            this.CEP = cep;

        }

    }
}
