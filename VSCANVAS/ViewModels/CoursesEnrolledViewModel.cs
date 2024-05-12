using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    internal class CoursesEnrolledViewModel : INotifyPropertyChanged
    {
        private CourseService courseSvc;
        private StudentService studentSvc = StudentService.Current;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Query { get; set; }
        private Student? student;

        public CoursesEnrolledViewModel(int studentID)
        {
            if (studentID == 0)
            {
                student = new Student();
            }
            else
            {
                student = StudentService.Current.Get(studentID) ?? new Student();
            }
        }


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
                return new ObservableCollection<Course>(student.CoursesEnrolledIn);
            }
            set
            {
                if (student == null)
                {
                    student = new Student();
                }
            }
        }

        public Course SelectedCourse { get; set; }


    }
}
