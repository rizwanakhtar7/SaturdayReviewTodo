using MediatR;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Queries.Get
{
    public class GetTodoQuery : IRequest<Todo>
    {
        public int Id { get; set; }

        public GetTodoQuery(int Id)
        {
            this.Id = Id;
            
        }
    }
}
