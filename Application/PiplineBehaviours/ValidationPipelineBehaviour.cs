using Application.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PiplineBehaviours
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                List<string> errors = new();

                var validationResult = await Task
                    .WhenAll(
                    _validators
                    .Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResult.SelectMany(x => x.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    foreach (var failure in failures)
                    {
                        errors.Add(failure.ErrorMessage);
                    }

                    throw new CustomValidationException("One or more validation failure(s) occured", errors);
                    
                }
            }
            return await next();
        }
    }
}
