namespace Library.VSCANVAS.Models
{
    public class Course
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public int? CourseId { get; set; }

        public int? StudentId { get; set; }

        public string? Description { get; set; }

        public List<Student> Roster;

        public List<Assignment> Assignments;

        public List<Module> Modules;

        public Course()
        {
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public Course(string? code, string name, string? description)
        {
            Code = code;
            Name = name;
            Description = description;
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public override String ToString()
        {
            return $"{Name} {Code} {CourseId}";
        }
    }
}
