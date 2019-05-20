using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduModels;

namespace EduWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Models.EduModelsContainer context)
        {
            context.Database.EnsureCreated();

            //Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{Name="test1",IdentityCard="33012219670119009x",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{Name="test2",IdentityCard="33012219670119010x",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="test3",IdentityCard="33012219670119011x",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Name="test4",IdentityCard="33012219670119012x",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="Yan",IdentityCard="33012219670119005x",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{Name="Peggy",IdentityCard="33012219670119006x",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{Name="Laura",IdentityCard="33012219670119007x",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{Name="Nino",IdentityCard="33012219670119008x",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            //context.SaveChanges();

            var courses = new Course[]
            {
            new Course{Title="Chemistry",Usable=true},
            new Course{Title="语文",Usable=true},
            new Course{Title="数学",Usable=true},
            new Course{Title="英语",Usable=true},
            new Course{Title="科学",Usable=true},
            new Course{Title="思政",Usable=true},
            new Course{Title="道法",Usable=true}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            //context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                //在Enrollment中添加新建的Student和Course 会自动增加到数据库中。这里新增两Student和3个Course.
            new Enrollment{Student=students[0], Course=courses[0],Score=70.5f,Semester=201801},
            new Enrollment{Student=students[0], Course=courses[1],Score=89f,Semester=201801},
            new Enrollment{Student=students[1], Course=courses[2],Score=60.5f,Semester=201801},
            //new Enrollment{Student_Id=26,Course_Id=19,Score=50f,Semester=201801},
            //new Enrollment{Student_Id=26,Course_Id=20,Score=87f,Semester=201801},
            //new Enrollment{Student_Id=27,Course_Id=15},
            //new Enrollment{Student_Id=27,Course_Id=16},
            //new Enrollment{Student_Id=28,Course_Id=16,Score=89.5f,Semester=201801},
            //new Enrollment{Student_Id=28,Course_Id=17,Score=77.5f,Semester=201801},
            //new Enrollment{Student_Id=29,Course_Id=18},
            //new Enrollment{Student_Id=30,Course_Id=19,Score=8.5f,Semester=201801},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
