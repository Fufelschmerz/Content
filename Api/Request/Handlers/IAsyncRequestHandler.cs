using Api.Request.Abstractions;
using Api.Response.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Request.Handlers
{
    public interface IAsyncRequestHandler<in TRequest> where TRequest : IRequest
    {
        Task ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IAsyncRequestHandler<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResponse
    {
        Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}
