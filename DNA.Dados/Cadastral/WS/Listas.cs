using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace DNA.Dados.Cadastral.WS
{
    public class Listas
    {
        public void Cidades(int idUF, string UF, int idCidade, string NomeCidade, ref DataSet oDS)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[5];
                    
                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "R_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_UF";
                    arParms[1].OracleDbType = OracleDbType.Varchar2;
                    arParms[1].Direction = ParameterDirection.Input;
                    if (UF.Trim().Equals(""))
                    { arParms[1].Value = DBNull.Value; }
                    else
                    { arParms[1].Value = UF; }

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_UF";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = idUF; 

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ID_CIDADE";
                    arParms[3].OracleDbType = OracleDbType.Int64;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = idCidade;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_NOME_CIDADE";
                    arParms[4].OracleDbType = OracleDbType.Varchar2;
                    arParms[4].Direction = ParameterDirection.Input;
                    if (NomeCidade.Trim().Equals(""))
                    { arParms[4].Value = DBNull.Value; }
                    else
                    { arParms[4].Value = NomeCidade; }

                    oConn.Execute("DNAONLINE.P_L_CIDADES", arParms, ref oDS);
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
