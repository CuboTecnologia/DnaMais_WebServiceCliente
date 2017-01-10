using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class ResponseSearchPJDadosEmpresa
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }

        public ResponseSearchPJDadosEmpresa()
        {
            this.CNPJ = string.Empty;
            this.RazaoSocial = string.Empty;
            this.NomeFantasia = string.Empty;
            this.UF = string.Empty;
            this.Cidade = string.Empty;
        }
    }
}
