﻿namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
     (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validatorResult = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var failures = validatorResult.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
