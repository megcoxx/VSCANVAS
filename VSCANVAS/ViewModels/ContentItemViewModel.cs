using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    internal class ContentItemViewModel : INotifyPropertyChanged
    {
        private ContentItemService contentItemSvc;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Query { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(ContentItems));
        }

        public void Remove()
        {
            contentItemSvc.Remove(SelectedContentItem);
            Refresh();
        }

        public ObservableCollection<ContentItem> ContentItems
        {
            get
            {
                return new ObservableCollection<ContentItem>(contentItemSvc.ContentItems.
                    ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public ContentItem SelectedContentItem
        {
            get; set;
        }

        public void addContentItem()
        {
            contentItemSvc.AddOrUpdate(new ContentItem { Name = "This is a new content item." });
            NotifyPropertyChanged(nameof(ContentItems));
        }

        public ContentItemViewModel()
        {
            contentItemSvc = ContentItemService.Current;
        }
    }
}



