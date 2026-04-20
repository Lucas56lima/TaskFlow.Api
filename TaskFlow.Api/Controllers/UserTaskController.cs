using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _service;

        private readonly ILogger<UserTaskController> _logger;

        public UserTaskController(ILogger<UserTaskController> logger, IUserTaskService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _service.GetAll();
                return Ok(tasks);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tasks");
                return StatusCode(500, "An error occurred while retrieving tasks.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var task = await _service.GetById(id);
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserTaskDto task)
        {
            try
            {
                var result = await _service.Create(task);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error creating task");
                return StatusCode(500, "An error occurred while creating the task.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error deleting task");
                return StatusCode(500, $"An error occurred while deleting the task: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto task)
        {
            try
            {
                var result = await _service.Update(task);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error updating task");
                return StatusCode(500, "An error occurred while updating the task.");
            }
        }
    }
}
