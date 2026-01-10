using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Kaebus
    {
        [Key]
        public int StutentId { get; set; }  
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ReasonForSuspension { get; set; }
        public DateTime SuspensionStartDate { get; set; }
        public DateTime SuspensionEndDate { get; set; }
        public string? NoteForParents { get; set; }
    }
}