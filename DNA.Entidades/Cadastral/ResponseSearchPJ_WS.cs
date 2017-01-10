using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchPJ_WS
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public List<Entidades.Cadastral.ResponseSearchPJDadosEmpresa> ListResponseSearchPFDadosEmpresa { get; set; }

        public ResponseSearchPJ_WS()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.ListResponseSearchPFDadosEmpresa = new List<Entidades.Cadastral.ResponseSearchPJDadosEmpresa>();
        }
    }
}
