using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class QSA
    {
        public String Cnpj { get; set; }
        public String DocumentoSocio { get; set; }
        public String NomeSocio { get; set; }
        public String Qualificacao { get; set; }
        public String DataEntradaSociedade { get; set; }
        public String ValorParticipacao { get; set; }
        public String TipoPessoa { get; set; }

        public QSA()
        {
            this.Cnpj = String.Empty;
            this.DocumentoSocio = String.Empty;
            this.NomeSocio = String.Empty;
            this.Qualificacao = String.Empty;
            this.DataEntradaSociedade = String.Empty;
            this.ValorParticipacao = String.Empty;
            this.TipoPessoa = String.Empty;
        }
    }
}
