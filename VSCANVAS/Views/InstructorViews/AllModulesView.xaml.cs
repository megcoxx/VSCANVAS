using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class AllModulesView : ContentPage
{
    public AllModulesView()
    {
        InitializeComponent();
        BindingContext = new ModuleViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ModuleDetail?moduleId=0");
    }

    private void PreviousPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//SpecificCourseInformation");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ModuleViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleViewModel)?.Remove();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleViewModel)?.Refresh();
    }

    private void OpenClicked(object sender, EventArgs e)
    {
        int? moduleId = (BindingContext as ModuleViewModel)?.SelectedModule?.ModuleId;
        if (moduleId != null)
        {
            Shell.Current.GoToAsync($"//SpecificModuleInformation?moduleId={moduleId}");
        }
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        int? moduleId = (BindingContext as ModuleViewModel)?.SelectedModule?.ModuleId;
        if (moduleId != null)
        {
            Shell.Current.GoToAsync($"//SpecificModuleInformation?moduleId={moduleId}");
        }
    }
}