using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchTelefonePF
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string NomeMae { get; set; }


        public ResponseSearchTelefonePF()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.CPF = string.Empty;
            this.Nome = string.Empty;
            this.DataNascimento = string.Empty;
            this.NomeMae = string.Empty;
        }
    }
}
