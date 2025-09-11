using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }

        public int? Smartnes;
        public string? FunnyJokesMade;
        public ICollection<PassportPhoto>? PassportPhotos;






        /* lisa kol omadust õpilasele, ise mõtled välja */

    }
}
