using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace DNA.Dados.Cadastral.WS
{
    public class RastreamentoSearchTelefonePJ
    {
        public void PesquisaSearchTelefonePJ(Entidades.Cadastral.FiltroPesquisaSearchTelefonePJ filtro, ref DataSet oDS)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[3];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_DDD";
                    arParms[0].OracleDbType = OracleDbType.Varchar2;
                    arParms[0].Direction = ParameterDirection.Input;
                    arParms[0].Value = filtro.DDD;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_TEL";
                    arParms[1].OracleDbType = OracleDbType.Varchar2;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = filtro.NumeroTel;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "R_CURSOR";
                    arParms[2].OracleDbType = OracleDbType.RefCursor;
                    arParms[2].Direction = ParameterDirection.Output;


                    oConn.Execute("DNAONLINE.P_L_WS_RASTREA_SEARCH_TEL_PJ", arParms, ref oDS);
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
