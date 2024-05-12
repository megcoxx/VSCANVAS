using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;
namespace VSCANVAS.ViewModels;

public class SpecificContentItemInstructorViewModel : ContentView
{
    public SpecificContentItemInstructorViewModel(int cId)
    {
        contentItem = ContentItemService.Current.Get(cId) ?? new ContentItem();
    }

    private ContentItem? contentItem;

    public string Name
    {
        get
        {
            return contentItem?.Name ?? string.Empty;
        }
        set
        {
            if (contentItem == null)
            {
                contentItem = new ContentItem();
            }
            contentItem.Name = value;
        }
    }

    public string Description
    {
        get
        {
            return contentItem?.Description ?? string.Empty;
        }
        set
        {
            if (contentItem == null)
            {
                contentItem = new ContentItem();
            }
            contentItem.Description = value;
        }
    }
}
