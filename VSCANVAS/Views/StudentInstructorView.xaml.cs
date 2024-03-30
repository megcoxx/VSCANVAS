using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class StudentInstructorView : ContentPage
{
    public StudentInstructorView()
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
        Shell.Current.GoToAsync("//Instructor");
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as StudentViewModel)?.Remove();
    }
}