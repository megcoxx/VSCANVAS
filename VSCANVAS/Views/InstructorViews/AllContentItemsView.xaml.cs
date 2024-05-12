using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class AllContentItemsView : ContentPage
{
    public AllContentItemsView()
    {
        InitializeComponent();
        BindingContext = new ContentItemViewModel();
    }

    private void BackToHomeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ContentItemDetail?contentItemId=0");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        int? contentItemId = (BindingContext as ContentItemViewModel)?.SelectedContentItem?.ContentItemId;
        if (contentItemId != null)
        {
            Shell.Current.GoToAsync($"//ContentItemDetail?contentItemId={contentItemId}");
        }
    }

    private void PreviousClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//SpecificModuleInformation");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ContentItemViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as ContentItemViewModel)?.Remove();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ContentItemViewModel)?.Refresh();
    }

    void Button_Clicked(object sender, EventArgs e)
    {
        int? contentItemId = (BindingContext as ContentItemViewModel)?.SelectedContentItem?.ContentItemId;
        if (contentItemId != null)
        {
            Shell.Current.GoToAsync($"//SpecificContentItemInformation?contentItemId={contentItemId}");
        }
    }
}

