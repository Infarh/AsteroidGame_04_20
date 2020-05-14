using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AdoNetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AsteroidsDB-Test;Integrated Security=True";

            ////DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            ////var new_connectionstring = builder.ConnectionString;

            //var sql_server_connection_string_builder = new SqlConnectionStringBuilder(connection_string);
            //sql_server_connection_string_builder.IntegratedSecurity = false;
            //sql_server_connection_string_builder.UserID = "User";
            //sql_server_connection_string_builder.Password = "Password";
            //sql_server_connection_string_builder.InitialCatalog = "TestDB123";

            //var new_connection_string = sql_server_connection_string_builder.ConnectionString;

            const string connection_string_name = "DefaultConnection";


            var connection_string = ConfigurationManager.ConnectionStrings[connection_string_name].ConnectionString;

            ExecuteNonQuery(connection_string);

            Console.ReadLine();
        }

        private const string __SqlCreateTablePlayer = @"
CREATE TABLE [dbo].[Player] 
(
    [Id] INT IDENTITY(1, 1) NOT NULL,
    [Name] NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    [Email]    NVARCHAR(100) NULL,
    [Phone]    NVARCHAR(MAX) NULL,
    [Birthday] NVARCHAR(MAX) NULL,
    CONSTRAINT[PK_dbo.People] PRIMARY KEY CLUSTERED([Id] ASC)
);";

        private static void ExecuteNonQuery(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var create_table_commend = new SqlCommand(__SqlCreateTablePlayer, connection);
                create_table_commend.ExecuteNonQuery();
            }
        }
    }
}
