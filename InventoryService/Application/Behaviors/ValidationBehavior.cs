using FluentValidation;
using MediatR;

namespace InventoryService.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> 
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any()){
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select( x=> x.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(e => e.Errors).Where(f => f != null).ToList();

                if(failures.Count != 0){
                    throw new ValidationException(failures);
                }
            }

            return await next();
        }
    }
}