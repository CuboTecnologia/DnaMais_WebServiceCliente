using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA.Entidades
{
    public class Produto
    {
        public string CodigoProduto { get; set; }
        public string CodigoItemProduto { get; set; }
        public string NomeProduto { get; set; }
        public string NomeInterno { get; set; }
        public string LinkImagem1 { get; set; }
        public string LinkImagem2 { get; set; }
        public string LinkImagem3 { get; set; }
        public string LinkNavegacaoWeb { get; set; }
        public string DescricaoProduto { get; set; }
        public Decimal PrecoProduto { get; set; }
        public Decimal? DescontoOferecidoPrecoProduto { get; set; }
        public DateTime? DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public string FlagAtivoProduto { get; set; }
        public string FlagProdutoWebService { get; set; }
        public string FlagAtivoPrecoProduto { get; set; }
        public int? IdUsuarioInclusaoProduto { get; set; }
        public int? IdUsuarioAlteracaoProduto { get; set; }
        public int? IdUsuarioInclusaoPrecoProduto { get; set; }
        public int? IdUsuarioAlteracaoPrecoProduto { get; set; }
        public DateTime? DataInclusaoProduto { get; set; }
        public DateTime? DataAlteracaoProduto { get; set; }
        public DateTime? DataInclusaoPrecoProduto { get; set; }
        public DateTime? DataAlteracaoPrecoProduto { get; set; }
        public Categoria CategoriaProduto { get; set; }

        public Produto()
        {
            this.CodigoProduto = string.Empty;
            this.CodigoItemProduto = string.Empty;
            this.NomeProduto = string.Empty;
            this.NomeInterno = string.Empty;
            this.LinkImagem1 = string.Empty;
            this.LinkImagem2 = string.Empty;
            this.LinkImagem3 = string.Empty;
            this.LinkNavegacaoWeb = string.Empty;
            this.DescricaoProduto = string.Empty;
            this.PrecoProduto = 0;
            this.DataInicioVigencia = null;
            this.DataFimVigencia = null;
            this.FlagAtivoProduto = string.Empty; 
            this.FlagProdutoWebService = string.Empty; 
            this.FlagAtivoPrecoProduto = string.Empty; 
            this.IdUsuarioInclusaoProduto = 0;
            this.IdUsuarioAlteracaoProduto = 0;
            this.IdUsuarioInclusaoPrecoProduto = 0;
            this.IdUsuarioAlteracaoPrecoProduto = 0;
            this.DataInclusaoProduto = null;
            this.DataAlteracaoProduto = null;
            this.DataInclusaoPrecoProduto = null;
            this.DataAlteracaoPrecoProduto = null;
            this.DescontoOferecidoPrecoProduto = 0;
            this.CategoriaProduto = new Categoria();
        }

        public Produto(string CodigoProduto, string codigoItemProduto, string nomeProduto, string descricaoProduto, Decimal precoProduto,
                       DateTime? dataInicioVigencia, DateTime? dataFimVigencia, string flagAtivoProduto, string flagAtivoPrecoProduto,
                       int? idUsuarioInclusaoProduto, int? idUsuarioAlteracaoProduto, int idUsuarioInclusaoPrecoProduto,
                       int? idUsuarioAlteracaoPrecoProduto, DateTime dataInclusaoProduto, DateTime? dataAlteracaoProduto,
                       DateTime dataInclusaoPrecoProduto, DateTime? dataAlteracaoPrecoProduto, Decimal? descontoOferecidoPrecoProduto,
                       string linkImagem1, string linkImagem2, string linkImagem3, string flagProdutoWebService, string nomeInterno,
                       string linkNavegacaoWeb)
        {
            this.DescontoOferecidoPrecoProduto = 0;
            this.CodigoProduto = string.Empty;
            this.CodigoItemProduto = string.Empty;
            this.NomeProduto = string.Empty;
            this.NomeInterno = string.Empty;
            this.LinkImagem1 = string.Empty;
            this.LinkImagem2 = string.Empty;
            this.LinkImagem3 = string.Empty;
            this.LinkNavegacaoWeb = string.Empty;
            this.DescricaoProduto = string.Empty;
            this.PrecoProduto = 0;
            this.DataInicioVigencia = null;
            this.DataFimVigencia = null;
            this.FlagAtivoProduto = string.Empty; 
            this.FlagProdutoWebService = string.Empty; 
            this.FlagAtivoPrecoProduto = string.Empty; 
            this.IdUsuarioInclusaoProduto = 0;
            this.IdUsuarioAlteracaoProduto = 0;
            this.IdUsuarioInclusaoPrecoProduto = 0;
            this.IdUsuarioAlteracaoPrecoProduto = 0;
            this.DataInclusaoProduto = null;
            this.DataAlteracaoProduto = null;
            this.DataInclusaoPrecoProduto = null;
            this.DataAlteracaoPrecoProduto = null;

            this.CodigoProduto = CodigoProduto;
            this.CodigoItemProduto = codigoItemProduto;
            this.NomeProduto = nomeProduto;
            this.NomeInterno = nomeInterno;
            this.LinkImagem1 = linkImagem1;
            this.LinkImagem2 = linkImagem2;
            this.LinkImagem3 = linkImagem3;
            this.LinkNavegacaoWeb = linkNavegacaoWeb;
            this.DescricaoProduto = descricaoProduto;
            this.PrecoProduto = precoProduto;
            this.DataInicioVigencia = dataInicioVigencia;
            this.DataFimVigencia = dataFimVigencia;
            this.FlagAtivoProduto = flagAtivoProduto;
            this.FlagProdutoWebService = flagProdutoWebService;
            this.FlagAtivoPrecoProduto = flagAtivoPrecoProduto;
            this.IdUsuarioInclusaoProduto = idUsuarioInclusaoProduto;
            this.IdUsuarioAlteracaoProduto = idUsuarioAlteracaoProduto;
            this.IdUsuarioInclusaoPrecoProduto = idUsuarioInclusaoPrecoProduto;
            this.IdUsuarioAlteracaoPrecoProduto = idUsuarioAlteracaoPrecoProduto;
            this.DataInclusaoProduto = dataInclusaoProduto;
            this.DataAlteracaoProduto = dataAlteracaoProduto;
            this.DataInclusaoPrecoProduto = dataInclusaoPrecoProduto;
            this.DataAlteracaoPrecoProduto = dataAlteracaoPrecoProduto;
            this.DescontoOferecidoPrecoProduto = descontoOferecidoPrecoProduto;

        }


    }
}
