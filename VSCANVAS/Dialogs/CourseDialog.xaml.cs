using VSCANVAS.ViewModels;

namespace VSCANVAS.Dialogs;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class CourseDialog : ContentPage
{
    public int CourseId { get; set; }

    public CourseDialog()
    {
        InitializeComponent();
        BindingContext = new CourseDialogViewModel(0);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Course");
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Course");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel(CourseId);
    }
}