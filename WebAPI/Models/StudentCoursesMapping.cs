using FluentNHibernate.Mapping;

namespace WebAPI.Models
{
    public class StudentCoursesMapping : ClassMap<StudentCourses>
    {
        public StudentCoursesMapping()
        {
            Table("StudentCourses");

            Id(x => x.EMPLID, "EMPLID");  
            Map(x => x.COURSE_ID, "COURSE_ID"); 
            Map(x => x.GRADE);
            Map(x => x.SCORE);
        }
    }
}
