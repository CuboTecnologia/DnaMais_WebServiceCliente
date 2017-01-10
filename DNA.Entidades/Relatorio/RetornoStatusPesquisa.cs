using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Relatorio
{
    public class RetornoStatusPesquisa
    {
        public string StatusConsulta { get; set; }
        public DateTime? DataSolicitacao { get; set; }

        public RetornoStatusPesquisa()
        { }
    }
}
