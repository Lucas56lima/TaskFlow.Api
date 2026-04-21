using TaskFlow.Application.Common;
using TaskFlow.Application.Dtos;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface IUserTaskService
    {
        Task<ResultT<UserTask>> Create(CreateUserTaskDto task);
        Task<Result> Update(UpdateTaskDto task);
        Task<Result> Delete(int id);
        Task<List<ColumnDto>> GetAll();
        Task<UserTask> GetById(int id);
    }
}
