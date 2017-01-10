using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class DadosCadastraisPJ
    {
        public String CNPJ { get; set; }
        public String RazaoSocial { get; set; }
        public String MatrizFilial { get; set; }
        public String DataAbertura { get; set; }
        public String NomeFantasia { get; set; }
        public String NaturezaJuridica { get; set; }
        public String SituacaoCadastral { get; set; }
        public String DataSituacaoDastral { get; set; }

        public DadosCadastraisPJ()
        {
            this.CNPJ = String.Empty;
            this.RazaoSocial = String.Empty;
            this.MatrizFilial = String.Empty;
            this.DataAbertura = String.Empty;
            this.NomeFantasia = String.Empty;
            this.NaturezaJuridica = String.Empty;
            this.SituacaoCadastral = String.Empty;
            this.DataSituacaoDastral = String.Empty;
        }
    }
}
