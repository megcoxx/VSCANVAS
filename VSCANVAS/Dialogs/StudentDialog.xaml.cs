using VSCANVAS.ViewModels;

namespace VSCANVAS.Dialogs;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentDialog : ContentPage
{
    public int StudentId { get; set; }

    public StudentDialog()
    {
        InitializeComponent();
        BindingContext = new StudentDialogViewModel(0);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllStudents");
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentDialogViewModel)?.AddStudent();
        Shell.Current.GoToAsync("//AllStudents");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new StudentDialogViewModel(StudentId);
    }
}