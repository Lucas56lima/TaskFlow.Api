using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskFlow.Application.Dtos;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("User Tasks")]
    public class UserTaskController : ControllerBase
    {
        private readonly IUserTaskService _service;
        private readonly ILogger<UserTaskController> _logger;

        public UserTaskController(
            ILogger<UserTaskController> logger,
            IUserTaskService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("tasks")]
        [SwaggerOperation(
            Summary = "Get all tasks",
            Description = "Returns all tasks registered in the system"
        )]
        [ProducesResponseType(typeof(IEnumerable<UserTask>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _service.GetAll();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tasks");
                return StatusCode(500, "An error occurred while retrieving tasks.");
            }
        }

        [HttpGet("tasks/{id}")]
        [SwaggerOperation(
            Summary = "Get task by id",
            Description = "Returns a specific task by its ID"
        )]
        [ProducesResponseType(typeof(UserTask), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var task = await _service.GetById(id);

                if (task == null)
                    return NotFound();

                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving task by id");
                return StatusCode(500, "An error occurred while retrieving the task.");
            }
        }

        [HttpPost("tasks")]
        [SwaggerOperation(
            Summary = "Create a new task",
            Description = "Creates a new task in the system"
        )]
        [ProducesResponseType(typeof(CreateUserTaskDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Add([FromBody] CreateUserTaskDto task)
        {
            try
            {
                var result = await _service.Create(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating task");
                return StatusCode(500, "An error occurred while creating the task.");
            }
        }

        [HttpPut("tasks")]
        [SwaggerOperation(
            Summary = "Update task",
            Description = "Updates an existing task"
        )]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto task)
        {
            try
            {
                var result = await _service.Update(task);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating task");
                return StatusCode(500, "An error occurred while updating the task.");
            }
        }

        [HttpDelete("tasks/{id}")]
        [SwaggerOperation(
            Summary = "Delete task",
            Description = "Deletes a task from the system"
        )]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _service.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting task");
                return StatusCode(500, $"An error occurred while deleting the task: {ex.Message}");
            }
        }
    }
}