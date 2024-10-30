using Microsoft.AspNetCore.Mvc;
using SaturdayReviewTodo.Application.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace SaturdayReviewTodo.API.API.Middleware
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
            
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            } catch (Exception ex)
            {
                await HandleErrorAsync(context, ex);
               

            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "error in {message} application", ex.Message);

            // default 500 error

            var httpStatusCode = HttpStatusCode.InternalServerError;
            var errors = new List<string>();

            switch (ex)
            {
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case ValidationExceptionHandler validationEx:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    errors = validationEx.ValidationErrors;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";

            var problemDetails = new ProblemDetails
            {
                Title = ex.Message,
                Detail = "error occured",
                Status = (int)httpStatusCode
            };

            // If there are validation errors, include them in the response
            if (errors.Any())
            {
                problemDetails.Extensions["errors"] = errors;
            }

            var result = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(result);
        }
    }
}
