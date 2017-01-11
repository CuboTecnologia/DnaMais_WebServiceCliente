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
                    OracleParameter[] arParms = new OracleParameter[9];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_PRODUTO_PRECO";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = cli.IdProdutoPreco;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_FLAG_SUCESSO";
                    arParms[2].OracleDbType = OracleDbType.Char;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = cli.FlagSucesso;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ENDERECO_IP_ORIGEM_PESQUISA";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = cli.IpOrigemConsulta;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_OBSERVACAO";
                    arParms[4].OracleDbType = OracleDbType.Clob;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = cli.Observacao;

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "P_DATA_INCLUSAO";
                    arParms[5].OracleDbType = OracleDbType.Date;
                    arParms[5].Direction = ParameterDirection.Input;
                    arParms[5].Value = cli.DataConsulta;

                    arParms[6] = new OracleParameter();
                    arParms[6].ParameterName = "P_ID_USUARIO_INCLUSAO";
                    arParms[6].OracleDbType = OracleDbType.Int64;
                    arParms[6].Direction = ParameterDirection.Input;
                    arParms[6].Value = cli.IdUsuarioConsulta;

                    arParms[7] = new OracleParameter();
                    arParms[7].ParameterName = "P_TIPO_FILTRO_ENTRADA_PESQUISA";
                    arParms[7].OracleDbType = OracleDbType.Clob;
                    arParms[7].Direction = ParameterDirection.Input;
                    arParms[7].Value = cli.TipoFiltroUtilizadoPesquisa;

                    arParms[8] = new OracleParameter();
                    arParms[8].ParameterName = "P_FILTRO_ENTRADA_PESQUISA";
                    arParms[8].OracleDbType = OracleDbType.Clob;
                    arParms[8].Direction = ParameterDirection.Input;
                    arParms[8].Value = cli.FiltroUtilizadoPesquisa;

                    oConn.Execute("DNAINFO.P_I_HISTORICO_CONSULTA", arParms, ref oDT);
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

        public void SalvarHistoricoFornecedor(DNA.Entidades.HistoricoPesquisa cli, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[8];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_ID_ORIGEM_PRODUTO_CONSULTADO";
                    arParms[0].OracleDbType = OracleDbType.Int64;
                    arParms[0].Direction = ParameterDirection.Input;
                    arParms[0].Value = cli.IdOrigemProdutoConsultado;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_HISTORICO_CONSULTA";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = cli.IdHistoricoConsulta;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_FLAG_SUCESSO";
                    arParms[2].OracleDbType = OracleDbType.Char;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = cli.FlagSucesso;

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

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "P_ID_USUARIO_INCLUSAO";
                    arParms[5].OracleDbType = OracleDbType.Int64;
                    arParms[5].Direction = ParameterDirection.Input;
                    arParms[5].Value = cli.IdUsuarioConsulta;

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
