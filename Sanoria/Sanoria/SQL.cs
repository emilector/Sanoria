using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace Sanoria
{
    class SQL
    {
        public SQL(ref Data data)
        {
            connection = new SQLiteConnection();
            connection.ConnectionString = "Data Source=" + "SQLData\\SQLiteDataTable.db";
            connection.Open();

            createTable();
        }

        ~SQL()
        {
            connection.Close();
            connection.Dispose();
        }

        SQLiteConnection connection;

        public void showTable(ref Data data)
        {
            foreach (var element in data.map)
            {
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO dataTable (Id, Name, Value, Comment, Date) VALUES (@i, @n, @v, @c, @d)";
                command.Parameters.AddWithValue("@i", element.Key);
                command.Parameters.AddWithValue("@n", data.map[element.Key].name);
                command.Parameters.AddWithValue("@v", data.map[element.Key].value);

                if(data.map[element.Key].comment == null)
                    command.Parameters.AddWithValue("@c", "");
                else
                command.Parameters.AddWithValue("@c", data.map[element.Key].comment);

                command.Parameters.AddWithValue("@d", data.map[element.Key].date);
                command.ExecuteNonQuery();
            }

            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\SQLData\\SQLiteDataTable.db");
        }

        void createTable()
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "CREATE TABLE IF NOT EXISTS dataTable ( Id INTEGER NOT NULL, Name VARCHAR(100) NOT NULL, Value VARCHAR(100) NOT NULL, Comment VARCHAR(100) NOT NULL, Date DOUBLE NOT NULL);";
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM dataTable";
            command.ExecuteNonQuery();
        }

        public void resetTable()
        {
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROM dataTable";
            command.ExecuteNonQuery();
        }
    }
}
