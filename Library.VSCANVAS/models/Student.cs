namespace Library.VSCANVAS.Models
{
    public class Student
    {
        public int? StudentId { get; set; }

        public string? Name { get; set; }

        public string? Classification { get; set; }

        public string? Grade { get; set; }

        public Student(){ }

        public override string ToString()
        {
            return $"{Name} - {Classification} - {StudentId}";
        }
    }
}
