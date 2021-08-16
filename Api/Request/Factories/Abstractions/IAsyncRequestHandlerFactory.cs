using Api.Request.Abstractions;
using Api.Request.Handlers;
using Api.Response.Abstractions;

namespace Api.Request.Factories.Abstractions
{
    public interface IAsyncRequestHandlerFactory
    {
        IAsyncRequestHandler<TRequest> Create<TRequest>()
            where TRequest : IRequest;

        IAsyncRequestHandler<TRequest, TResponse> Create<TRequest, TResponse>()
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse;
    }
}
