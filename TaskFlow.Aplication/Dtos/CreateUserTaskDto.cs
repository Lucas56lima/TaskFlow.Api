using System.ComponentModel.DataAnnotations;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Dtos
{
    public class CreateUserTaskDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string? Title { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string? Description { get; set; }
        public Status? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
