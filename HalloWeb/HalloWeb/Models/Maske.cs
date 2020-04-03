using System;
using System.Linq;
using System.Threading.Tasks;

namespace HalloWeb.Models
{
    public class Maske
    {
        public int Id { get; set; }

        public string Farbe { get; set; }

        public int Größe { get; set; }

        public string Hersteller { get; set; }

        public DateTime Datum { get; set; }
    }
}
