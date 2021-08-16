using Api.Response.Abstractions;

namespace Api.Request.Abstractions
{
    public interface IRequest
    {
    }

    public interface IRequest<out TResponse> where TResponse : IResponse
    {

    }
}
