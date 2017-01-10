using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class Vinculo
    {
        public String CPF { get; set; }
        public String Nome { get; set; }

        public Vinculo()
        {
            this.CPF = String.Empty;
            this.Nome = String.Empty;
        }
    }
}
