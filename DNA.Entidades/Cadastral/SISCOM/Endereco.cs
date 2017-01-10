using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class Endereco
    {
        public String Bairro { get; set; }
        public String CEP { get; set; }
        public String Cidade { get; set; }
        public String Complemento { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String UF { get; set; }

        public Endereco()
        {
            this.Bairro = String.Empty;
            this.CEP = String.Empty;
            this.Cidade = String.Empty;
            this.Complemento = String.Empty;
            this.Logradouro = String.Empty;
            this.Numero = String.Empty;
            this.UF = String.Empty;
        }
    }
}
