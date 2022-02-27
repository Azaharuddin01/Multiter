using System;
using Microsoft.Data.SqlClient;
using CommanLayer.Models;

namespace DataAccessLayer
{
    public class DbConnection
    {
        public SqlConnection Cnn;
        public DbConnection()
        {
            Cnn = new SqlConnection(Connection.ConnectionStr);
        }
    }
}
