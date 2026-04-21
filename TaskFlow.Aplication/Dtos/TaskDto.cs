using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Dtos
{
    public class TaskDto : UserTask
    {
    }
    public class ColumnDto
    {
        public string? Name { get; set; }
        public int Status { get; set; }
        public List<TaskDto>? Tasks { get; set; }
    }
}
