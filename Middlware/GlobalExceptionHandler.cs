using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using dalil.Core.Exptions; // تأكدي أن مسار الـ namespace للاستثناءات صحيح

namespace dalil.Core.GlobalExceptionHandler
{
    public class GlobalExceptionHandler(
        IProblemDetailsService problemDetails,
        ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context, Exception exception, CancellationToken ct)
        {
            var (status, title) = exception switch
            {
                ValidationException => (400, "Validation failed"),
                NotFoundExption => (404, "Resource not found"),
                ConflictExtpion => (409, "Conflict"),
                _ => (500, "An unexpected error occurred")
            };

            if (status == 500) 
                logger.LogError(exception, "Unhandled exception");

            context.Response.StatusCode = status;

            var problem = new ProblemDetails 
            { 
                Status = status, 
                Title = title,
                Detail = exception is NotFoundExption or ConflictExtpion ? exception.Message : null 
            };

            if (exception is ValidationException ve)
            {
                problem.Extensions["errors"] = ve.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
            }

            return await problemDetails.TryWriteAsync(new() { HttpContext = context, ProblemDetails = problem });
        }
    }
}