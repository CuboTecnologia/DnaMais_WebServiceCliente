using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdCliente { get; set; }
        public string NomeUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Observacao { get; set; }
        public string FlagAtivo { get; set; }
        public string IpClienteLogado { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int? IdUsuarioInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public List<Entidades.PerfilAcesso> Perfil { get; set; }
        public List<Entidades.Produto> Produtos { get; set; }
        public Entidades.Cliente Cliente { get; set; }

        public Usuario()
        {
            this.IdUsuario = 0;
            this.IdCliente = 0;
            this.NomeUsuario = string.Empty;
            this.LoginUsuario = string.Empty;
            this.SenhaUsuario = string.Empty;
            this.Email1 = string.Empty;
            this.Email2 = string.Empty;
            this.Observacao = string.Empty;
            this.FlagAtivo = string.Empty;
            this.DataInclusao = null;
            this.IdUsuarioInclusao = null;
            this.DataAlteracao = null;
            this.IdUsuarioAlteracao = null;
            this.IpClienteLogado = string.Empty;
            this.Perfil = new List<PerfilAcesso>();
            this.Produtos = new List<Produto>();
            this.Cliente = new Cliente();
        }

        public Usuario(int idUsuario, int? idCliente, string nomeUsuario, string loginUsuario, string senhaUsuario,
                       string flagAtivo, DateTime? dataInclusao, int? idUsuarioInclusao, DateTime? dataAlteracao,
                       int? idUsuarioAlteracao, List<Entidades.PerfilAcesso> perfil, string ipClienteLogado,
                       string email1, string email2, string obeservacao, List<Entidades.Produto> produtos, 
                       Entidades.Cliente cliente)
        {
            this.IdUsuario = 0;
            this.IdCliente = 0;
            this.NomeUsuario = string.Empty;
            this.LoginUsuario = string.Empty;
            this.SenhaUsuario = string.Empty;
            this.FlagAtivo = null;
            this.DataInclusao = null;
            this.IdUsuarioInclusao = null;
            this.DataAlteracao = null;
            this.IdUsuarioAlteracao = null;
            this.Perfil = null;
            this.IpClienteLogado = string.Empty;
            this.Email1 = string.Empty;
            this.Email2 = string.Empty;
            this.Observacao = string.Empty;
            this.Produtos = null;
            this.Cliente = new Cliente();
            this.Produtos = new List<Produto>();
            this.Perfil = new List<PerfilAcesso>();

            this.IdUsuario = idUsuario;
            this.IdCliente = idCliente;
            this.NomeUsuario = nomeUsuario;
            this.LoginUsuario = loginUsuario;
            this.SenhaUsuario = senhaUsuario;
            this.Email1 = email1;
            this.Email2 = email2;
            this.Observacao = obeservacao;
            this.FlagAtivo = flagAtivo;
            this.DataInclusao = dataInclusao;
            this.IdUsuarioInclusao = idUsuarioInclusao;
            this.DataAlteracao = dataAlteracao;
            this.IpClienteLogado = ipClienteLogado;
            this.IdUsuarioAlteracao = idUsuarioAlteracao;
            this.Produtos = produtos;
            this.Perfil = perfil;
            this.Cliente = cliente;
        }
    }
}
