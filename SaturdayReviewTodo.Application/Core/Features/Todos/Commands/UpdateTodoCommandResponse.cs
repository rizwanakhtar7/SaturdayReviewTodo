using SaturdayReviewTodo.Application.Core.Common;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class UpdateTodoCommandResponse : BaseResponse
    {
        public UpdateTodoCommandResponse() : base() { }

        public Todo Todo { get; set; } = default!;
    }
}
