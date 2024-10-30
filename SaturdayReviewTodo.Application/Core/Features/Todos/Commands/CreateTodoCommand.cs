using MediatR;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class CreateTodoCommand : IRequest<CreateTodoCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public CreateTodoCommand(string Name, string Description, DateTime DatePosted)
        {
            this.DatePosted = DatePosted;
            this.Description = Description;
            this.Name = Name;
            
        }
    }
}
