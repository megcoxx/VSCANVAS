using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;
namespace VSCANVAS.ViewModels;

public class SpecificStudentInstructorViewModel : ContentView
{
    public SpecificStudentInstructorViewModel(int cId)
    {
        student = StudentService.Current.Get(cId) ?? new Student();
    }

    private Student? student;

    public string Name
    {
        get
        {
            return student?.Name ?? string.Empty;
        }
        set
        {
            if (student == null)
            {
                student = new Student();
            }
            student.Name = value;
        }
    }
}