using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DNA.Negocios
{
    public class Produtos
    {
        public List<Entidades.Produto> ListarByIdUsuario(Entidades.Usuario user)
        {
            List<Entidades.Produto> lProd = new List<Entidades.Produto>();
            Dados.Produtos negProd = new Dados.Produtos();

            DataTable dtProdutos = new DataTable();

            try
            {
                negProd.ListarByIdUsuario(user, ref dtProdutos);

                foreach (DataRow drProd in dtProdutos.Rows)
                {
                    Entidades.Produto retProd = new Entidades.Produto();

                    retProd.CodigoProduto = drProd["CD_PRODUTO"].ToString();
                    retProd.NomeProduto = drProd["NM_PRODUTO"].ToString();
                    retProd.DescricaoProduto = drProd["DS_PRODUTO"].ToString();

                    //****************   As colunas abaixo existiam no WS mas não foram localizadas no novo modelo DNASITE

                    //retProd.NomeInterno = drProd["NOME_INTERNO_PRODUTO"].ToString();
                    //retProd.LinkImagem1 = drProd["LINK_IMAGEM_1_PRODUTO"].ToString();
                    //retProd.LinkImagem2 = drProd["LINK_IMAGEM_2_PRODUTO"].ToString();
                    //retProd.LinkImagem3 = drProd["LINK_IMAGEM_3_PRODUTO"].ToString();
                    //retProd.LinkNavegacaoWeb = drProd["LINK_NAVEGACAO_WEB_PRODUTO"].ToString();
                    //retProd.FlagProdutoWebService = drProd["FLAG_WEBSERVICE_PRODUTO"].ToString();
                    //retProd.FlagAtivoProduto = drProd["FLAG_ATIVO_PRODUTO"].ToString();
                    //retProd.DataInclusaoProduto = DateTime.Parse(drProd["DATA_INCLUSAO_PRODUTO"].ToString());
                    //retProd.IdUsuarioInclusaoProduto = int.Parse(drProd["ID_USUARIO_INCLUSAO_PRODUTO"].ToString());

                    //if (!drProd["DATA_ALTERACAO_PRODUTO"].ToString().Equals(""))
                    //{ retProd.DataAlteracaoProduto = DateTime.Parse(drProd["DATA_ALTERACAO_PRODUTO"].ToString()); }

                    //if (!drProd["ID_USUARIO_ALTERACAO_PRODUTO"].ToString().Equals(""))
                    //{ retProd.IdUsuarioAlteracaoProduto = int.Parse(drProd["ID_USUARIO_ALTERACAO_PRODUTO"].ToString()); }

                    //retProd.IdPrecoProduto = int.Parse(drProd["ID_PP"].ToString());
                    //retProd.PrecoProduto = Decimal.Parse(drProd["PRECO_PRODUTO"].ToString());

                    //if (!drProd["DATA_INICIO_VIGENCIA_PP"].ToString().Equals(""))
                    //{ retProd.DataInicioVigencia = DateTime.Parse(drProd["DATA_INICIO_VIGENCIA_PP"].ToString()); }

                    //if (!drProd["DATA_FIM_VIGENCIA_PP"].ToString().Equals(""))
                    //{ retProd.DataInicioVigencia = DateTime.Parse(drProd["DATA_FIM_VIGENCIA_PP"].ToString()); }

                    //retProd.FlagAtivoPrecoProduto = drProd["FLAG_ATIVO_PP"].ToString();

                    //if (!drProd["DATA_INCLUSAO_PP"].ToString().Equals(""))
                    //{ retProd.DataInclusaoPrecoProduto = DateTime.Parse(drProd["DATA_INCLUSAO_PP"].ToString()); }

                    //if (!drProd["ID_USUARIO_INCLUSAO_PP"].ToString().Equals(""))
                    //{ retProd.IdUsuarioInclusaoPrecoProduto = int.Parse(drProd["ID_USUARIO_INCLUSAO_PP"].ToString()); }

                    //if (!drProd["DATA_ALTERACAO_PP"].ToString().Equals(""))
                    //{ retProd.DataAlteracaoPrecoProduto = DateTime.Parse(drProd["DATA_ALTERACAO_PP"].ToString()); }

                    //if (!drProd["ID_USUARIO_ALTERACAO_PP"].ToString().Equals(""))
                    //{ retProd.IdUsuarioAlteracaoPrecoProduto = int.Parse(drProd["ID_USUARIO_ALTERACAO_PP"].ToString()); }

                    lProd.Add(retProd);
                }

                return lProd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
