using Library.VSCANVAS.Models;
using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class AllStudentsRosterView : ContentPage
{
    public int CourseId { get; set; }

    public AllStudentsRosterView()
    {
        InitializeComponent();
        BindingContext = new StudentViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddBtnClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.AddToCourse(CourseId);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as StudentViewModel)?.Refresh();
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//SpecificCourseInformation?courseId={CourseId}");
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.Refresh();
    }
}
