using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Kaebus
    {
        [Key]
        public int KuritarvitajadID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string OpilaneVOpetaja { get; set; }
        public string KuritarvitajaDescription { get; set; }
        public int KuritegevusteArv { get; set; }
        public string Kaebuse { get; set; }

        public ICollection<Instructor>? KaebuseAdmin { get; set; }

        }
}
