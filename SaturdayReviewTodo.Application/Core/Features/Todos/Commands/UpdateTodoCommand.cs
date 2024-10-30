using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class UpdateTodoCommand : IRequest<UpdateTodoCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }
        public UpdateTodoCommand(int Id, string Name, string Description, DateTime DatePosted)
        {
            this.Id = Id;   
            this.DatePosted = DatePosted;
            this.Description = Description;
            this.Name = Name;

        }
    }
}
