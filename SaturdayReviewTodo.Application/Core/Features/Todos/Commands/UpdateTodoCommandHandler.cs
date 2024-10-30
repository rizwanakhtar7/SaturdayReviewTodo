using MediatR;
using SaturdayReviewTodo.Application.Core.Contracts.Persistence;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, UpdateTodoCommandResponse>
    {
        private readonly IAsyncRepository<Todo> _context;

        public UpdateTodoCommandHandler(IAsyncRepository<Todo> context)
        {
            _context = context;
            
        }
        public async Task<UpdateTodoCommandResponse> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var updateTodoCommandResponse = new UpdateTodoCommandResponse();

            var getTodo = await _context.GetEntityById(request.Id);

            if (getTodo == null)
            {
                updateTodoCommandResponse.Success = false;
                updateTodoCommandResponse.Message = "No such ID exists";

                return updateTodoCommandResponse;
            }
            

            if (updateTodoCommandResponse.Success)
            {
                getTodo.Name = request.Name;
                getTodo.DatePosted = request.DatePosted;
                getTodo.Description = request.Description;
               

                var updatedResult = await _context.UpdateEntity(getTodo);
                updateTodoCommandResponse.Todo = updatedResult;
            }

            return updateTodoCommandResponse;
        }
    }
}
