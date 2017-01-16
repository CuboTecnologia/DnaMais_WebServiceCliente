using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados
{
    public class HistoricoPesquisa
    {
        public void Salvar(DNA.Entidades.HistoricoPesquisa cli, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[6];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_CLIENTE_EMPRESA";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = cli.IdClienteEmpresa;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_CONTRATO_EMPRESA";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = cli.IdContratoEmpresa;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ID_USUARIO_CLIENTE";
                    arParms[3].OracleDbType = OracleDbType.Int64;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = cli.IdUsuarioConsulta;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_CD_ITEM_PRODUTO";
                    arParms[4].OracleDbType = OracleDbType.Char;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = cli.CodigoItemProduto;

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "P_IS_DADOS_ENCONTRADOS";
                    arParms[5].OracleDbType = OracleDbType.Char;
                    arParms[5].Direction = ParameterDirection.Input;
                    arParms[5].Value = cli.FlagSucesso;

                    oConn.Execute("DNASITE.P_I_HISTORICO_CONSULTA", arParms, ref oDT);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oConn.CloseConnection();
                    oConn = null;
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void SalvarHistoricoFornecedor(DNA.Entidades.HistoricoPesquisa cli, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[8];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_ID_CLIENTE_EMPRESA";
                    arParms[0].OracleDbType = OracleDbType.Int64;
                    arParms[0].Direction = ParameterDirection.Input;
                    arParms[0].Value = cli.IdClienteEmpresa;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_CONTRATO_EMPRESA";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = cli.IdContratoEmpresa;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_USUARIO_CLIENTE";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = cli.IdUsuarioConsulta;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_CD_ITEM_PRODUTO";
                    arParms[2].OracleDbType = OracleDbType.Char;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = cli.CodigoItemProduto;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_RETORNO_SOLCITACAO";
                    arParms[3].OracleDbType = OracleDbType.Clob;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = cli.HTMLRetornadoFornecedor;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_DATA_INCLUSAO";
                    arParms[4].OracleDbType = OracleDbType.Date;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = cli.DataConsulta;

                    arParms[6] = new OracleParameter();
                    arParms[6].ParameterName = "P_DATA_ALTERACAO";
                    arParms[6].OracleDbType = OracleDbType.Date;
                    arParms[6].Direction = ParameterDirection.Input;
                    if (cli.DataAlteracao == null) { arParms[6].Value = DBNull.Value; } else { arParms[6].Value = cli.DataAlteracao; }

                    arParms[7] = new OracleParameter();
                    arParms[7].ParameterName = "P_ID_USUARIO_ALTERACAO";
                    arParms[7].OracleDbType = OracleDbType.Int64;
                    arParms[7].Direction = ParameterDirection.Input;
                    if (cli.IdUsuarioAlteracao == 0) { arParms[7].Value = DBNull.Value; } else { arParms[7].Value = cli.IdUsuarioAlteracao; }

                    oConn.Execute("DNAINFO.P_I_HISTORICO_FORNECEDOR", arParms, ref oDT);
                    oConn.Commit();
                }
                catch (Exception ex)
                {
                    oConn.Rollback();
                    throw ex; 
                }
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
