using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class PEP
    {
        public String CPF { get; set; }
        public String Cargo { get; set; }
        public String Nome { get; set; }
        public String Orgao { get; set; }
        public String Vinculo { get; set; }

        public PEP()
        {
            this.CPF = String.Empty;
            this.Cargo = String.Empty;
            this.Nome = String.Empty;
            this.Orgao = String.Empty;
            this.Vinculo = String.Empty;
        }
    }
}
