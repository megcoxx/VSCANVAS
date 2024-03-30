using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    internal class StudentViewModel : INotifyPropertyChanged
    {
        private StudentService studentSvc;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Students));
        }

        public void Remove()
        {
            studentSvc.Remove(SelectedStudent);
            Refresh();
        }
        public ObservableCollection<Student> Students
        {
            get
            {
                return new ObservableCollection<Student>(studentSvc.Students);
            }
        }

        public Student SelectedStudent
        {
            get; set;
        }

        public void addStudent()
        {
            studentSvc.AddOrUpdate(new Student { Name = "This is a new student." });
            NotifyPropertyChanged(nameof(Students));
        }

        public StudentViewModel()
        {
            studentSvc = StudentService.Current;
        }
    }
}
