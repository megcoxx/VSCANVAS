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
            new Course{Name = "TestCourse2", CourseId =2}
        };
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

    public void Delete(Course courseToDelete)
    {
        courses.Remove(courseToDelete);
    }
}