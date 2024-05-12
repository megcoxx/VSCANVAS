using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class CoursesEnrolled : ContentPage
{
    public int StudentId = 1;

    public CoursesEnrolled()
    {
        InitializeComponent();
        BindingContext = new CoursesEnrolledViewModel(StudentId);
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CoursesEnrolled");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as CourseViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel)?.Remove();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel)?.Refresh();
    }

    private void CourseClicked(object sender, EventArgs e)
    {
        int? courseId = (BindingContext as CourseViewModel)?.SelectedCourse?.CourseId;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//SpecificCourseInformation?courseId={courseId}");
        }
    }
}