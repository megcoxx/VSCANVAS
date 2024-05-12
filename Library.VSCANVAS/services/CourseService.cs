using Library.VSCANVAS.Models;

namespace Library.VSCANVAS.Services;
public class CourseService
{
    private IList<Course> courses;
    private string? query;
    private static object _lock = new();
    private static CourseService? instance;

    public static CourseService Current
    {
        get
        {
            lock (_lock)
            {
                instance ??= new CourseService();
            }
            return instance;
        }
    }

    public IEnumerable<Course> Courses
    {
        get
        {
            return courses.Where(
                c =>
                    c.Name.ToUpper().Contains(query ?? string.Empty));
        }
    }

    private CourseService()
    {
        courses = new List<Course>{
            new Course{Name = "TestCourse1", CourseId = 1},
            new Course{Name = "TestCourse2", CourseId = 2}
        };
        courses.FirstOrDefault().Roster = new List<Student>();
    }

    public int Count()
    {
        return courses.Count;
    }

    public Course? Get(int id)
    {
        return courses.FirstOrDefault(c => c.CourseId == id);
    }

    public void AddOrUpdate(Course course)
    {
        if (course.CourseId <= 0 || course.CourseId == null)
        {
            course.CourseId = (this.Count()) + 1;
            courses.Add(course);
        }
    }

    public void Remove(Course course)
    {
        courses.Remove(course);
    }

    public void AddStudent(int studentID, Course course)
    {
        Student student = StudentService.Current.Get(studentID);
        if (!course.Roster.Contains(student))
        {
            course.Roster.Add(student);
            student.CoursesEnrolledIn.Add(course);
        };
    }

    public void RemoveFromRoster(Student student, Course course)
    {
        course.Roster.Remove(student);
    }
}

