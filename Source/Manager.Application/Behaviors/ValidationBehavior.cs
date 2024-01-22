using FluentValidation;
using MediatR;

namespace Manager.Application.Behavior
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var results = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context)));
                var failures = results.SelectMany(x => x.Errors).Where(x => x != null).ToList();

                if (failures.Count != 0) 
                    throw new ValidationException(failures);
            }
            
            return await next();
        }
    }
}