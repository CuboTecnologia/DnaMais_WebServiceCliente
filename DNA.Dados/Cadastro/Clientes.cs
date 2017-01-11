using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados.Cadastro
{
    public class Clientes
    {
        public void Listar(DNA.Entidades.Cliente cli, ref DataTable oDT)
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
                    arParms[1].ParameterName = "P_ID_CLIENTE";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = cli.IdCliente; 

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_NOME_RAZAO_SOCIAL";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = cli.NomeRazaoSocial;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_NOME_FANTASIA";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = cli.NomeFantasia;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_NUM_CPF_CNPJ";
                    arParms[4].OracleDbType = OracleDbType.Varchar2;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = cli.NumeroDocCPFCNPJ;

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "P_FLAG_ATIVO";
                    arParms[5].OracleDbType = OracleDbType.Char;
                    arParms[5].Direction = ParameterDirection.Input;
                    arParms[5].Value = cli.FlagAtivo;

                    oConn.Execute("DNAINFO.P_L_CLIENTES", arParms, ref oDT);
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
