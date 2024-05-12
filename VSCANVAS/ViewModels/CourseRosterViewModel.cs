using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    public class CourseRosterViewModel : INotifyPropertyChanged
    {
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Student SelectedStudent { get; set; }

        private Course? course;

        private Student? student;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Student> Roster
        {
            get
            {
                return new ObservableCollection<Student>(course.Roster);
            }
            set
            {
                if (course == null)
                {
                    course = new Course();
                }
            }
        }

        public CourseRosterViewModel(int cId)
        {
            if (cId == 0)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(cId) ?? new Course();
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Roster));
        }

        public void Remove()
        {
            CourseService.Current.RemoveFromRoster(SelectedStudent, course);
            Refresh();
        }
    }
}
