using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace UltimateCalendar.Models
{
    public class DataBaseConnection
    {
        public MySqlConnection GetMySqlConnection()
        {
          return new MySqlConnection(ConfigurationManager.ConnectionStrings["GCPMySqlDB"].ConnectionString);
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);
        }
        
    }
}
