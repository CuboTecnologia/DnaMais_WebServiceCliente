using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchPJ
    {
        public Entidades.Cadastral.Controle Controle { get; set; }
        public Entidades.Cadastral.ResponseStatus ResponseStatus { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }


        public ResponseSearchPJ()
        {
            this.Controle = new Entidades.Cadastral.Controle();
            this.ResponseStatus = new ResponseStatus();
            this.CNPJ = string.Empty;
            this.RazaoSocial = string.Empty;
            this.NomeFantasia = string.Empty;
            this.UF = string.Empty;
            this.Cidade = string.Empty;
        }
    }
}
