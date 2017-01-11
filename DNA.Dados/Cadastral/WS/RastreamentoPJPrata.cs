using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace DNA.Dados.Cadastral.WS
{
    public class RastreamentoPJPrata
    {
        public void PesquisaPJ(string numeroCNPJ, ref DataSet oDS)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[6];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_CNPJ";
                    arParms[0].OracleDbType = OracleDbType.Varchar2;
                    arParms[0].Direction = ParameterDirection.Input;
                    arParms[0].Value = numeroCNPJ;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "R_DADOS_CADASTRAIS";
                    arParms[1].OracleDbType = OracleDbType.RefCursor;
                    arParms[1].Direction = ParameterDirection.Output;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "R_TELEFONES";
                    arParms[2].OracleDbType = OracleDbType.RefCursor;
                    arParms[2].Direction = ParameterDirection.Output;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "R_ENDERECO";
                    arParms[3].OracleDbType = OracleDbType.RefCursor;
                    arParms[3].Direction = ParameterDirection.Output;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "R_CNAE";
                    arParms[4].OracleDbType = OracleDbType.RefCursor;
                    arParms[4].Direction = ParameterDirection.Output;

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "R_QSA";
                    arParms[5].OracleDbType = OracleDbType.RefCursor;
                    arParms[5].Direction = ParameterDirection.Output;   

                    oConn.Execute("DNAINFO.P_L_WS_RASTREAMENTO_PJ_PRATA", arParms, ref oDS);
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
