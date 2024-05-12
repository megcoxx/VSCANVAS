using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    internal class ModuleViewModel : INotifyPropertyChanged
    {
        private ModuleService moduleSvc;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Query { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Modules));
        }

        public void Remove()
        {
            moduleSvc.Remove(SelectedModule);
            Refresh();
        }

        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(moduleSvc.Modules.
                    ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Module SelectedModule
        {
            get; set;
        }

        public void addModule()
        {
            moduleSvc.AddOrUpdate(new Module { Name = "This is a new student." });
            NotifyPropertyChanged(nameof(Modules));
        }

        public ModuleViewModel()
        {
            moduleSvc = ModuleService.Current;
        }
    }
}

