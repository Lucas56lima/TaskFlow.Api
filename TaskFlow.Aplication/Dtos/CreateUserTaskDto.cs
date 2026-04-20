using System.ComponentModel.DataAnnotations;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Dtos
{
    public class CreateUserTaskDto
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public Status? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
