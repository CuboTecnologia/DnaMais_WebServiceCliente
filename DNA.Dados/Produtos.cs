using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados
{
    public class Produtos
    {
        public void ListarByIdUsuario(Entidades.Usuario user, ref DataTable oDT)
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
                    arParms[1].ParameterName = "P_ID_CLIENTE_EMPRESA";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = user.IdCliente;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_USUARIO_CLIENTE";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = arParms[2].Value = user.IdUsuario; 

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_CD_PRODUTO";
                    arParms[3].OracleDbType = OracleDbType.Char;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = user.Produtos.FirstOrDefault().CodigoProduto; 
                    
                    //TODO: PROC Listar Produtos do usuario - Verificar se os parametros abaixo serão construidos na procedure para o novo modelo
                    //arParms[4] = new OracleParameter();
                    //arParms[4].ParameterName = "P_FLAG_PROD_WS";
                    //arParms[4].OracleDbType = OracleDbType.Char;
                    //arParms[4].Direction = ParameterDirection.Input;
                    //arParms[4].Value = "";
                    //if (user.Produtos != null && user.Produtos.Count == 1)
                    //{ arParms[4].Value = user.Produtos.FirstOrDefault().FlagProdutoWebService; }

                    //arParms[5] = new OracleParameter();
                    //arParms[5].ParameterName = "P_FLAG_ATIVO_REL_USU_CLI_PROD";
                    //arParms[5].OracleDbType = OracleDbType.Char;
                    //arParms[5].Direction = ParameterDirection.Input;
                    //arParms[5].Value = "";
                    //if (user.Produtos != null && user.Produtos.Count == 1)
                    //{ arParms[5].Value = user.Produtos.FirstOrDefault().FlagAtivoProduto; }

                    oConn.Execute("DNASITE.P_L_PRODUTOS_BY_ID_USU_CLI", arParms, ref oDT);
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
