using System.Collections.Generic;
using System.Linq;

namespace HalloWeb.Models
{
    public class DataManager
    {
        static List<Maske> db = new List<Maske>();


        static DataManager()
        {
            db.Add(new Maske() { Hersteller = "6M", Farbe = "Blau", Größe = 7,Id=1 });
            db.Add(new Maske() { Hersteller = "VForce", Farbe = "Gelb", Größe = 7,Id=2 });
            db.Add(new Maske() { Hersteller = "Dye", Farbe = "Red", Größe = 4,Id=3 });
        }

        public void Add(Maske m) => db.Add(m);
        public void Delete(Maske m) => db.Remove(m);
        public Maske GetById(int id) => db.FirstOrDefault(x => x.Id == id);
        public IEnumerable<Maske> GetAll() => db;
        public void Update(Maske m)
        {
            var old = GetById(m.Id);
            Delete(old);
            Add(m);
        }
    }
}
