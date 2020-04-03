using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDatenbank
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true;";

            var con = new SqlConnection(conString);
            con.Open();
            Console.WriteLine("DB Verbindung hergestellt");

            var cmdCount = new SqlCommand();
            cmdCount.Connection = con;
            cmdCount.CommandText = "SELECT Count(*) FROM Employees";
            var count = cmdCount.ExecuteScalar();
            Console.WriteLine($"{count} Employees in DB");

            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Employees ORDER BY BirthDate";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string vorname = reader["FirstName"].ToString();
                string nachname = reader.GetString(1);
                DateTime bDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
                Console.WriteLine($"{vorname} {nachname} ({bDate:d})");
            }

            var mySqlCon = new MySqlConnection("server ==...");


            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
