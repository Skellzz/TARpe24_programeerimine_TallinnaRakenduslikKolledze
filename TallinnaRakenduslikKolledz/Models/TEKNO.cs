using Microsoft.EntityFrameworkCore.Query;

namespace TallinnaRakenduslikKolledz.Models
{
    public class TEKNO
    {
        public int TeknoID { get; set; }
        public string TeknoNimetus{ get; set; }
        public string TeknoDescription { get; set; }
        public int TeknoArv { get; set; }
        public int TeknoHind { get; set; }

        public ICollection<Instructor>? TeknoAdmin { get; set; }

        }
}
