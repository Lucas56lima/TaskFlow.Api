using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class UserTask
    {
        public int Id { get; set; }     
        public string? Title { get; set; }       
        public string? Description { get; set; }       
        public Status? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
