using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades.Cadastral
{
    public class DadosCadastraisPF
    {
        public String CPF { get; set; }
        public String ClasseSocial { get; set; }
        public String DataNascimento { get; set; }
        public String Escolaridade { get; set; }
        public String EstadoCivil { get; set; }
        public String Idade { get; set; }
        public String Nome { get; set; }
        public String NomeMae { get; set; }
        public String RG { get; set; }
        public String RendaEstimada { get; set; }
        public String Sexo { get; set; }
        public String Signo { get; set; }
        public String StatusCPF { get; set; }
        public String TituloEleitoral { get; set; }
        public String Obito { get; set; }
        public String DataObito { get; set; }

        public DadosCadastraisPF()
        {
            this.CPF = String.Empty;
            this.CPF = String.Empty;
            this.ClasseSocial = String.Empty;
            this.DataNascimento = String.Empty;
            this.Escolaridade = String.Empty;
            this.EstadoCivil = String.Empty;
            this.Idade = String.Empty;
            this.Nome = String.Empty;
            this.NomeMae = String.Empty;
            this.RG = String.Empty;
            this.RendaEstimada = String.Empty;
            this.Sexo = String.Empty;
            this.Signo = String.Empty;
            this.StatusCPF = String.Empty;
            this.TituloEleitoral = String.Empty;
            this.Obito = String.Empty;
            this.DataObito = String.Empty;
        }
    }
}
