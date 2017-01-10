using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados
{
    public class Fornecedor
    {
        public void Listar(Entidades.FornecedorConsulta fornec, ref DataTable oDT)
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
                    arParms[1].ParameterName = "P_ID_FORNECEDOR";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = fornec.IdFornecedor;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_NOME_RAZAO_SOCIAL";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = fornec.RazaoSocial;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_NOME_FANTASIA";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = fornec.NomeFantasia;
                    
                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_FLAG_ATIVO";
                    arParms[4].OracleDbType = OracleDbType.Char;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = fornec.FlagAtivo; 

                    oConn.Execute("DNAONLINE.P_L_FORNECEDORES", arParms, ref oDT);
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

        public void ListarOrigemProdutoFornecedor(Entidades.FornecedorConsulta fornec, ref DataTable oDT)
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
                    arParms[1].ParameterName = "P_ID";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    if (fornec.Produtos != null && fornec.Produtos.Count > 0)
                    { arParms[1].Value = fornec.Produtos.FirstOrDefault().IdOrigemProdutoConsultado; }


                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_NOME_PRODUTO_FORNEC";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = "";
                    if (fornec.Produtos != null && fornec.Produtos.Count > 0)
                    { arParms[2].Value = fornec.Produtos.FirstOrDefault().NomeProduto; }

                    oConn.Execute("DNAONLINE.P_L_ORIGEM_PRODUTO_CONSULTADO", arParms, ref oDT);
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
