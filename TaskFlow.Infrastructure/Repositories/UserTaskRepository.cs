using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;
using TaskFlow.Infrastructure.Context;

namespace TaskFlow.Infrastructure.Repositories
{
    public class UserTaskRepository : IUserTaskRespository
    {
        private readonly UserTaskDbContext _context;
        public UserTaskRepository(UserTaskDbContext context)
        {
            _context = context;
        }
        public async Task Add(UserTask task)
        {
           await _context.UserTasks.AddAsync(task);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask != null)
            {
                _context.UserTasks.Remove(userTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ColumnDto>> GetAll()
        {
            var tasks = await _context.UserTasks.ToListAsync();

            var result = Enum.GetValues(typeof(Status))
                .Cast<Status>()
                .Select(status => new ColumnDto
                {
                    Name = status.ToString(),
                    Status = (int)status,
                    Tasks = tasks
                        .Where(t => t.Status == status)
                        .Select(task => new TaskDto
                        {
                            Id = task.Id,
                            Title = task.Title,
                            Description = task.Description,
                            Status = task.Status                           
                        })
                        .ToList()
                })
                .ToList();

            return result;
        }

        public async Task<UserTask> GetById(int id)
        {
            return await _context.UserTasks.FindAsync(id);
        }

        public async Task Update(UserTask task)
        {      
            await _context.SaveChangesAsync();          
        }
    }
}
