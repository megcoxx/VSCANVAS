using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;
namespace VSCANVAS.ViewModels
{
    public class CourseDialogViewModel
    {

        private Course? course;
        public string Name
        {
            get
            {
                return course?.Name ?? string.Empty;
            }
            set
            {
                if (course == null)
                {
                    course = new Course();
                }
                course.Name = value;
            }
        }

        public string Code
        {
            get
            {
                return course?.Code ?? string.Empty;
            }
            set
            {
                if (course == null)
                {
                    course = new Course();
                }
                course.Code = value;
            }
        }

        public string Description
        {
            get
            {
                return course?.Description ?? string.Empty;
            }
            set
            {
                if (course == null)
                {
                    course = new Course();
                }
                course.Description = value;
            }
        }

        public CourseDialogViewModel(int cId)
        {
            if(cId == 0){
                course = new Course();
            }
            else{
                course = new Course { Name =  "SUCCESS"};
            }
        }

        public void AddCourse()
        {
            if (course != null)
            {
                CourseService.Current.AddOrUpdate(course);
            }
        }
    }
}
