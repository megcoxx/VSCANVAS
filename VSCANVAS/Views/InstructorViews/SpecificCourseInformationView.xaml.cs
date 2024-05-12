using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(CourseId), "courseId")]
public partial class SpecificCourseInformationView : ContentPage
{
    public int CourseId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllCourses");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SpecificCourseInstructorViewModel(CourseId);
    }

    public SpecificCourseInformationView()
    {
        BindingContext = new SpecificCourseInstructorViewModel(CourseId);
        InitializeComponent();
    }

    void AssignmentsClicked(object sender, EventArgs e)
    {
        int? courseId = CourseId;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//AllAssignments?courseId={courseId}");
        }
    }

    void ModulesClicked(object sender, EventArgs e)
    {
        int? courseId = CourseId;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//AllModules?courseId={courseId}");
        }
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? courseId = CourseId;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//CourseDetail?courseId={courseId}");
        }
    }

    void StudentsClicked(object sender, EventArgs e)
    {
        int? courseId = CourseId;
        if (courseId != null)
        {
            Shell.Current.GoToAsync($"//CourseRoster?courseId={courseId}");
        }
    }
}
