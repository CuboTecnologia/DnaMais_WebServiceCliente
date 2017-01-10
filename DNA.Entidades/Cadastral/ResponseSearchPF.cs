using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchPF
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string DataNascimento { get; set; }
        public string NomeMae { get; set; }

        public ResponseSearchPF()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.CPF = string.Empty;
            this.Nome = string.Empty;
            this.UF = string.Empty;
            this.Cidade = string.Empty;
            this.DataNascimento = string.Empty;
            this.NomeMae = string.Empty;
        }
    }
}
