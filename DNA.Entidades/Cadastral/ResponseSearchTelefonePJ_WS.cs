using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchTelefonePJ_WS
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public List<Entidades.Cadastral.ResponseSearchTelPJDadosEmpresa> ListResponseSearchTelPJDadosEmpresa { get; set; }

        public ResponseSearchTelefonePJ_WS()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.ListResponseSearchTelPJDadosEmpresa = new List<Entidades.Cadastral.ResponseSearchTelPJDadosEmpresa>();
        }
    }
}
