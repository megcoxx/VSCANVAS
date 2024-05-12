using VSCANVAS.ViewModels;

namespace VSCANVAS;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void InstructorViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorHome");
    }

    private void StudentViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//CoursesEnrolled?studentId={1}");
    }
}


