using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace DNA.Dados.Cadastral.WS
{
    public class RastreamentoMoradoresMesmoEndereco
    {
        public void PesquisaMoradoresMesmoEndereco(Entidades.Cadastral.FiltroPesquisaMoradoresMesmoEndereco filtro, ref DataSet oDS)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[7];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_CEP";
                    arParms[0].OracleDbType = OracleDbType.Varchar2;
                    arParms[0].Direction = ParameterDirection.Input;
                    if (filtro.Cep.Trim().Equals(""))
                    { arParms[0].Value = DBNull.Value; }
                    else
                    { arParms[0].Value = filtro.Cep; }

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
                    arParms[3].ParameterName = "P_BAIRRO";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = filtro.Bairro; 

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_LOGRADOURO";
                    arParms[4].OracleDbType = OracleDbType.Varchar2;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = filtro.Logradouro;

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "P_NUMERO";
                    arParms[5].OracleDbType = OracleDbType.Varchar2;
                    arParms[5].Direction = ParameterDirection.Input;
                    arParms[5].Value = filtro.Numero; 

                    arParms[6] = new OracleParameter();
                    arParms[6].ParameterName = "R_CURSOR";
                    arParms[6].OracleDbType = OracleDbType.RefCursor;
                    arParms[6].Direction = ParameterDirection.Output;


                    oConn.Execute("DNAONLINE.P_L_WS_RAST_MORA_MESMO_END", arParms, ref oDS);
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
