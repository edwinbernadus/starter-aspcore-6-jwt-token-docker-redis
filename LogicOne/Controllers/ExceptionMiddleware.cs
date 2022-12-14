using System;
using System.Net;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Http;

namespace Logic0ne.Controllers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        // context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        // context.Response.StatusCode = (int)HttpStatusCode.OK;

        // var generateErr = new ErrorDetails()
        // {
        //     StatusCode = context.Response.StatusCode,
        //     Message = $"{exception.Message} - {exception.StackTrace}"
        // };

        // var generateErr = ContentData<Student>.GenerateErr(exception.Message);


        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // var generateErr = $"{exception.Message} - {exception.StackTrace}";

            var generateErr = new ErrorInternal()
            {
                Message = $"{exception.Message}",
                StackTrace = exception.StackTrace
            };
            
            try
            {
                var text2 = generateErr.ToString();
                await context.Response.WriteAsync(text2);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}