
namespace Manager.API.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}