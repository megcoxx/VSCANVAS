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
        private CourseService courseSvc;
        private CourseRosterViewModel course;

        public string Query { get; set; }

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
                return new ObservableCollection<Student>(studentSvc.Students.
                    ToList().Where(c => c?.Name?.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }

        public Student SelectedStudent { get; set; }

        public void addStudent()
        {
            studentSvc.AddOrUpdate(new Student { Name = "This is a new student." });
            NotifyPropertyChanged(nameof(Students));
        }

        public void AddToCourse(int CourseId)
        {
            int sID = (int)SelectedStudent.StudentId;
            Course courseUsed = courseSvc.Get(CourseId);
            if (sID != null)
            {
                courseSvc.AddStudent(sID, courseUsed);
                course.Refresh();
            }
        }

        public StudentViewModel()
        {
            studentSvc = StudentService.Current;
            courseSvc = CourseService.Current;
        }
    }
}
