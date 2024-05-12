using Library.VSCANVAS.Models;

namespace Library.VSCANVAS.Services;
public class AssignmentService
{
    private IList<Assignment> assignments;
    private string? query;
    private static object _lock = new();
    private static AssignmentService? instance;

    public static AssignmentService Current
    {
        get
        {
            lock (_lock)
            {
                instance ??= new AssignmentService();
            }
            return instance;
        }
    }

    public IEnumerable<Assignment> Assignments
    {
        get
        {
            return assignments.Where(
                c =>
                    c.Name.ToUpper().Contains(query ?? string.Empty));
        }
    }

    private AssignmentService()
    {
        assignments = new List<Assignment>{
            new Assignment{Name = "TestAssignment1", AssignmentId = 1},
            new Assignment{Name = "TestAssignment2", AssignmentId = 2}
        };
    }

    public int Count()
    {
        return assignments.Count;
    }

    public Assignment? Get(int id)
    {
        return assignments.FirstOrDefault(c => c.AssignmentId == id);
    }

    public void AddOrUpdate(Assignment assignment)
    {
        if (assignment.AssignmentId <= 0 || assignment.AssignmentId == null)
        {
            assignment.AssignmentId = (this.Count()) + 1;
            assignments.Add(assignment);
        }
    }

    public void Remove(Assignment assignment)
    {
        assignments.Remove(assignment);
    }
}