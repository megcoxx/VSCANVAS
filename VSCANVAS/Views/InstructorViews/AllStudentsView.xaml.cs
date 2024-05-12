using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class AllStudentsView : ContentPage
{
    public AllStudentsView()
    {
        InitializeComponent();
        BindingContext = new StudentViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//StudentDetail?studentId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? studentId = (BindingContext as StudentViewModel)?.SelectedStudent?.StudentId;
        if (studentId != null)
        {
            Shell.Current.GoToAsync($"//StudentDetail?studentId={studentId}");
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as StudentViewModel)?.Refresh();
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InstructorHome");
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.Remove();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.Refresh();
    }

    private void StudentClicked(object sender, EventArgs e)
    {
        int? studentId = (BindingContext as StudentViewModel)?.SelectedStudent?.StudentId;
        if (studentId != null)
        {
            Shell.Current.GoToAsync($"//SpecificStudentInformation?studentId={studentId}");
        }
    }
}