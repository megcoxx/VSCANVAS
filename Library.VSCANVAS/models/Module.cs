namespace Library.VSCANVAS.Models
{
    public class Module
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? ModuleId { get; set; }

        public List<ContentItem>? Contents;
    }
}