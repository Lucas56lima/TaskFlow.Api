using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Context
{
    public class UserTaskDbContext : DbContext
    {      
        public UserTaskDbContext(DbContextOptions<UserTaskDbContext> options) : base(options)
        {
        }
        public DbSet<UserTask> UserTasks { get; set; }

    }
}