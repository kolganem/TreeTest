using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TreeWebAPI.Infrastructure.Exceptions;
using TreeWebAPI.Models;
using TreeWebAPI.Services;

namespace TreeWebAPI.Infrastructure.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context, [FromServices] IErrorRecordService errorRecordService)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, errorRecordService);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex, IErrorRecordService errorRecordService)
    {
        string errorType = nameof(Exception);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        if (ex is SecureException)
        {
            errorType = nameof(SecureException);
        }

        var response = new
        {
            errorInfo = new
            {
                message = "An error occurred while processing your request.",
                details = ex.Message,
            }
        };

        string errorData = JsonConvert.SerializeObject(response);
        
        ErrorRecord errorRecord = new()
        {
            Id = new Guid(), 
            TypeInfo = errorType, 
            Time = DateTime.UtcNow, 
            Data = JsonConvert.SerializeObject(new
            {
                message = ex.Message,
                stackTrace = ex.StackTrace
            })
        };
       
        await errorRecordService.Add(errorRecord);

        await context.Response.WriteAsync(errorData);
    }
}