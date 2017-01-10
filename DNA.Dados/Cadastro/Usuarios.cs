using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DNA.Dados.Cadastro
{
    public class Usuarios
    {
        public void Listar(DNA.Entidades.Usuario usu, ref DataTable oDT)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[5];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "V_CURSOR";
                    arParms[0].OracleDbType = OracleDbType.RefCursor;
                    arParms[0].Direction = ParameterDirection.Output;

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_USUARIO";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    if (usu.IdUsuario == 0) { arParms[1].Value = DBNull.Value; } else { arParms[1].Value = usu.IdUsuario; }

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_LOGIN";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    arParms[2].Value = usu.LoginUsuario;

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_SENHA";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    arParms[3].Value = usu.SenhaUsuario;

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_FLAG_ATIVO";
                    arParms[4].OracleDbType = OracleDbType.Char;
                    arParms[4].Direction = ParameterDirection.Input;
                    arParms[4].Value = usu.FlagAtivo;

                    oConn.Execute("DNAONLINE.P_L_USUARIOS", arParms, ref oDT);
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

        public void AlterarSenha(int idUsuarioAlteracao, DNA.Entidades.Usuario usu)
        {
            try
            {
                ConexaoPersonalizada oConn = new ConexaoPersonalizada();

                try
                {
                    OracleParameter[] arParms = new OracleParameter[9];

                    arParms[0] = new OracleParameter();
                    arParms[0].ParameterName = "P_ID_USUARIO_ALTERADO";
                    arParms[0].OracleDbType = OracleDbType.Int64;
                    arParms[0].Direction = ParameterDirection.Input;
                    if (usu.IdUsuario == 0) { arParms[0].Value = DBNull.Value; } else { arParms[0].Value = usu.IdUsuario; }

                    arParms[1] = new OracleParameter();
                    arParms[1].ParameterName = "P_ID_USUARIO_ALTERACAO";
                    arParms[1].OracleDbType = OracleDbType.Int64;
                    arParms[1].Direction = ParameterDirection.Input;
                    arParms[1].Value = idUsuarioAlteracao;

                    arParms[2] = new OracleParameter();
                    arParms[2].ParameterName = "P_NOVO_NOME";
                    arParms[2].OracleDbType = OracleDbType.Varchar2;
                    arParms[2].Direction = ParameterDirection.Input;
                    if (usu.NomeUsuario.Length == 0) { arParms[2].Value = DBNull.Value; } else { arParms[2].Value = usu.NomeUsuario; }

                    arParms[3] = new OracleParameter();
                    arParms[3].ParameterName = "P_NOVO_LOGIN";
                    arParms[3].OracleDbType = OracleDbType.Varchar2;
                    arParms[3].Direction = ParameterDirection.Input;
                    if (usu.LoginUsuario.Length == 0) { arParms[3].Value = DBNull.Value; } else { arParms[3].Value = usu.LoginUsuario; }

                    arParms[4] = new OracleParameter();
                    arParms[4].ParameterName = "P_NOVA_SENHA";
                    arParms[4].OracleDbType = OracleDbType.Varchar2;
                    arParms[4].Direction = ParameterDirection.Input;
                    if (usu.SenhaUsuario.Length == 0) { arParms[4].Value = DBNull.Value; } else { arParms[4].Value = usu.SenhaUsuario; }

                    arParms[5] = new OracleParameter();
                    arParms[5].ParameterName = "P_NOVO_EMAIL1";
                    arParms[5].OracleDbType = OracleDbType.Varchar2;
                    arParms[5].Direction = ParameterDirection.Input;
                    if (usu.Email1.Length == 0) { arParms[5].Value = DBNull.Value; } else { arParms[5].Value = usu.Email1; }

                    arParms[6] = new OracleParameter();
                    arParms[6].ParameterName = "P_NOVO_EMAIL2";
                    arParms[6].OracleDbType = OracleDbType.Varchar2;
                    arParms[6].Direction = ParameterDirection.Input;
                    if (usu.Email2.Length == 0) { arParms[6].Value = DBNull.Value; } else { arParms[6].Value = usu.Email2; }

                    arParms[7] = new OracleParameter();
                    arParms[7].ParameterName = "P_NOVO_OBSERVACAO";
                    arParms[7].OracleDbType = OracleDbType.Varchar2;
                    arParms[7].Direction = ParameterDirection.Input;
                    if (usu.Observacao.Length == 0) { arParms[7].Value = DBNull.Value; } else { arParms[7].Value = usu.Observacao; }

                    arParms[8] = new OracleParameter();
                    arParms[8].ParameterName = "P_FLAG_ATIVO";
                    arParms[8].OracleDbType = OracleDbType.Char;
                    arParms[8].Direction = ParameterDirection.Input;
                    if (usu.FlagAtivo.Length == 0) { arParms[8].Value = DBNull.Value; } else { arParms[8].Value = usu.FlagAtivo; }

                    oConn.Execute("DNAONLINE.P_U_USUARIO", arParms);

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
