using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class PerfilAcesso
    {
        public int IdPerfilAcesso { get; set; }
        public int IdUsuario { get; set; }
        public int IdPerfilAcessoUsuario { get; set; }
        public string DescricaoPerfilAcesso { get; set; }
        public DateTime? DataInclusaoPerfilAcesso { get; set; }
        public int? IdUsuarioInclusaoPerfilAcesso { get; set; }
        public DateTime? DataAlteracaoPerfilAcesso { get; set; }
        public int? IdUsuarioAlterasaoPerfilAcesso { get; set; }
        public string FlagAtivoPerfilAcesso { get; set; }

        public string NomeUsuarioInclusao { get; set; }
        public string NomeUsuarioAlteracao { get; set; }


        public PerfilAcesso()
        {
            this.IdPerfilAcessoUsuario = 0;
            this.IdPerfilAcesso = 0;
            this.IdUsuario = 0;
            this.DescricaoPerfilAcesso = string.Empty;
            this.DataInclusaoPerfilAcesso = null;
            this.IdUsuarioInclusaoPerfilAcesso = 0;
            this.DataAlteracaoPerfilAcesso = null;
            this.IdUsuarioAlterasaoPerfilAcesso = null;
            this.FlagAtivoPerfilAcesso = string.Empty;
            this.NomeUsuarioInclusao = string.Empty;
            this.NomeUsuarioAlteracao = string.Empty;
        }

        public PerfilAcesso(int idPerfilAcesso, string descricaoPerfilAcesso, DateTime? dataInclusaoPerfilAcesso,
                            int? idUsuarioInclusaoPerfilAcesso, DateTime? dataAlteracaoPerfilAcesso,
                            int? idUsuarioAlterasaoPerfilAcesso, string flagAtivoPerfilAcesso, string nomeUsuarioInclusao,
                            string nomeUsuarioAlteracao, int idUsuario)
        {
            this.IdPerfilAcesso = 0;
            this.DescricaoPerfilAcesso = string.Empty;
            this.DataInclusaoPerfilAcesso = null;
            this.IdUsuarioInclusaoPerfilAcesso = 0;
            this.DataAlteracaoPerfilAcesso = null;
            this.IdUsuarioAlterasaoPerfilAcesso = null;
            this.FlagAtivoPerfilAcesso = null;
            this.NomeUsuarioInclusao = string.Empty;
            this.NomeUsuarioAlteracao = string.Empty;
            this.IdUsuario = 0;

            this.IdPerfilAcesso = idPerfilAcesso;
            this.DescricaoPerfilAcesso = descricaoPerfilAcesso;
            this.DataInclusaoPerfilAcesso = dataInclusaoPerfilAcesso;
            this.IdUsuarioInclusaoPerfilAcesso = idUsuarioInclusaoPerfilAcesso;
            this.DataAlteracaoPerfilAcesso = dataAlteracaoPerfilAcesso;
            this.IdUsuarioAlterasaoPerfilAcesso = idUsuarioAlterasaoPerfilAcesso;
            this.FlagAtivoPerfilAcesso = flagAtivoPerfilAcesso;
            this.NomeUsuarioInclusao = nomeUsuarioInclusao;
            this.NomeUsuarioAlteracao = nomeUsuarioAlteracao;
            this.IdUsuario = idUsuario;
        }
    }
}
