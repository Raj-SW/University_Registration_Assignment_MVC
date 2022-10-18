using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCPract.DataAccessLayer.Common
{
    public class DAL
    {
        public const string connectionstring = @"server=localhost;database=UniversityDB;uid=wpboc;pwd=sql@tfs2008";
        public SqlConnection connection;

        public DAL()
        {
            connection = new SqlConnection(connectionstring);
            OpenConnection();
        }
        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}