using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(ModuleId), "moduleId")]
[QueryProperty(nameof(CourseId), "courseId")]
public partial class SpecificModuleInformationView : ContentPage
{
    public int ModuleId { get; set; }
    public int CourseId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllModules");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SpecificModuleInstructorViewModel(ModuleId);
    }
    public SpecificModuleInformationView()
    {
        InitializeComponent();
        BindingContext = new SpecificModuleInstructorViewModel(ModuleId);
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? moduleId = ModuleId;
        if (moduleId != null)
        {
            Shell.Current.GoToAsync($"//ModuleDetail?moduleId={moduleId}");
        }
    }

    private void ReturnBtnClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllModules");

    }

    private void ModuleContentsBtnClicked(object sender, EventArgs e)
    {
        int? moduleId = ModuleId;
        if (moduleId != null)
        {
            Shell.Current.GoToAsync($"//AllContentItems?moduleId={moduleId}");
        }
    }
}