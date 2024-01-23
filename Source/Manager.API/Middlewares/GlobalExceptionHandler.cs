
using System.Net;
using FluentValidation;
using Manager.API.Utilities;
using Manager.Domain.Validators;
namespace Manager.API.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try 
            {
                await next(context);
            } 
            catch (DomainValidationException exception)
            {
                await ExceptionHandler(context, "Usuário inválido", exception.Errors);
            }
            catch (ValidationException exception)
            {
                await ExceptionHandler(context, "Erro de validação", exception.Errors.Select(x => x.ErrorMessage));
            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex.Message);
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(
                    new Responses.Result()
                );
            }
        }

        private async static Task ExceptionHandler(HttpContext context, string message, IEnumerable<string>? errors)
        {   
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            await context.Response.WriteAsJsonAsync(
                Responses.DomainErrorMessage(message, errors!)
            );
        } 
    }
}