using FileForm.Api.Dto;

namespace FileForm.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
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
            _logger.LogError($"saagsfg{"sdfas"}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var response = new ApiException();

            var json = response.ToJson();
            

            await context.Response.WriteAsync(json);
        }
    }
}