using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class UF
    {
        public int IdUF { get; set; }
        public string NomeUF { get; set; }
        public List<Entidades.Cadastral.Cidade> Cidades { get; set; }

        public UF()
        {
            this.IdUF = 0;
            this.NomeUF = string.Empty;
            this.Cidades = new List<Entidades.Cadastral.Cidade>();
        }
    }
}
