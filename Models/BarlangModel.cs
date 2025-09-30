using System.ComponentModel.DataAnnotations;

namespace Barlangok.Models
{
    public class BarlangModel
    {
        [Key]
        public int ID { get; set; }
        public string Nev { get; set; }
        public int Hossz { get; set; }
        public int Kiterjedes { get; set; }
        public int Melyseg { get; set; }
        public int Magassag { get; set; }
        public string Telepules { get; set; }
    }
}
