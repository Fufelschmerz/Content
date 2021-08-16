using Api.Request.Abstractions;
using Api.Response.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Request.Builders.Abstractions
{
    public interface IAsyncRequestBuilder
    {
        Task ExecuteAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest;

        Task<TRequestResult> ExecuteAsync<TRequest, TRequestResult>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TRequestResult>
            where TRequestResult : IResponse;
    }
}
