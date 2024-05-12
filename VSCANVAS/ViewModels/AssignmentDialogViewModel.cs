using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;
namespace VSCANVAS.ViewModels
{
    public class AssignmentDialogViewModel
    {
        private Assignment? assignment;

        public string Name
        {
            get
            {
                return assignment?.Name ?? string.Empty;
            }
            set
            {
                if (assignment == null)
                {
                    assignment = new Assignment();
                }
                assignment.Name = value;
            }
        }

        public int TotalAvailablePoints
        {
            get
            {
                return assignment?.TotalAvailablePoints ?? 0;
            }
            set
            {
                if (assignment == null)
                {
                    assignment = new Assignment();
                }
                assignment.TotalAvailablePoints = value;
            }
        }

        public string Description
        {
            get
            {
                return assignment?.Description ?? string.Empty;
            }
            set
            {
                if (assignment == null)
                {
                    assignment = new Assignment();
                }
                assignment.Description = value;
            }
        }

        public AssignmentDialogViewModel(int cId)
        {
            if (cId == 0)
            {
                assignment = new Assignment();
            }
            else
            {
                assignment = AssignmentService.Current.Get(cId) ?? new Assignment();
            }
        }

        public void AddAssignment()
        {
            if (assignment != null)
            {
                AssignmentService.Current.AddOrUpdate(assignment);
            }
        }
    }
}
