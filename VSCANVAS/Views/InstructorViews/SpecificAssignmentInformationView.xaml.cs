using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(AssignmentId), "assignmentId")]
public partial class SpecificAssignmentInformationView : ContentPage
{
    public int AssignmentId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllAssignments");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SpecificAssignmentInstructorViewModel(AssignmentId);
    }

    public SpecificAssignmentInformationView()
    {
        BindingContext = new SpecificAssignmentInstructorViewModel(AssignmentId);
        InitializeComponent();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? assignmentId = AssignmentId;
        if (assignmentId != null)
        {
            Shell.Current.GoToAsync($"//AssignmentDetail?assignmentId={assignmentId}");
        }
    }
}