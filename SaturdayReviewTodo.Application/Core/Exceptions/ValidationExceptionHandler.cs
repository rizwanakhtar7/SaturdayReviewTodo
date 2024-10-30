﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Exceptions
{
    public class ValidationExceptionHandler : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationExceptionHandler(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        
        }
    }
}
