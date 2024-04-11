using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;

namespace les7
{
    internal class Program
    {
        /*public class Db
        {
            Db(string name)
            {
                dbname = $"{name}.db";
                connection_string = $" Data Source = {dbname};";
            }

            public void init_quary()
            {
                string init_str = "CREATE TABLE IF NOT EXISTS " +
                "Pc_Chaptres (Id INTEGER, Name_ch TEXT, Cost INTEGER);";
            }


            public string dbname;
            public string connection_string;
        }*/


        static void Main(string[] args)
        {
            string dbname = "PC_chpter.db";
            string connection_string = $" Data Source = {dbname};";

            string init_query = "CREATE TABLE IF NOT EXISTS " +
                "PC_chapter (Id INTEGER, Name_ch TEXT, Cost INTEGER, Quantity INTEGER);";

            string insert_query = "INSERT INTO PC_chapter (Id, Name_ch, cost, Quantity)" + "VALUES (1, 'RTX 3090', 100000, 5);";

            string insert_query2 = "INSERT INTO PC_chapter (Id, Name_ch, cost, Quantity)" + "VALUES (2, 'RTX 4090', 200000, 3);" +"\n"
               + "INSERT INTO PC_chapter (Id, Name_ch, cost, Quantity)" + "VALUES (3, 'RTX 4070', 70000, 12);";

            string select_query = "SELECT * FROM PC_Chapter;";

            SQLiteConnection connection = new SQLiteConnection(connection_string);
            connection.Open();
            Console.WriteLine("Соединение установлено");

            SQLiteCommand command01 = new SQLiteCommand(init_query, connection);
            command01.ExecuteNonQuery();
            Console.WriteLine($"Выполнен запрос {init_query}");

            SQLiteCommand command02 = new SQLiteCommand(insert_query, connection);
            command02.ExecuteNonQuery();
            Console.WriteLine($"Выполнен запрос {insert_query}");


            SQLiteCommand command03 = new SQLiteCommand(insert_query2, connection);
            command03.ExecuteNonQuery();
            Console.WriteLine($"Выполнен запрос {insert_query2}");

            SQLiteCommand command04 = new SQLiteCommand(select_query, connection);
            SQLiteDataReader reader =  command04.ExecuteReader();
            Console.WriteLine($"Выполнен запрос {select_query}");
            Console.WriteLine($"{reader.GetName(0)}\t " +
                $"{reader.GetName(1)}\t"+
                $"{reader.GetName(2)}\t"+
                $"{reader.GetName(3)}\t"
                );
            while (reader.Read())
            {
                Console.WriteLine(
                $"{reader.GetValue(0)}\t " +
                $"{reader.GetValue(1)}\t" +
                $"{reader.GetValue(2)}\t" +
                $"{reader.GetValue(3)}\t"
                );
            }
            connection.Close();
            Console.WriteLine("Соединение прервано");



            Console.WriteLine("Добро пожаловать в вашу базу данных");
            Console.WriteLine("действия: 1- прочитать данные с базы" + "\n"+ 
                "2-добавить данные в базу");
            
            

        }
    }
}
