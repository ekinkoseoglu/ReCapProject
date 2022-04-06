using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Backbone.Extensions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
               await HandleExceptionAsync(context,e);

            }


        }

        public Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;


            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                context.Response.StatusCode = 400;


                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = message,
                    ValidationErrors = errors
                    
                }.ToString());
            }

            else
            {
                return context.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode, //  "500" as it declared from top 
                    Message = message // "Internal Server Error" as it has described from top
                }.ToString());
            }


        }

    }
}
