using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral.SISCOM
{
    public class DadosCadastrais
    {
        public String CPF { get; set; }
        public String Nome { get; set; }
        public String RG { get; set; }

        public DadosCadastrais()
        {
            this.CPF = String.Empty;
            this.Nome = String.Empty;
            this.RG = String.Empty;
        }
    }
}
