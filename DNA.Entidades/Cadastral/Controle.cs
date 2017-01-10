using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class Controle
    {
        public String Codigo { get; set; }
        public String DataHora { get; set; }
        public String Mensagem { get; set; }
        public String Protocolo { get; set; }


        public Controle()
        {
            this.Codigo = String.Empty;
            this.DataHora = String.Empty;
            this.Mensagem = String.Empty;
            this.Protocolo = String.Empty;
        }
    }
}
