using MediatR;
using SaturdayReviewTodo.Application.Core.Contracts.Persistence;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Queries.List
{
    public class GetAllTodoQueryHandler : IRequestHandler<GetAllTodoQuery, IReadOnlyList<Todo>>
    {
        private readonly IAsyncRepository<Todo> _context;

        public GetAllTodoQueryHandler(IAsyncRepository<Todo> context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Todo>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetAllAsync();
            
        }
    }
}
