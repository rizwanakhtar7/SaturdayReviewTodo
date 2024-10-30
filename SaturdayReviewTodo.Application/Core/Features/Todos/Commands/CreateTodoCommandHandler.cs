using MediatR;
using SaturdayReviewTodo.Application.Core.Contracts.Persistence;
using SaturdayReviewTodo.Application.Core.Entities;
using SaturdayReviewTodo.Application.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoCommandResponse>
    {
        private readonly IAsyncRepository<Todo> _context;

        public CreateTodoCommandHandler(IAsyncRepository<Todo> context)
        {
            _context = context;
            
        }
        public async Task<CreateTodoCommandResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var createTodoCommandResponse = new CreateTodoCommandResponse();

            var validation = new CreateTodoCommandValidator();
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.Errors.Count() > 0)
            {
                createTodoCommandResponse.Success = false;
                createTodoCommandResponse.ValidationErrrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createTodoCommandResponse.ValidationErrrors.Add(error.ErrorMessage);
                }

                throw new ValidationExceptionHandler(validationResult);
                 
            }

            if (createTodoCommandResponse.Success)
            {
                var todo = new Todo
                {
                    Name = request.Name,
                    Description = request.Description,
                    DatePosted = request.DatePosted,
                };




                var createdTodo = await _context.CreateEntity(todo);
                createTodoCommandResponse.Todo = createdTodo;

            }

            return createTodoCommandResponse;

            


        }
    }
}
