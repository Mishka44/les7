using System;
using System.Data.SQLite;

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

            

            string insert_query2 = "INSERT INTO PC_chapter (Id, Name_ch, cost, Quantity)" + "VALUES (2, 'RTX 4090', 200000, 3);" + "\n"
               + "INSERT INTO PC_chapter (Id, Name_ch, cost, Quantity)" + "VALUES (3, 'RTX 4070', 70000, 12);";

            string select_query = "SELECT * FROM PC_Chapter;";


            SQLiteConnection connection = new SQLiteConnection(connection_string);
            connection.Open();
            /*Console.WriteLine("Соединение установлено");*/

            SQLiteCommand command01 = new SQLiteCommand(init_query, connection);
            command01.ExecuteNonQuery();
            /*Console.WriteLine($"Выполнен запрос {init_query}");*/

            /*SQLiteCommand command02 = new SQLiteCommand(insert_query, connection);
            command02.ExecuteNonQuery();
            Console.WriteLine($"Выполнен запрос {insert_query}");


            SQLiteCommand command03 = new SQLiteCommand(insert_query2, connection);
            command03.ExecuteNonQuery();
            Console.WriteLine($"Выполнен запрос {insert_query2}");*/


            Console.WriteLine("Добро пожаловать в вашу базу данных, ваши имеющиеся данные");



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
            Console.WriteLine("выберетеде действие: 1-добавить новую информацию" +
                "\t 2-удалить информацию по номеру айди" + "\n 3-Вывести информацию по определённому параметру");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    string id, name_ch, cost, quantity;
                    Console.WriteLine("введите айди:");
                        id = Console.ReadLine();
                    Console.WriteLine("Введите наименование товара");
                    name_ch = Console.ReadLine();
                    Console.WriteLine("Введите цену товара");
                    cost = Console.ReadLine();
                    Console.WriteLine("Введите количество товара");
                    quantity = Console.ReadLine();
                    string insert_query = $"INSERT INTO PC_chapter (Id, Name_ch, cost, Quantity)" + $"VALUES ({id}, '{name_ch}', {cost}, {quantity});";

                    SQLiteCommand command_insert = new SQLiteCommand(insert_query, connection);
                    command_insert.ExecuteNonQuery();
                    break; 

                case 2:
                    Console.WriteLine("Введите id строчки, которую хотите удалить");
                    string del_id = Console.ReadLine();
                    string delete_query = $"DELETE FROM PC_Chapter\r\nWHERE Id = {del_id};";
                    SQLiteCommand command_del = new SQLiteCommand(delete_query, connection);
                    command_del.ExecuteNonQuery();
                    break;

                case 3:
                    Console.WriteLine("Введите стоимость,больше которой будем делать выборку:");
                    string cost_ch = Console.ReadLine();

                    string select_query2 = $"SELECT * FROM PC_Chapter\r\nwhere cost > {cost_ch};";
                    SQLiteCommand command_rep = new SQLiteCommand(select_query2, connection);
                    SQLiteDataReader reader_2 = command_rep.ExecuteReader();

                    
                    Console.WriteLine($"{reader_2.GetName(0)}\t " +
                        $"{reader_2.GetName(1)}\t" +
                        $"{reader.GetName(2)}\t" +
                        $"{reader_2.GetName(3)}\t"
                        );
                    while (reader_2.Read())
                    {
                        Console.WriteLine(
                        $"{reader_2.GetValue(0)}\t " +
                        $"{reader_2.GetValue(1)}\t" +
                        $"{reader_2.GetValue(2)}\t" +
                        $"{reader_2.GetValue(3)}\t"
                        );
                    }
                    break;

            }


            connection.Close();





            Console.WriteLine("Соединение прервано");



        }
    }
}
