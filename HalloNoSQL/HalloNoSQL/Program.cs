using LiteDB;
using System;

namespace HalloNoSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new LiteDatabase(@"C:\temp\MyData.db"))
            {
                var col = db.GetCollection<Auto>("Autos");

                //    foreach (var item in col.Query().ToList())
                //    {
                //        Console.WriteLine(item.Hersteller);
                //    }
                col.Insert(new Auto() { Farbe = "blau", Baujahr = DateTime.Now.AddDays(-1047) });


            }

            Console.ReadLine();
        }
    }

    class Auto
    {

        public int Id { get; set; }

        public string Farbe { get; set; }
        //public string Hersteller { get; set; }
        public DateTime Baujahr { get; set; }
    }
}
