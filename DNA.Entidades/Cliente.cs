using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string NumeroDocCPFCNPJ { get; set; }
        public string TipoPessoa { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoMunicipio { get; set; }
        public string EnderecoUF { get; set; }
        public string EnderecoCEP { get; set; }
        public string DataNascimento { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Sexo { get; set; }
        public string Observacao { get; set; }
        public string DDDTelComercial { get; set; }
        public string NumeroTelComercial { get; set; }
        public string NumeroTelComercialRamal { get; set; }
        public string DDDTelResidencial { get; set; }
        public string NumeroTelResidencial { get; set; }
        public string DDDCelular { get; set; }
        public string NumeroCelular { get; set; }
        public string FlagAtivo { get; set; }
        public string FlagExcluido { get; set; }
        public int? IdUsuarioInclusaoCliente { get; set; }
        public int? IdUsuarioAlteracaoCliente { get; set; }
        public DateTime? DataInclusaoCliente { get; set; }
        public DateTime? DataAlteracaoCliente { get; set; }
        public List<Entidades.Usuario> Usuarios { get; set; }
        public List<Entidades.Produto> Produtos { get; set; }

        public Cliente()
        {
            this.IdCliente = 0;
            this.NomeRazaoSocial = string.Empty;
            this.NomeFantasia = string.Empty;
            this.NumeroDocCPFCNPJ = string.Empty;
            this.TipoPessoa = string.Empty;
            this.EnderecoLogradouro = string.Empty;
            this.EnderecoNumero = string.Empty;
            this.EnderecoComplemento = string.Empty;
            this.EnderecoBairro = string.Empty;
            this.EnderecoMunicipio = string.Empty;
            this.EnderecoUF = string.Empty;
            this.EnderecoCEP = string.Empty;
            this.DataNascimento = string.Empty;
            this.Email1 = string.Empty;
            this.Email2 = string.Empty;
            this.Sexo = string.Empty;
            this.Observacao = string.Empty;
            this.DDDTelComercial = string.Empty;
            this.NumeroTelComercial = string.Empty;
            this.NumeroTelComercialRamal = string.Empty;
            this.DDDTelResidencial = string.Empty;
            this.NumeroTelResidencial = string.Empty;
            this.DDDCelular = string.Empty;
            this.NumeroCelular = string.Empty;
            this.FlagAtivo = string.Empty;
            this.FlagExcluido = string.Empty;
            this.IdUsuarioInclusaoCliente = 0;
            this.IdUsuarioAlteracaoCliente = 0;
            this.DataInclusaoCliente = null;
            this.DataAlteracaoCliente = null;
            this.Usuarios = new List<Usuario>();
            this.Produtos = new List<Produto>();
        }

    }
}
