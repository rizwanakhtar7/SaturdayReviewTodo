using FluentValidation;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Features.Todos.Commands
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        { 
            RuleFor(t => t.Name).NotEmpty().WithMessage("'{PropertyName}' cannot be blank.");

        }
    }
}
