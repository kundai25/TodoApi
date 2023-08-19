namespace TodoApi.Model
{
    public class Category : AuditTable
    {
        public int Id { get; set; }
        public string TaskCategory { get; set; } = string.Empty;
        public IEnumerable<TodoTask> Tasks { get; set; }
       
    }
}
