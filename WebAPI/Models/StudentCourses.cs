namespace WebAPI.Models
{
    public class StudentCourses
    {
        public virtual string EMPLID { get; set; } // compound key
        public virtual string COURSE_ID { get; set; } // compound key
        public virtual string GRADE { get; set; }
        public virtual int SCORE { get; set; }
    }
}
