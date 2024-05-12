using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    internal class CourseViewModel : INotifyPropertyChanged
    {
        private CourseService courseSvc;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Query { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Courses));
        }

        public void Remove()
        {
            courseSvc.Remove(SelectedCourse);
            Refresh();
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(courseSvc.Courses.
                    ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Course SelectedCourse { get; set; }

        public void addStudentToCourse(int studentID)
        {
            courseSvc.AddStudent(studentID, SelectedCourse);
            Refresh();
        }

        public void addCourse()
        {
            courseSvc.AddOrUpdate(new Course { Name = "This is a new student." });
            NotifyPropertyChanged(nameof(Courses));
        }

        public CourseViewModel()
        {
            courseSvc = CourseService.Current;
        }
    }
}