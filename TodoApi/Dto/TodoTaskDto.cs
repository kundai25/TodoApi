using TodoApi.Model;

namespace TodoApi.Dto
{
    public class TodoTaskDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string TaskDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string TaskStatus { get; set; } = string.Empty;
    }
}
