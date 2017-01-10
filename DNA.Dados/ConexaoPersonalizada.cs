using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DNA.Dados
{
    public class ConexaoPersonalizada
    {
        private OracleTransaction oTransaction;
        private OracleConnection oConn;

        public ConexaoPersonalizada()
        {
            try
            {
                oConn = new OracleConnection(strConexao());

                if (oConn.State != ConnectionState.Open)
                {
                    oConn.Open();
                    Transaction = oConn.BeginTransaction();
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro ao tentar abrir a conexão. Mensagem: " + ex.Message); }
        }

        public OracleTransaction Transaction
        {
            get { return oTransaction; }
            set { oTransaction = value; }
        }

        private string strConexao()
        {
            try
            {
                string sConn = string.Empty;
                sConn = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                return sConn;
            }
            catch (Exception ex)
            { throw new Exception("Erro ao tentar obter a string de conexão. ERRO: " + ex.Message); }
        }

        public void OpenConnection()
        {
            try
            {
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.ConnectionString = strConexao();
                    oConn.Open();
                    Transaction = oConn.BeginTransaction();
                }
            }
            catch (Exception ex)
            { throw new Exception("Erro ao tentar abrir a conexão. ERRO: " + ex.Message); }
        }

        public void Commit()
        {
            try
            {
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.ConnectionString = strConexao();
                    oConn.Open();
                    Transaction = oConn.BeginTransaction();
                }

                Transaction.Commit();

                CloseConnection();
            }
            catch (Exception ex)
            { throw new Exception("Erro ao tentar efetuar COMMIT. ERRO: " + ex.Message); }
        }

        public void Rollback()
        {
            try
            {
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.ConnectionString = strConexao();
                    oConn.Open();
                    Transaction = oConn.BeginTransaction();
                }

                Transaction.Rollback();

                CloseConnection();
            }
            catch (Exception ex)
            { throw new Exception("Erro ao tentar efetuar ROLLBACK. ERRO: " + ex.Message); }
        }

        public void CloseConnection()
        {
            try
            {
                oTransaction.Dispose();
                oConn.Close();
                oConn.Dispose();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Execute(string ProcedureName, OracleParameter[] arrParameters, ref DataSet oDS)
        {
            try
            {
                OracleCommand oCmd = new OracleCommand();

                try
                {
                    OpenConnection();
                    oCmd.Connection = oConn;
#if DEBUG
                    oCmd.CommandTimeout = 0;
#endif
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.CommandText = ProcedureName;
                    oCmd.Transaction = Transaction;

                    foreach (OracleParameter p in arrParameters)
                    { oCmd.Parameters.Add(p); }

                    OracleDataAdapter oDA = new OracleDataAdapter(oCmd);

                    //oDS.BeginLoadData();
                    oDA.Fill(oDS);
                    //oDS.EndLoadData();
                    oDA.Dispose();
                    oCmd.Parameters.Clear();
                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    oDS.Dispose();
                    oCmd.Dispose();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Execute(string ProcedureName, OracleParameter[] arrParameters, ref DataTable oDT)
        {
            try
            {
                OracleCommand oCmd = new OracleCommand();

                try
                {
                    OpenConnection();
                    oCmd.Connection = oConn;
#if DEBUG
                    oCmd.CommandTimeout = 0;
#endif
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.CommandText = ProcedureName;
                    oCmd.Transaction = Transaction;
                    //oCmd.BindByName = true;

                    foreach (OracleParameter p in arrParameters)
                    { oCmd.Parameters.Add(p); }

                    OracleDataAdapter oDA = new OracleDataAdapter(oCmd);

                    oDT.BeginLoadData();
                    oDA.Fill(oDT);
                    oDT.EndLoadData();

                    oDA.Dispose();
                    oDA = null;
                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    oDT.Dispose();
                    oCmd.Dispose();
                    //oCmd.Connection.Close();
                    //oCmd.Connection.Dispose();
                    //oCmd.Connection = null;
                    //oCmd.Parameters.Clear();
                    //oCmd = null;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Execute(string ProcedureName, OracleParameter[] arrParameters)
        {
            try
            {
                OracleCommand oCmd = new OracleCommand();
                try
                {
                    OpenConnection();
                    oCmd.Connection = oConn;
#if DEBUG
                    oCmd.CommandTimeout = 0;
#endif
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.CommandText = ProcedureName;
                    oCmd.Transaction = Transaction;

                    foreach (OracleParameter p in arrParameters)
                    { oCmd.Parameters.Add(p); }

                    oCmd.ExecuteNonQuery();

                    oCmd.Parameters.Clear();
                }
                catch (Exception ex)
                { throw ex; }
                finally
                { oCmd.Dispose(); }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Execute(string QuerySQL, ref DataTable oDT)
        {
            try
            {
                OracleCommand oCmd = new OracleCommand();

                try
                {
                    OpenConnection();
                    oCmd.Connection = oConn;
#if DEBUG
                    oCmd.CommandTimeout = 0;
#endif
                    oCmd.CommandType = CommandType.Text;
                    oCmd.CommandText = QuerySQL;
                    oCmd.Transaction = Transaction;
                    //oCmd.BindByName = true;

                    OracleDataAdapter oDA = new OracleDataAdapter(oCmd);

                    oDT.BeginLoadData();
                    oDA.Fill(oDT);
                    oDT.EndLoadData();

                    oDA.Dispose();
                    oDA = null;
                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    oDT.Dispose();
                    oCmd.Dispose();
                    //oCmd.Connection.Close();
                    //oCmd.Connection.Dispose();
                    //oCmd.Connection = null;
                    //oCmd.Parameters.Clear();
                    //oCmd = null;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Execute(string QuerySQL, ref DataSet oDS)
        {
            try
            {
                OracleCommand oCmd = new OracleCommand();

                try
                {
                    OpenConnection();
                    oCmd.Connection = oConn;
#if DEBUG
                    oCmd.CommandTimeout = 0;
#endif
                    oCmd.CommandType = CommandType.Text;
                    oCmd.CommandText = QuerySQL;
                    oCmd.Transaction = Transaction;

                    OracleDataAdapter oDA = new OracleDataAdapter(oCmd);

                    //oDS.BeginLoadData();
                    oDA.Fill(oDS);
                    //oDS.EndLoadData();
                    oDA.Dispose();
                    oCmd.Parameters.Clear();
                }
                catch (Exception ex)
                { throw ex; }
                finally
                {
                    oDS.Dispose();
                    oCmd.Dispose();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
