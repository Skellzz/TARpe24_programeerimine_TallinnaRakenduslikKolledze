using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        /**/
        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        /**/
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        /**/
        public string FirstName { get; set; }
        /**/
        [Display(Name = "Õpetaja nimi")]



        
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        /**/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Tööleasumiskuupäev")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssigments { get; set; }
        public OfficeAssignment? OfficeAssignemt { get; set; }


        [Required]
        [Display(Name="Palk")]
        public int Palk { get; set; }

        [Display(Name="Kas on Kriminaal Süüdistusi?")]
        public string KriminaalSüüdistusi { get; set; }

        [Display(Name="Kas on Lapsi?")]
        public string Lapsi { get; set; }

    }
}
