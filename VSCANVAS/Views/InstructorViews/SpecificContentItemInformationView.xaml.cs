using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

[QueryProperty(nameof(ContentItemId), "contentItemId")]
public partial class SpecificContentItemInformationView : ContentPage
{
    public int ContentItemId { get; set; }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AllContentItems");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new SpecificContentItemInstructorViewModel(ContentItemId);
    }

    public SpecificContentItemInformationView()
    {
        BindingContext = new SpecificContentItemInstructorViewModel(ContentItemId);
        InitializeComponent();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? contentItemId = ContentItemId;
        if (contentItemId != null)
        {
            Shell.Current.GoToAsync($"//ContentItemDetail?contentItemId={contentItemId}");
        }
    }
}