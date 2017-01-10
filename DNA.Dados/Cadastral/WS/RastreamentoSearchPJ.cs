using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace DNA.Dados.Cadastral.WS
{
    public class RastreamentoSearchPJ
    {
        public void PesquisaSearchPJ(Entidades.Cadastral.FiltroPesquisaSearchPJ filtro, ref DataSet oDS)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[4];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_NOME";
                    arParms[0].OracleDbType = OracleDbType.Varchar2;
                    arParms[0].Direction = ParameterDirection.Input;
                    arParms[0].Value = filtro.Nome;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_UF";
                    arParms[1].OracleDbType = OracleDbType.Varchar2;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = filtro.UF;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_CIDADE";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = filtro.Cidade;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "R_CURSOR";
                    arParms[3].OracleDbType = OracleDbType.RefCursor;
                    arParms[3].Direction = ParameterDirection.Output;


                    oConn.Execute("DNAONLINE.P_L_WS_RASTREAMENTO_SEARCH_PJ", arParms, ref oDS);
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
