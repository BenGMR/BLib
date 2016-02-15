using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLibUtils.SQL
{
    /// <summary>
    /// A simple wrapper class for SQL connections
    /// </summary>

    public class SQLEngine
    {
        SqlConnection _connection;

        SqlCommand _command;

        DataTable _table;

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public SqlCommand Command
        {
            get
            {
                return _command;
            }
        }
        
        /// <summary>
        /// A useless ctor that does not connect to anything
        /// </summary>
        public SQLEngine()
        {
            _connection = new SqlConnection();
            _command = new SqlCommand("", _connection);
            _table = new DataTable();
        }
        
        /// <summary>
        /// A lame ctor that attempts to connect to the specified database
        /// </summary>
        /// <param name="server">server name to connect</param>
        /// <param name="dataBase">database in the server</param>
        /// <param name="userID">username for sql connection</param>
        /// <param name="pWord">password for sql connection</param>
        public SQLEngine(string server, string dataBase, string userID, string pWord)
        {
            _connection = new SqlConnection(string.Format("Server={0}; Database={1}; User Id ={2}; Password = {3}", server, dataBase, userID, pWord));
            _command = new SqlCommand("", _connection);
            _table = new DataTable();
        }

        public DataTable ExecuteProcedure(string procedureName, params SqlParameter[] parameters)
        {
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = string.Format(procedureName);

            _command.Parameters.Clear();

            for (int i = 0; i < parameters.Length; i++)
            {
                _command.Parameters.Add(parameters[i]);
            }


                SqlDataAdapter sda = new SqlDataAdapter(_command);
                DataTable set = new DataTable();

                sda.Fill(set);

            return set;
        }

        public DataTable ExecuteProcedure(string procedureName)
        {
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = string.Format(procedureName);

            SqlDataAdapter sda = new SqlDataAdapter(_command);
            DataTable set = new DataTable();

            sda.Fill(set);

            return set;
        }

        public int ExecuteNonQuery(string procName, params SqlParameter[] parameters)
        {
            _table = new DataTable();
            _connection.Open();

            _command.Connection = _connection;
            _command.CommandText = procName;
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.Parameters.Clear();
            for (int i = 0; i < parameters.Length; i++)
            {
                _command.Parameters.Add(parameters[i]);
            }
            int rows = _command.ExecuteNonQuery();
            _connection.Close();
            return rows;
        }

       
    }
}
