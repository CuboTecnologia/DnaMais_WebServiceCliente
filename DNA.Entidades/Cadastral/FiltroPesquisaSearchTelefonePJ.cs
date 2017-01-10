using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class FiltroPesquisaSearchTelefonePJ
    {
        public string DDD { get; set; }
        public string NumeroTel { get; set; }

        public FiltroPesquisaSearchTelefonePJ()
        {
            this.DDD = string.Empty;
            this.NumeroTel = string.Empty;
        }
    }
}
