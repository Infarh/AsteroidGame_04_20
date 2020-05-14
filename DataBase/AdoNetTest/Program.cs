using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

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

            //ExecuteNonQuery(connection_string);
            //ExecuteScalar(connection_string);
            //ExecuteReader(connection_string);
            //ParametricQuery(connection_string);
            DataAdapterTest(connection_string);

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

        private const string _SqlInsertToPlayerTable = @"INSERT INTO [dbo].[Player] (Name,Birthday,Email,Phone) VALUES (N'{0}','{1}','{2}','{3}');";

        private static void ExecuteNonQuery(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                //var create_table_commend = new SqlCommand(__SqlCreateTablePlayer, connection);
                //create_table_commend.ExecuteNonQuery();

                var insert_data_command = new SqlCommand(
                    string.Format(_SqlInsertToPlayerTable,
                        "Иванов Иван Иванович",
                        "18.10.2001",
                        "ivanov@server.ru",
                        "+7(123)456-78-90"),
                    connection);
                insert_data_command.ExecuteNonQuery();
            }
        }

        private const string __SqlCountPlayers = @"SELECT COUNT(*) FROM [dbo].[Player]";

        private static void ExecuteScalar(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var count_command = new SqlCommand(__SqlCountPlayers, connection);
                if (!(count_command.ExecuteScalar() is int count))
                    throw new InvalidOperationException("Ошибка в результате выполнения команды подсчёта числа строк в таблице игроков - возвращённое значение не является значением Int32");
            }
        }

        private const string __SqlSelectFromPlayer = @"SELECT * FROM [dbo].[Player]";

        private static void ExecuteReader(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var select_command = new SqlCommand(__SqlSelectFromPlayer, connection);

                using (var reader = select_command.ExecuteReader())
                    if(reader.HasRows)
                        while (reader.Read())
                        {
                            var id = (int) reader.GetValue(0);
                            var name = reader.GetString(1);
                            var email = reader["Email"] as string;
                            var phone = reader.GetString(reader.GetOrdinal("Phone"));

                            Console.WriteLine("id:{0}\tname:{1}\temail:{2}\tphone:{3}", id, name, email, phone);
                        }

            }
        }

        private const string __SqlSelectWithFilter = @"SELECT COUNT(*) FROM [dbo].[Player] WHERE {0}";

        private static void ParametricQuery(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var select_command = new SqlCommand(
                    string.Format(__SqlSelectWithFilter, "Birthday=@Birthday"),
                    connection);

                var birthday = new SqlParameter("@Birthday", SqlDbType.NVarChar, -1);

                select_command.Parameters.Add(birthday);

                birthday.Value = "18.10.2001";

                var count = (int) select_command.ExecuteScalar();
            }
        }

        private static void DataAdapterTest(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                //connection.Open();

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM Player", connection);

                var table = new DataTable();

                adapter.Fill(table);
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var adapter = new SqlDataAdapter("SELECT * FROM Player; SELECT * FROM Games", connection);

                var data_set = new DataSet();
                adapter.Fill(data_set);

                var players = data_set.Tables[0];
                var gamse = data_set.Tables[1];
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                //connection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM Player", connection);

                var insert_command = new SqlCommand(@"INSERT INTO Player (Name,Birthday,Email,Phone) VALUES (@Name,@Birthday,@Email,@Phone); SET @ID=@@IDENTITY", connection)
                {
                    Parameters =
                    {
                        { "@Name", SqlDbType.NVarChar, -1, "Name" },
                        { "@Birthday", SqlDbType.NVarChar, -1, "Birthday" },
                        { "@Email", SqlDbType.NVarChar, 100, "Email" },
                        { "@Phone", SqlDbType.NVarChar, -1, "Phone" },
                        { "@ID", SqlDbType.Int, 0, "ID" },
                    }
                };
                insert_command.Parameters["@ID"].Direction = ParameterDirection.Output;

                adapter.InsertCommand = insert_command;

                adapter.UpdateCommand = new SqlCommand(@"UPDATE Player SET Name=@Name,Birthday=@Birthday WHERE ID=@ID", connection)
                {
                    Parameters =
                    {
                        { "@Name", SqlDbType.NVarChar, -1, "Name" },
                        { "@Birthday", SqlDbType.NVarChar, -1, "Birthday" },
                        { "@ID", SqlDbType.Int, 0, "ID" },
                    }
                };
                adapter.UpdateCommand.Parameters["@ID"].Direction = ParameterDirection.Output;

                adapter.DeleteCommand = new SqlCommand(@"DELETE FROM Player WHERE ID=@ID", connection)
                {
                    Parameters =
                    {
                        { "@ID", SqlDbType.Int, 0, "ID" }
                    }
                };
                adapter.DeleteCommand.Parameters["@ID"].Direction = ParameterDirection.Output;

                var data_set = new DataSet();
                adapter.Fill(data_set);

                var table = data_set.Tables[0];

                var row = table.NewRow();
                row["Name"] = "QWE ASD ZXC";
                row["Birthday"] = "21.04.2012";
                table.Rows.Add(row);

                adapter.Update(data_set);

                var adapter2 = new SqlDataAdapter("SELECT * FROM Player", connection);

                var builder = new SqlCommandBuilder(adapter2);
                adapter2.InsertCommand = builder.GetInsertCommand();
                adapter2.UpdateCommand = builder.GetUpdateCommand();
                adapter2.DeleteCommand = builder.GetDeleteCommand();

            }
        }
    }
}
