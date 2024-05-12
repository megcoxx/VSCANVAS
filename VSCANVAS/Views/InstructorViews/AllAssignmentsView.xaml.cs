using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class AllAssignmentsView : ContentPage
{
    public AllAssignmentsView()
    {
        InitializeComponent();
        BindingContext = new AssignmentViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//AssignmentDetail?assignmentId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? assignmentId = (BindingContext as AssignmentViewModel)?.SelectedAssignment?.AssignmentId;
        if (assignmentId != null)
        {
            Shell.Current.GoToAsync($"//AssignmentDetail?assignmentId={assignmentId}");
        }
    }

    private void PreviousClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//SpecificCourseInformation");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as AssignmentViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentViewModel)?.Remove();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentViewModel)?.Refresh();
    }

    void Button_Clicked(object sender, EventArgs e)
    {
        int? assignmentId = (BindingContext as AssignmentViewModel)?.SelectedAssignment?.AssignmentId;
        if (assignmentId != null)
        {
            Shell.Current.GoToAsync($"//SpecificAssignmentInformation?assignmentId={assignmentId}");
        }
    }
}
