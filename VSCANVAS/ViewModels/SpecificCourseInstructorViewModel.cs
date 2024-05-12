using System.Collections.ObjectModel;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;
namespace VSCANVAS.ViewModels;

public class SpecificCourseInstructorViewModel : ContentView
{
    public SpecificCourseInstructorViewModel(int cId)
    {
        course = CourseService.Current.Get(cId) ?? new Course();
    }

    private Course? course;

    public string Name
    {
        get
        {
            return course?.Name ?? string.Empty;
        }
        set
        {
            if (course == null)
            {
                course = new Course();
            }
            course.Name = value;
        }
    }

    public ObservableCollection<Student> Roster
    {
        get
        {
            return new ObservableCollection<Student>(course.Roster);
        }
        set
        {
            if (course == null)
            {
                course = new Course();
            }
        }
    }

    public string Code
    {
        get
        {
            return course?.Code ?? string.Empty;
        }
        set
        {
            if (course == null)
            {
                course = new Course();
            }
            course.Code = value;
        }
    }

    public string Description
    {
        get
        {
            return course?.Description ?? string.Empty;
        }
        set
        {
            if (course == null)
            {
                course = new Course();
            }
            course.Description = value;
        }
    }
}
