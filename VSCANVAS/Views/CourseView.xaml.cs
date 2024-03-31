using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class CourseView : ContentPage
{
    public CourseView()
    {
        InitializeComponent();
        BindingContext = new CourseViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//CourseDetail?courseId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? courseId = (BindingContext as CourseViewModel)?.SelectedCourse?.CourseId;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//CourseDetail?courseId={courseId}");
        }
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
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
}