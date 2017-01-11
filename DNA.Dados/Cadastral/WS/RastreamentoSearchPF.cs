using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace DNA.Dados.Cadastral.WS
{
    public class RastreamentoSearchPF
    {
        public void PesquisaSearchPF(Entidades.Cadastral.FiltroPesquisaSearchPF filtro, ref DataSet oDS)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[6];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_NOME";
                    arParms[0].OracleDbType = OracleDbType.Varchar2;
                    arParms[0].Direction = ParameterDirection.Input;
                    arParms[0].Value = filtro.Nome;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_UF";
                    arParms[1].OracleDbType = OracleDbType.Varchar2;
                    arParms[1].Direction = ParameterDirection.Input;
                    if (filtro.UF.Trim().Equals(""))
                    { arParms[1].Value = DBNull.Value; }
                    else
                    { arParms[1].Value = filtro.UF; }

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_CIDADE";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    if (filtro.Cidade.Trim().Equals(""))
                    { arParms[2].Value = DBNull.Value; }
                    else
                    { arParms[2].Value = filtro.Cidade; }

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_DATA_NASCIMENTO";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    if (filtro.DataNascimento.Trim().Equals(""))
                    { arParms[3].Value = DBNull.Value; }
                    else
                    { arParms[3].Value = filtro.DataNascimento; }

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_NOME_MAE";
                    arParms[4].OracleDbType = OracleDbType.Varchar2;
                    arParms[4].Direction = ParameterDirection.Input;
                    if (filtro.NomeMae.Trim().Equals(""))
                    { arParms[4].Value = DBNull.Value; }
                    else
                    { arParms[4].Value = filtro.NomeMae; }

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "R_CURSOR";
                    arParms[5].OracleDbType = OracleDbType.RefCursor;
                    arParms[5].Direction = ParameterDirection.Output;


                    oConn.Execute("DNAINFO.P_L_WS_RASTREAMENTO_SEARCH_PF", arParms, ref oDS);
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
