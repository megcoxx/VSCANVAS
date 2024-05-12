using Library.VSCANVAS.Models;

namespace Library.VSCANVAS.Services;
public class ModuleService
{
    private IList<Module> modules;
    private string? query;
    private static object _lock = new();
    private static ModuleService? instance;

    public static ModuleService Current
    {
        get
        {
            lock (_lock)
            {
                instance ??= new ModuleService();
            }
            return instance;
        }
    }

    public IEnumerable<Module> Modules
    {
        get
        {
            return modules.Where(
                c =>
                    c.Name.ToUpper().Contains(query ?? string.Empty));
        }
    }

    private ModuleService()
    {
        modules = new List<Module>{
            new Module{Name = "TestModule1", ModuleId = 1},
            new Module{Name = "TestModule2", ModuleId = 2}
        };
    }

    public int Count()
    {
        return modules.Count;
    }

    public Module? Get(int id)
    {
        return modules.FirstOrDefault(c => c.ModuleId == id);
    }

    public void AddOrUpdate(Module module)
    {
        if (module.ModuleId <= 0 || module.ModuleId == null)
        {
            module.ModuleId = (this.Count()) + 1;
            modules.Add(module);
        }
    }

    public void Remove(Module module)
    {
        modules.Remove(module);
    }
}

