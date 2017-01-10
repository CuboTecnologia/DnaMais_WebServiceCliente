using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class FornecedorConsulta
    {
        public int IdFornecedor { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string DocumentoCnpjCpf { get; set; }
        public string NumeroInscricaoEstadualRG { get; set; }
        public string NomeContato { get; set; }
        public string EmailContato1 { get; set; }
        public string EmailContato2 { get; set; }
        public string TelefoneContato1 { get; set; }
        public string TelefoneContato2 { get; set; }
        public string FaxContato { get; set; }
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string ComplementoEndereco { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string FlagPJ { get; set; }
        public string FlagPF { get; set; }
        public string FlagOrgaoPublico { get; set; }
        public string ObservacaoGeral { get; set; }
        public string FlagAtivo { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public List<Entidades.OrigemProdutoConsultado> Produtos { get; set; }


        public FornecedorConsulta()
        {
            this.IdFornecedor = 0;
            this.RazaoSocial = string.Empty;
            this.NomeFantasia = string.Empty;
            this.DocumentoCnpjCpf = string.Empty;
            this.NumeroInscricaoEstadualRG = string.Empty;
            this.NomeContato = string.Empty;
            this.EmailContato1 = string.Empty;
            this.EmailContato2 = string.Empty;
            this.TelefoneContato1 = string.Empty;
            this.TelefoneContato2 = string.Empty;
            this.FaxContato = string.Empty;
            this.Logradouro = string.Empty;
            this.NumeroEndereco = string.Empty;
            this.ComplementoEndereco = string.Empty;
            this.Bairro = string.Empty;
            this.Municipio = string.Empty;
            this.UF = string.Empty;
            this.CEP = string.Empty;
            this.FlagPJ = string.Empty;
            this.FlagPF = string.Empty;
            this.FlagOrgaoPublico = string.Empty;
            this.ObservacaoGeral = string.Empty;
            this.FlagAtivo = string.Empty;
            this.DataInclusao = null;
            this.IdUsuarioInclusao = 0;
            this.DataAlteracao = null;
            this.IdUsuarioAlteracao = 0;
            this.Produtos = new List<Entidades.OrigemProdutoConsultado>();
        }
    }
}
