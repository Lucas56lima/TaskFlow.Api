using TaskFlow.Application.Common;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRespository _repository;

        public UserTaskService(IUserTaskRespository repository)
        {
            _repository = repository;
        }

        public async Task<ResultT<UserTask>> Create(CreateUserTaskDto task)
        {
            if(string.IsNullOrEmpty(task.Title))
            {
               return ResultT<UserTask>.Fail("Task title cannot be empty.");
            }
            if(string.IsNullOrEmpty(task.Description))
            {
                return ResultT<UserTask>.Fail("Task description cannot be empty.");
            }
            task.CreatedAt = DateTime.UtcNow;
            task.Status = Status.Pending;
            var userTask = new UserTask
            {
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt
            };
            await _repository.Add(userTask);
            return ResultT<UserTask>.Ok(userTask);
        }

        public async Task<Result> Delete(int id)
        {
            if(id <= 0)
            {
                return Result.Fail("Invalid task ID.");
            }
            var existingTask = await _repository.GetById(id);   
            if (existingTask == null)
            {
                return Result.Fail("Task not found.");
            }
            await _repository.Delete(id);
            return Result.Ok();
        }

        public async Task<ResultT<List<UserTask>>> GetAll()
        {
           var tasks = await _repository.GetAll();
           return ResultT<List<UserTask>>.Ok(tasks);           
        }

        public async Task<ResultT<UserTask>> GetById(int id)
        {
            if(id <= 0)
            {
                return ResultT<UserTask>.Fail("Invalid task ID.");
            }
            var task = await _repository.GetById(id);
            if (task == null)
            {
                return ResultT<UserTask>.Fail("Task not found.");                
            }
            return ResultT<UserTask>.Ok(task);
        }

        public async Task<Result> Update(UpdateTaskDto task)
        {
            if (task.Id <= 0)
            {
                return Result.Fail("Invalid task ID.");
            }
            var existingTask = await _repository.GetById(task.Id);
            if (existingTask == null)
            {
                return Result.Fail("Task not found.");
            }
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.CreatedAt = task.CreatedAt;
            await _repository.Update(existingTask);            
            return Result.Ok();
        }
    }
}
