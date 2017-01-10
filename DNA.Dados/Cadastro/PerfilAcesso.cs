using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados.Cadastro
{
    public class PerfilAcesso
    {
        public void ListarPerfis(DNA.Entidades.Usuario usu, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[4];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_PERFIL";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    if (usu.IdUsuario == 0) { arParms[1].Value = DBNull.Value; } else { arParms[1].Value = usu.IdUsuario; }

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_DESCRICAO";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = usu.LoginUsuario;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_FLAG_ATIVO";
                    arParms[3].OracleDbType = OracleDbType.Char;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = usu.SenhaUsuario;

                    oConn.Execute("DNAONLINE.P_L_PERFIS", arParms, ref oDT);
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

        public void ListarPerfilByIdUsuario(DNA.Entidades.PerfilAcesso perf, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[4];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = perf.IdPerfilAcessoUsuario; 

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_ID_PERFIL";
                    arParms[2].OracleDbType = OracleDbType.Int64;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = perf.IdPerfilAcesso;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_ID_USUARIO";
                    arParms[3].OracleDbType = OracleDbType.Int64;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = perf.IdUsuario;

                    oConn.Execute("DNAONLINE.P_L_USU_PERF_ACESS", arParms, ref oDT);
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
