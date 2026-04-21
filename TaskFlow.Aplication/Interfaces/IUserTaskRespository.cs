using TaskFlow.Application.Dtos;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface IUserTaskRespository
    {
        Task<UserTask> GetById(int id);
        Task<List<ColumnDto>> GetAll();
        Task Add(UserTask task);
        Task Update(UserTask task);
        Task Delete(int id);
    }
}

