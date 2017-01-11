using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados.Relatorios
{
    public class Relatorio
    {
        public void ListarSolicitacoesByUsuario(Entidades.Usuario usu, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[4];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_PRODUTO";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    if (usu.Produtos == null || usu.Produtos.Count == 0)
                    { arParms[1].Value = 0; }
                    else
                    { arParms[1].Value = usu.Produtos.FirstOrDefault().IdProduto; }

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_PRODUTO_PRECO";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    if (usu.Produtos == null || usu.Produtos.Count == 0)
                    { arParms[2].Value = 0; }
                    else
                    { arParms[2].Value = usu.Produtos.FirstOrDefault().IdPrecoProduto; }

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ID_USUARIO";
                    arParms[3].OracleDbType = OracleDbType.Int64;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = usu.IdUsuario;

                    oConn.Execute("DNAINFO.P_L_PRODUTOS_BY_USUARIO", arParms, ref oDT);
                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    oConn.CloseConnection();
                    oConn = null;
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ListarRelatorioAnaliticoUsuario(Entidades.Relatorio.FiltroPesquisa filtro, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[5];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_USUARIO_INCLUSAO";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = filtro.IdUsuarioLogado;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_PRODUTO_PRECO";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    if (filtro.IdProdutoPreco == null || filtro.IdProdutoPreco == 0)
                    { arParms[2].Value = DBNull.Value; }
                    else
                    { arParms[2].Value = filtro.IdProdutoPreco; }

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_DATA_INICAL";
                    arParms[3].OracleDbType = OracleDbType.Date;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = filtro.DataInicialPesquisa;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_DATA_FINAL";
                    arParms[4].OracleDbType = OracleDbType.Date;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = filtro.DataFinalPesquisa;

                    oConn.Execute("DNAINFO.P_REL_HISTORICO_BY_USUARIO", arParms, ref oDT);
                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    oConn.CloseConnection();
                    oConn = null;
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
