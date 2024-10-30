using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaturdayReviewTodo.Application.Core.Entities;
using SaturdayReviewTodo.Application.Core.Features.Todos.Commands;
using SaturdayReviewTodo.Application.Core.Features.Todos.Queries.Get;
using SaturdayReviewTodo.Application.Core.Features.Todos.Queries.List;

namespace SaturdayReviewTodo.API.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    { 


        private readonly IMediator _mediator;
        public TodoController(IMediator mediator) 
        {
            _mediator = mediator;
        
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Todo>>> GetAllTodos()
        {
            var query = new GetAllTodoQuery();
            var result = await _mediator.Send(query);

            //if (result.Count() > 2)
            //{
            //    throw new Exception();
            //}

            return Ok(result);
        }

        [HttpGet("{todoId}")]
        public async Task<ActionResult<Todo>> GetTodoById(int todoId)
        {
            var query = new GetTodoQuery(todoId);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(TodoCreation todo)
        {
            var command = new CreateTodoCommand(todo.Name, todo.Description, todo.DatePosted);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTodoById), new { todoId = result.Todo.Id }, result.Todo );


        }

        [HttpDelete("{todoId}")]
        public async Task<ActionResult> DeleteTodo(int todoId)
        {
            var query = new DeleteTodoCommand(todoId);
            var result = await _mediator.Send(query);

            return NoContent();
        }

        [HttpPut("{todoId}")]
        public async Task<ActionResult<Todo>> UpdateTodo(int todoId, TodoUpdate todo)
        {
         

            var command = new UpdateTodoCommand(todoId, todo.Name, todo.Description, todo.DatePosted);
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Todo);
        }
    }
}
