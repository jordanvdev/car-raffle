using System.Net;

namespace car_raffle_model.Endpoint_Response;

public interface IHttpResult
{
    HttpStatusCode StatusCode { get; }
    object Result { get; }
    string? Error { get; }
}