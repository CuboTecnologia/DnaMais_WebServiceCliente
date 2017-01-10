using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchPF_WS
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public List<Entidades.Cadastral.ResponseSearchPFDadosPessoais> ListResponseSearchPFDadosPessoais { get; set; }

        public ResponseSearchPF_WS()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.ListResponseSearchPFDadosPessoais = new List<Entidades.Cadastral.ResponseSearchPFDadosPessoais>();
        }
    }
}
