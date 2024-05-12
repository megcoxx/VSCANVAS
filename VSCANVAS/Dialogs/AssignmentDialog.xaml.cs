using VSCANVAS.ViewModels;

namespace VSCANVAS.Dialogs;

[QueryProperty(nameof(AssignmentId), "assignmentId")]
public partial class AssignmentDialog : ContentPage
{
    public int AssignmentId { get; set; }

    public AssignmentDialog()
    {
        InitializeComponent();
        BindingContext = new AssignmentDialogViewModel(0);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllAssignments");
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentDialogViewModel)?.AddAssignment();
        Shell.Current.GoToAsync("//AllAssignments");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AssignmentDialogViewModel(AssignmentId);
    }
}
