﻿using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TruckManager.Application.Common.Behaviors
{
    internal class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Starting request {@requestName}, {@DateTimeUtc}", 
                typeof(TRequest).Name, 
                DateTime.UtcNow);

            var result = await next();

            if (result.IsError)
            {
                _logger.LogError(
                "Request failure {@requestName},{@Error}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                result.Errors,
                DateTime.UtcNow);

                return result;
            }

            _logger.LogInformation(
                "Completed request {@requestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            return result;
        }
    }
}
