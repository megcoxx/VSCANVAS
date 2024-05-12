using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class AddStudentToCourseView : ContentPage
{
    public int StudentId { get; set; }

    public AddStudentToCourseView()
    {
        InitializeComponent();
        BindingContext = new CourseViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorHome");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CourseViewModel)?.Refresh();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel)?.Refresh();
    }

    private void CourseClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel)?.addStudentToCourse(StudentId);
        if (StudentId != null)
        {
            Shell.Current.GoToAsync($"//SpecificStudentInformation?studentId={StudentId}");
        }
    }
}
