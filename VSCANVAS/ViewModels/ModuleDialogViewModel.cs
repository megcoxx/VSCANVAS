using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;
namespace VSCANVAS.ViewModels
{
    public class ModuleDialogViewModel
    {
        private Module? module;

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

        public ModuleDialogViewModel(int cId)
        {
            if (cId == 0)
            {
                module = new Module();
            }
            else
            {
                module = ModuleService.Current.Get(cId) ?? new Module();
            }
        }

        public void AddModule()
        {
            if (module != null)
            {
                ModuleService.Current.AddOrUpdate(module);
            }
        }
    }
}

