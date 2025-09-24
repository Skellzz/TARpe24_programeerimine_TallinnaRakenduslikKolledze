using System;
using TallinnaRakenduslikKolledz.Models;

public class DbInitalizer
{
    public static void Initalize(SchoolContext context)
    {
        context.Database.EnsureCreated();
        if (!context.Students.Any())
        {
            return;
        }
        var Students = new Student[]
        {
             new Student{FirstName = "George",LastName = "Teemus",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Abrakam",LastName = "Linkon",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Abr",LastName = "Baber",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "AbduLabu",LastName = "Labubu",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Swiger",LastName = "Dwinger",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Justin",LastName = "Biiber",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Michael",LastName = "Jakson",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Paaar",LastName = "Kursust",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Ära",LastName = "kopputa",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Mis",LastName = "Arvad",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Mikteeioota",LastName = "õpetaja",EnrollmentDate = DateTime.Now, },
             new Student{FirstName = "Label",LastName = "Baber",EnrollmentDate = DateTime.Now, },
        };
        context.Students.AddRange(Students);
        context.SaveChanges();
        if (context.Courses.Any()) { return; }
        var courses = new Course[]
        {
            new Course{CourseID=1010,Title="Programeerimine",Credits=3,},
            new Course{CourseID=1020,Title="Linux Õppe",Credits=3,},
            new Course{CourseID=1030,Title="Multimeedia",Credits=3,},
            new Course{CourseID=1040,Title="Õmblemine",Credits=4,},
            new Course{CourseID=1050,Title="Trigonometry",Credits=4,},
            new Course{CourseID=1060,Title="Programeerimise alused",Credits=3,},
            new Course{CourseID=1070,Title="Harjusrakenduste alused",Credits=4,},
        };
        context.Courses.AddRange(courses);
        context.SaveChanges();
        if (context.Enrollments.Any()) { return; }
        var enrollments = new Enrollment[]
        {
            new Enrollment{StudentID=1, CourseID=1040, CurrentGrade=Grade.A },
            new Enrollment{StudentID=1, CourseID=1050, CurrentGrade=Grade.X },
            new Enrollment{StudentID=1, CourseID=1030, CurrentGrade=Grade.B },
            new Enrollment{StudentID=2, CourseID=1010, CurrentGrade=Grade.C },
            new Enrollment{StudentID=2, CourseID=1020, CurrentGrade=Grade.B },
            new Enrollment{StudentID=2, CourseID=1030, CurrentGrade=Grade.F },
            new Enrollment{StudentID=3, CourseID=1010, CurrentGrade=Grade.F },
            new Enrollment{StudentID=3, CourseID=1040, CurrentGrade=Grade.C },
            new Enrollment{StudentID=4, CourseID=1050, CurrentGrade=Grade.A },
            new Enrollment{StudentID=5, CourseID=1010, CurrentGrade=Grade.A },
            new Enrollment{StudentID=6, CourseID=1020, CurrentGrade=Grade.A },
            new Enrollment{StudentID=7, CourseID=1070, CurrentGrade=Grade.F },
            new Enrollment{StudentID=7, CourseID=1030, CurrentGrade=Grade.A },

        };
        context.Enrollments.AddRange(enrollments);
        context.SaveChanges();
        if (context.Instructors.Any()) { return; }
        var instructors = new Instructor[]
        {
            new Instructor{FirstName="Pekka",LastName="Pouta",HireDate=DateTime.Now, KriminaalSüüdistusi="Jah"},
            new Instructor{FirstName="Juku",LastName="Labubu",HireDate=DateTime.Now, KriminaalSüüdistusi="Ei" },
            new Instructor{FirstName="Mari",LastName="Mets",HireDate=DateTime.Now, KriminaalSüüdistusi="Mister Morris"},
            new Instructor{FirstName="Jüri",LastName="Juurikas",HireDate=DateTime.Now, KriminaalSüüdistusi="Ei"},
        };
        context.Instructors.AddRange(instructors);
        context.SaveChanges();
    }

}


