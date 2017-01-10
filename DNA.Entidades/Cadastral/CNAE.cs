using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class CNAE
    {
        public String Codigo { get; set; }
        public String Descricao { get; set; }
        public String Grupo { get; set; }
        public String Industria { get; set; }
        public String ComercioServico { get; set; }
        public String Ordem { get; set; }
        public String OrdemDescricao { get; set; }
        public String Flag { get; set; }

        public CNAE()
        {
            this.Codigo = String.Empty;
            this.Descricao = String.Empty;
            this.Grupo = String.Empty;
            this.Industria = String.Empty;
            this.ComercioServico = String.Empty;
            this.Ordem = String.Empty;
            this.OrdemDescricao = String.Empty;
            this.Flag = String.Empty;
        }
    }
}
