using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class SpecificStudentInformationView : ContentPage
{
    public int StudentId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllStudents");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SpecificStudentInstructorViewModel(StudentId);
    }

    public SpecificStudentInformationView()
    {
        InitializeComponent();
        BindingContext = new SpecificStudentInstructorViewModel(StudentId);
    }

    private void EnrollInCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//AddStudentToCourse?studentId={StudentId}");
        //Running through function but not updating on course side
    }
}
