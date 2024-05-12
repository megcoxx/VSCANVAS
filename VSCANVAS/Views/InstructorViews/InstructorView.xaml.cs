using VSCANVAS.ViewModels;
using VSCANVAS.Views;
namespace VSCANVAS.Views;

public partial class InstructorView : ContentPage
{
    public InstructorView()
    {
        InitializeComponent();
    }

    private void ViewAllCoursesClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllCourses");
    }

    private void ViewAllStudentsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllStudents");
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}