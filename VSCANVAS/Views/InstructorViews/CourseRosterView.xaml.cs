using Library.VSCANVAS.Models;
using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseRosterView : ContentPage
{
    public int CourseId { get; set; }
    public Student SelectedStudent { get; set; }

    public CourseRosterView()
    {
        InitializeComponent();
        BindingContext = new CourseRosterViewModel(0);
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//AllStudentsRosterView?courseId={CourseId}");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllCourses");
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//SpecificCourseInformation?courseId={courseId}");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseRosterViewModel(CourseId);
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//SpecificCourseInformation?courseId={CourseId}");
    }


    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseRosterViewModel)?.Remove();
    }
}