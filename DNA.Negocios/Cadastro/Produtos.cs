using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DNA.Negocios.Cadastro
{
    public class Produtos
    {
        private DateTime DataBR = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

        public bool Incluir(Entidades.Produto prod)
        {
            try
            {
                #region Codigo
                
                //Linq.CheckLogDBDataContext dc = new Linq.CheckLogDBDataContext(Linq.ConnectionString.GetStringConnCheckLog);

                //dc.Connection.Open();

                //using (System.Data.Common.DbTransaction trans = dc.Connection.BeginTransaction())
                //{
                //    try
                //    {
                //        dc.Transaction = trans;

                //        Linq.PRODUTO p = new Linq.PRODUTO();

                //        p.NOME = prod.NomeProduto;
                //        p.DESCRICAO = prod.DescricaoProduto;
                //        p.FLAG_ATIVO = true;
                //        p.DATA_INCLUSAO = DataBR;
                //        p.ID_USUARIO_INCLUSAO = prod.IdUsuarioInclusaoProduto == null ? 0 : (int)prod.IdUsuarioInclusaoProduto;
                //        p.LINK_IMAGEM_1 = prod.LinkImagem1;
                //        p.LINK_IMAGEM_2 = prod.LinkImagem2;
                //        p.LINK_IMAGEM_3 = prod.LinkImagem3;
                //        p.LINK_NAVEGACAO_WEB = prod.LinkNavegacaoWeb;
                //        p.FLAG_WEBSERVICE = prod.FlagProdutoWebService;

                //        dc.PRODUTOs.InsertOnSubmit(p);
                //        dc.SubmitChanges();

                //        Linq.PRODUTO_PRECO pp = new Linq.PRODUTO_PRECO();

                //        pp.ID_PRODUTO = p.ID;
                //        pp.PRECO = prod.PrecoProduto;
                //        pp.DATA_INICIO_VIGENCIA = DataBR;
                //        pp.FLAG_ATIVO = true;
                //        pp.DATA_INCLUSAO = DataBR;
                //        pp.ID_USUARIO_INCLUSAO = (int)prod.IdUsuarioInclusaoProduto;

                //        dc.PRODUTO_PRECOs.InsertOnSubmit(pp);
                //        dc.SubmitChanges();

                //        trans.Commit();
                //    }
                //    catch (Exception ex)
                //    {
                //        trans.Rollback();
                //        throw ex;
                //    }
                //}

                #endregion

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(Entidades.Produto prod)
        {
            try
            {
                #region Codigo
                
                //Linq.CheckLogDBDataContext dc = new Linq.CheckLogDBDataContext(Linq.ConnectionString.GetStringConnCheckLog);

                //dc.Connection.Open();

                //using (System.Data.Common.DbTransaction trans = dc.Connection.BeginTransaction())
                //{
                //    try
                //    {
                //        dc.Transaction = trans;

                //        Linq.PRODUTO p = dc.PRODUTOs.SingleOrDefault(x => x.ID == prod.IdProduto);

                //        if (p != null)
                //        {
                //            p.NOME = prod.NomeProduto;
                //            p.DESCRICAO = prod.DescricaoProduto;
                //            p.FLAG_ATIVO = prod.FlagAtivoProduto;
                //            p.DATA_ALTERACAO = DataBR;
                //            p.ID_USUARIO_ALTERACAO = (int)prod.IdUsuarioAlteracaoProduto;
                //            p.LINK_IMAGEM_1 = prod.LinkImagem1;
                //            p.LINK_IMAGEM_2 = prod.LinkImagem2;
                //            p.LINK_IMAGEM_3 = prod.LinkImagem3;
                //            p.LINK_NAVEGACAO_WEB = prod.LinkNavegacaoWeb;
                //            p.FLAG_WEBSERVICE = prod.FlagProdutoWebService;

                //            dc.SubmitChanges();

                //            Linq.PRODUTO_PRECO pp = dc.PRODUTO_PRECOs.SingleOrDefault(x => x.ID == prod.IdPrecoProduto);

                //            if (pp != null)
                //            {
                //                pp.PRECO = prod.PrecoProduto;
                //                pp.DATA_INICIO_VIGENCIA = DataBR;
                //                pp.FLAG_ATIVO = prod.FlagAtivoPrecoProduto;
                //                pp.DATA_ALTERACAO = DataBR;
                //                pp.ID_USUARIO_ALTERACAO = (int)prod.IdUsuarioAlteracaoProduto;

                //                dc.SubmitChanges();
                //            }

                //            trans.Commit();
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        trans.Rollback();
                //        throw ex;
                //    }
                //}

                #endregion

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.Produto> Listar(Entidades.Produto prod)
        {
            try
            {
                List<Entidades.Produto> l = new List<Entidades.Produto>();

                return l;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.Produto> ListarByIdCliente(Entidades.Cliente cli)
        {
            try
            {
                List<Entidades.Produto> l = new List<Entidades.Produto>();

               

                return l;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.Produto> ListarByIdUsuario(Entidades.Cliente cli)
        {
            try
            {
                List<Entidades.Produto> lRet = new List<Entidades.Produto>();
                Dados.Cadastro.Produtos negProd = new Dados.Cadastro.Produtos();

                DataTable dtProd = new DataTable();

                try
                {
                    negProd.ListarByIdUsuario(cli, ref dtProd);

                    foreach (DataRow drPro in dtProd.Rows)
                    {
                        Entidades.Produto retProd = new Entidades.Produto();

                        #region Dados de Retorno do Produto

                        if (!drPro["CD_PRODUTO"].ToString().Trim().Equals(""))
                        { retProd.CodigoProduto = drPro["CD_PRODUTO"].ToString(); }

                        retProd.NomeInterno = drPro["NOME_INTERNO_PROD"].ToString();
                        retProd.NomeProduto = drPro["NM_PRODUTO"].ToString();
                        retProd.DescricaoProduto = drPro["DESCRICAO_PROD"].ToString();
                        retProd.LinkImagem1 = drPro["LINK_IMAGEM_1"].ToString();
                        retProd.LinkImagem2 = drPro["LINK_IMAGEM_2"].ToString();
                        retProd.LinkImagem3 = drPro["LINK_IMAGEM_3"].ToString();
                        retProd.LinkNavegacaoWeb = drPro["LINK_NAVEGACAO_WEB"].ToString();
                        retProd.FlagProdutoWebService = drPro["FLAG_WEBSERVICE"].ToString();
                        retProd.FlagAtivoProduto = drPro["FLAG_ATIVO_PROD"].ToString();

                        if (!drPro["DATA_INC_PROD"].ToString().Trim().Equals(""))
                        { retProd.DataInclusaoProduto = DateTime.Parse(drPro["DATA_INC_PROD"].ToString()); }

                        if (!drPro["ID_USUARIO_INC_PROD"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioInclusaoProduto = int.Parse(drPro["ID_USUARIO_INC_PROD"].ToString()); }

                        if (!drPro["DATA_ALT_PROD"].ToString().Trim().Equals(""))
                        { retProd.DataAlteracaoProduto = DateTime.Parse(drPro["DATA_ALT_PROD"].ToString()); }

                        if (!drPro["ID_USUARIO_ALT_PROD"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioAlteracaoProduto = int.Parse(drPro["ID_USUARIO_ALT_PROD"].ToString()); }

                        if (!drPro["ID_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.IdCategoria = int.Parse(drPro["ID_CATEGORIA_PROD"].ToString()); }

                        if (retProd.CategoriaProduto == null)
                        { retProd.CategoriaProduto = new Entidades.Categoria(); }

                        retProd.CategoriaProduto.Nome = drPro["NOME_CATEGORIA_PROD"].ToString();
                        retProd.CategoriaProduto.Descricao = drPro["DESC_CATEGORIA_PROD"].ToString();
                        retProd.CategoriaProduto.FlagAtivo = drPro["FLAG_ATIVO_CATEGORIA_PROD"].ToString();

                        if (!drPro["DATA_INC_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.DataInclusao = DateTime.Parse(drPro["DATA_INC_CATEGORIA_PROD"].ToString()); }

                        if (!drPro["DATA_INC_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.IdUsuarioInclusao = int.Parse(drPro["ID_USUARIO_INC_CATEGORIA_PROD"].ToString()); }

                        if (!drPro["DATA_ALT_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.DataAlteracao = DateTime.Parse(drPro["DATA_ALT_CATEGORIA_PROD"].ToString()); }

                        if (!drPro["ID_USUARIO_ALT_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.IdUsuarioAlteracao = int.Parse(drPro["ID_USUARIO_ALT_CATEGORIA_PROD"].ToString()); }
                        
                        #endregion

                        #region Dados de Retorno do Preço Produto

                        if (!drPro["CD_ITEM_PRODUTO"].ToString().Trim().Equals(""))
                        { retProd.CodigoItemProduto = drPro["CD_ITEM_PRODUTO"].ToString(); }

                        if (!drPro["PRECO"].ToString().Trim().Equals(""))
                        { retProd.PrecoProduto = Decimal.Parse(drPro["PRECO"].ToString()); }

                        if (!drPro["DT_INI_VIGE_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.DataInicioVigencia = DateTime.Parse(drPro["DT_INI_VIGE_PROD_PRECO"].ToString()); }

                        retProd.FlagAtivoPrecoProduto = drPro["FLAG_ATIVO_PROD_PRECO"].ToString();

                        if (!drPro["DATA_INC_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.DataInclusaoPrecoProduto = DateTime.Parse(drPro["DATA_INC_PROD_PRECO"].ToString()); }

                        if (!drPro["ID_USUARIO_INC_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioInclusaoPrecoProduto = int.Parse(drPro["ID_USUARIO_INC_PROD_PRECO"].ToString()); }

                        if (!drPro["DATA_ALT_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.DataAlteracaoPrecoProduto = DateTime.Parse(drPro["DATA_ALT_PROD_PRECO"].ToString()); }

                        if (!drPro["ID_USUARIO_ALT_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioAlteracaoPrecoProduto = int.Parse(drPro["ID_USUARIO_ALT_PROD_PRECO"].ToString()); }

                        if (!drPro["DESCONTO_OFERECIDO"].ToString().Trim().Equals(""))
                        { retProd.DescontoOferecidoPrecoProduto = Decimal.Parse(drPro["DESCONTO_OFERECIDO"].ToString()); }

                        #endregion

                        lRet.Add(retProd);
                    }

                    return lRet;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Entidades.Produto> ListarByIdUsuario(Entidades.Usuario usu)
        {
            try
            {
                List<Entidades.Produto> lRet = new List<Entidades.Produto>();
                Dados.Cadastro.Produtos negProd = new Dados.Cadastro.Produtos();

                DataTable dtProd = new DataTable();

                try
                {
                    negProd.ListarByIdUsuario(usu, ref dtProd);

                    foreach (DataRow drPro in dtProd.Rows)
                    {
                        Entidades.Produto retProd = new Entidades.Produto();

                        #region Dados de Retorno do Produto

                        if (!drPro["CD_PRODUTO"].ToString().Trim().Equals(""))
                        { retProd.CodigoProduto = drPro["CD_PRODUTO"].ToString(); }

                        retProd.NomeInterno = drPro["NOME_INTERNO_PROD"].ToString();
                        retProd.NomeProduto = drPro["NM_PRODUTO"].ToString();
                        retProd.DescricaoProduto = drPro["DESCRICAO_PROD"].ToString();
                        retProd.LinkImagem1 = drPro["LINK_IMAGEM_1"].ToString();
                        retProd.LinkImagem2 = drPro["LINK_IMAGEM_2"].ToString();
                        retProd.LinkImagem3 = drPro["LINK_IMAGEM_3"].ToString();
                        retProd.LinkNavegacaoWeb = drPro["LINK_NAVEGACAO_WEB"].ToString();
                        retProd.FlagProdutoWebService = drPro["FLAG_WEBSERVICE"].ToString();
                        retProd.FlagAtivoProduto = drPro["FLAG_ATIVO_PROD"].ToString();

                        if (!drPro["DATA_INC_PROD"].ToString().Trim().Equals(""))
                        { retProd.DataInclusaoProduto = DateTime.Parse(drPro["DATA_INC_PROD"].ToString()); }

                        if (!drPro["ID_USUARIO_INC_PROD"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioInclusaoProduto = int.Parse(drPro["ID_USUARIO_INC_PROD"].ToString()); }

                        if (!drPro["DATA_ALT_PROD"].ToString().Trim().Equals(""))
                        { retProd.DataAlteracaoProduto = DateTime.Parse(drPro["DATA_ALT_PROD"].ToString()); }

                        if (!drPro["ID_USUARIO_ALT_PROD"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioAlteracaoProduto = int.Parse(drPro["ID_USUARIO_ALT_PROD"].ToString()); }

                        if (!drPro["ID_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.IdCategoria = int.Parse(drPro["ID_CATEGORIA_PROD"].ToString()); }

                        if (retProd.CategoriaProduto == null)
                        { retProd.CategoriaProduto = new Entidades.Categoria(); }

                        retProd.CategoriaProduto.Nome = drPro["NOME_CATEGORIA_PROD"].ToString();
                        retProd.CategoriaProduto.Descricao = drPro["DESC_CATEGORIA_PROD"].ToString();
                        retProd.CategoriaProduto.FlagAtivo = drPro["FLAG_ATIVO_CATEGORIA_PROD"].ToString();

                        if (!drPro["DATA_INC_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.DataInclusao = DateTime.Parse(drPro["DATA_INC_CATEGORIA_PROD"].ToString()); }

                        if (!drPro["DATA_INC_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.IdUsuarioInclusao = int.Parse(drPro["ID_USUARIO_INC_CATEGORIA_PROD"].ToString()); }

                        if (!drPro["DATA_ALT_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.DataAlteracao = DateTime.Parse(drPro["DATA_ALT_CATEGORIA_PROD"].ToString()); }

                        if (!drPro["ID_USUARIO_ALT_CATEGORIA_PROD"].ToString().Trim().Equals(""))
                        { retProd.CategoriaProduto.IdUsuarioAlteracao = int.Parse(drPro["ID_USUARIO_ALT_CATEGORIA_PROD"].ToString()); }

                        #endregion

                        #region Dados de Retorno do Preço Produto

                        if (!drPro["CD_ITEM_PRODUTO"].ToString().Trim().Equals(""))
                        { retProd.CodigoItemProduto = drPro["CD_ITEM_PRODUTO"].ToString(); }

                        if (!drPro["PRECO"].ToString().Trim().Equals(""))
                        { retProd.PrecoProduto = Decimal.Parse(drPro["PRECO"].ToString()); }

                        if (!drPro["DT_INI_VIGE_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.DataInicioVigencia = DateTime.Parse(drPro["DT_INI_VIGE_PROD_PRECO"].ToString()); }

                        retProd.FlagAtivoPrecoProduto = drPro["FLAG_ATIVO_PROD_PRECO"].ToString();

                        if (!drPro["DATA_INC_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.DataInclusaoPrecoProduto = DateTime.Parse(drPro["DATA_INC_PROD_PRECO"].ToString()); }

                        if (!drPro["ID_USUARIO_INC_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioInclusaoPrecoProduto = int.Parse(drPro["ID_USUARIO_INC_PROD_PRECO"].ToString()); }

                        if (!drPro["DATA_ALT_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.DataAlteracaoPrecoProduto = DateTime.Parse(drPro["DATA_ALT_PROD_PRECO"].ToString()); }

                        if (!drPro["ID_USUARIO_ALT_PROD_PRECO"].ToString().Trim().Equals(""))
                        { retProd.IdUsuarioAlteracaoPrecoProduto = int.Parse(drPro["ID_USUARIO_ALT_PROD_PRECO"].ToString()); }

                        if (!drPro["DESCONTO_OFERECIDO"].ToString().Trim().Equals(""))
                        { retProd.DescontoOferecidoPrecoProduto = Decimal.Parse(drPro["DESCONTO_OFERECIDO"].ToString()); }

                        #endregion

                        lRet.Add(retProd);
                    }

                    return lRet;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
