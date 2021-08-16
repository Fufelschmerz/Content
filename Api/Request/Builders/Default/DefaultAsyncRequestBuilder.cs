using Api.Request.Abstractions;
using Api.Request.Builders.Abstractions;
using Api.Request.Factories.Abstractions;
using Api.Response.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Request.Builders.Default
{
    public class DefaultAsyncRequestBuilder : IAsyncRequestBuilder
    {
        private readonly IAsyncRequestHandlerFactory _asyncRequestHandlerFactory;

        public DefaultAsyncRequestBuilder(IAsyncRequestHandlerFactory asyncRequestHandlerFactory)
        {
            _asyncRequestHandlerFactory = asyncRequestHandlerFactory ?? throw new ArgumentNullException(nameof(asyncRequestHandlerFactory));
        }

        public Task ExecuteAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest
        {
            return _asyncRequestHandlerFactory.Create<TRequest>().ExecuteAsync(request);
        }

        public Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            return _asyncRequestHandlerFactory.Create<TRequest, TResponse>().ExecuteAsync(request);
        }
    }
}
