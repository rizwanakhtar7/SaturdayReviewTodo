using MediatR;
using SaturdayReviewTodo.Application.Core.Contracts.Persistence;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Queries.Get
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, Todo>
    {
        private readonly IAsyncRepository<Todo> _context;

        public GetTodoQueryHandler(IAsyncRepository<Todo> context)
        {
            _context = context;
        }
        public async Task<Todo> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            // TO DO add ERROR HANDLING 

            return await _context.GetEntityById(request.Id);
           
        }
    }
}
