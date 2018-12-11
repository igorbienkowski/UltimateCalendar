using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCalendar.Models
{
    public abstract class DBQuery<AnyType>
    {
        protected MySqlConnection connection = null;
        protected MySqlCommand command = null;

        private void Open()
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["GCPMySqlDB"].ConnectionString);
            connection.Open();
            command = new MySqlCommand();
            command.Connection = connection;
        }

        private void Execute(AnyType obj)
        {
            Open();

            ExecuteCommand(obj);

            Close();
        }

        private void Close()
        {
            connection.Dispose();
        }

        public abstract void ExecuteCommand(AnyType obj);
    }
}
