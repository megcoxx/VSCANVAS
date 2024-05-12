using System.Collections.ObjectModel;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels;

public class SpecificModuleInstructorViewModel : ContentView
{
    public SpecificModuleInstructorViewModel(int cId)
    {
        module = ModuleService.Current.Get(cId) ?? new Module();
    }

    private Module? module;

    public ObservableCollection<ContentItem> ContentItems
    {
        get
        {
            return new ObservableCollection<ContentItem>(module.Contents);
        }
        set
        {
            if (module == null)
            {
                module = new Module();
            }
        }
    }

    public string Name
    {
        get
        {
            return module?.Name ?? string.Empty;
        }
        set
        {
            if (module == null)
            {
                module = new Module();
            }
            module.Name = value;
        }
    }

    public string Description
    {
        get
        {
            return module?.Description ?? string.Empty;
        }
        set
        {
            if (module == null)
            {
                module = new Module();
            }
            module.Description = value;
        }
    }
}

