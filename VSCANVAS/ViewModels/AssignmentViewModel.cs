using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    internal class AssignmentViewModel : INotifyPropertyChanged
    {
        private AssignmentService assignmentSvc;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Query { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Assignments));
        }

        public void Remove()
        {
            assignmentSvc.Remove(SelectedAssignment);
            Refresh();
        }

        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(assignmentSvc.Assignments.
                    ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Assignment SelectedAssignment
        {
            get; set;
        }

        public void addAssignment()
        {
            assignmentSvc.AddOrUpdate(new Assignment { Name = "This is a new student." });
            NotifyPropertyChanged(nameof(Assignments));
        }

        public AssignmentViewModel()
        {
            assignmentSvc = AssignmentService.Current;
        }
    }
}

