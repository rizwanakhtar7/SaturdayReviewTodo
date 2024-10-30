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
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, int>
    {
        private IAsyncRepository<Todo> _context;

        public DeleteTodoCommandHandler(IAsyncRepository<Todo> context)
        {
            _context = context;
            
        }
        public async Task<int> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var getTodo = await _context.GetEntityById(request.id);

            if (getTodo == null)
            {
                throw new NotFoundException(nameof(getTodo), request.id);
            }

            await _context.DeleteEntity(getTodo);

            return getTodo.Id;
        }
    }
}
