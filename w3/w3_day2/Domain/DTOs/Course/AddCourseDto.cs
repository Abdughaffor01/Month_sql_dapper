namespace Domain.DTOs.Course
{
    public class AddCourseDto
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Fee { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StudentLimit { get; set; }
    }
}
