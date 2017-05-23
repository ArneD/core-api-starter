﻿using System;
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
            var validationException = context.Exception as ValidationException;
            var aggregateException = context.Exception as AggregateException;
            
            if (validationException == null && aggregateException != null && aggregateException.InnerExceptions.Any(exception => exception is ValidationException))
            {
                validationException = aggregateException.InnerExceptions.First(exception => exception is ValidationException) as ValidationException;
            }

            if (validationException != null)
            {
                context.Result = new BadRequestObjectResult(validationException.Errors.Select(failure => new ErrorMessage(failure)));
            }
        }
    }
}
