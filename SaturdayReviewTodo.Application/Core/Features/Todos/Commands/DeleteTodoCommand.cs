using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class DeleteTodoCommand : IRequest<int>
    {
        public int id { get; set; }

        public DeleteTodoCommand(int id) {
            this.id = id;
        }

    }
}
