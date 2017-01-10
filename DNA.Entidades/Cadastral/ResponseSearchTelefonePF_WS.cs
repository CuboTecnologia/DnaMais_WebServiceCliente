﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchTelefonePF_WS
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public List<Entidades.Cadastral.ResponseSearchTelPFDadosPessoais> ListResponseSearchTelPFDadosPessoais { get; set; }

        public ResponseSearchTelefonePF_WS()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.ListResponseSearchTelPFDadosPessoais = new List<Entidades.Cadastral.ResponseSearchTelPFDadosPessoais>();
        }
    }
}
