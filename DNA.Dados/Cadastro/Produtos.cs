using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados.Cadastro
{
    public class Produtos
    {
        public void Listar(Entidades.Produto prod, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[3];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_PRODUTO";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = prod.IdProduto;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_PRODUTO_PRECO";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = prod.IdPrecoProduto;

                    oConn.Execute("DNAINFO.P_L_PRODUTOS", arParms, ref oDT);
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

        public void ListarByIdCliente(Entidades.Produto prod, Entidades.Cliente cli, ref DataTable oDT)
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
                    arParms[1].Value = prod.IdProduto;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_PRODUTO_PRECO";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = prod.IdPrecoProduto;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ID_CLIENTE";
                    arParms[3].OracleDbType = OracleDbType.Int64;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = cli.IdCliente;

                    oConn.Execute("DNAINFO.P_L_PRODUTOS_BY_CLIENTE", arParms, ref oDT);
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

        public void ListarByIdUsuario(Entidades.Cliente cli, ref DataTable oDT)
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
                    if (cli.Produtos == null || cli.Produtos.Count == 0)
                    { arParms[1].Value = 0; }
                    else
                    { arParms[1].Value = cli.Produtos.FirstOrDefault().IdProduto; }

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_PRODUTO_PRECO";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    if (cli.Produtos == null || cli.Produtos.Count == 0)
                    { arParms[2].Value = 0; }
                    else
                    { arParms[2].Value = cli.Produtos.FirstOrDefault().IdPrecoProduto; }

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ID_USUARIO";
                    arParms[3].OracleDbType = OracleDbType.Int64;
                    arParms[3].Direction = ParameterDirection.Input;
                    if (cli.Usuarios == null || cli.Usuarios.Count == 0)
                    { arParms[3].Value = 0; }
                    else
                    { arParms[3].Value = cli.Usuarios.FirstOrDefault().IdUsuario; }

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

        public void ListarByIdUsuario(Entidades.Usuario usu, ref DataTable oDT)
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
    }
}
