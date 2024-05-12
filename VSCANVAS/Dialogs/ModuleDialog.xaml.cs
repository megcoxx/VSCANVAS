using VSCANVAS.ViewModels;

namespace VSCANVAS.Dialogs;

[QueryProperty(nameof(ModuleId), "moduleId")]
public partial class ModuleDialog : ContentPage
{
    public int ModuleId { get; set; }

    public ModuleDialog()
    {
        InitializeComponent();
        BindingContext = new ModuleDialogViewModel(0);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllModules");
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleDialogViewModel)?.AddModule();
        Shell.Current.GoToAsync("//AllModules");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleDialogViewModel(ModuleId);
    }
}
