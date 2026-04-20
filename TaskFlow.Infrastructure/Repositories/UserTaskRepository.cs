using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
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

        public async Task<List<UserTask>> GetAll()
        {
            return await _context.UserTasks.ToListAsync();
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
