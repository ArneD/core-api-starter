using System;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Infrastructure.Validation
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var aggregateException = context.Exception as AggregateException;

            if (context.Exception is ValidationException ||
                (aggregateException != null && aggregateException.InnerExceptions.Any(exception => exception is ValidationException)))
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
