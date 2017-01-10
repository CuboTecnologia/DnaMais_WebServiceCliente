using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class QSA_PJ
    {
        public String Cnpj { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String Qualificacao { get; set; }
        public String DataEntradaSociedade { get; set; }
        public String ValorParticipacao { get; set; }

        public QSA_PJ()
        {
            this.Cnpj = String.Empty;
            this.RazaoSocial = String.Empty;
            this.NomeFantasia = String.Empty;
            this.Qualificacao = String.Empty;
            this.DataEntradaSociedade = String.Empty;
            this.ValorParticipacao = String.Empty;
        }
    }
}
