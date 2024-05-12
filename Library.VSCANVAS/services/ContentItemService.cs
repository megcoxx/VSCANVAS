using Library.VSCANVAS.Models;

namespace Library.VSCANVAS.Services;
public class ContentItemService
{
    private IList<ContentItem> contentitems;
    private string? query;
    private static object _lock = new();
    private static ContentItemService? instance;

    public static ContentItemService Current
    {
        get
        {
            lock (_lock)
            {
                instance ??= new ContentItemService();
            }
            return instance;
        }
    }

    public IEnumerable<ContentItem> ContentItems
    {
        get
        {
            return contentitems.Where(
                c =>
                    c.Name.ToUpper().Contains(query ?? string.Empty));
        }
    }

    private ContentItemService()
    {
        contentitems = new List<ContentItem>{
            new ContentItem{Name = "TestContentItem1", ContentItemId = 1},
            new ContentItem{Name = "TestContentItem2", ContentItemId = 2}
        };
    }

    public int Count()
    {
        return contentitems.Count;
    }

    public ContentItem? Get(int id)
    {
        return contentitems.FirstOrDefault(c => c.ContentItemId == id);
    }

    public void AddOrUpdate(ContentItem contentitem)
    {
        if (contentitem.ContentItemId <= 0 || contentitem.ContentItemId == null)
        {
            contentitem.ContentItemId = (this.Count()) + 1;
            contentitems.Add(contentitem);
        }
    }

    public void Remove(ContentItem contentitem)
    {
        contentitems.Remove(contentitem);
    }
}

