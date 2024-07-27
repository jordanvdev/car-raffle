using System.Net;

namespace car_raffle_model.Endpoint_Response;

public interface IHttpResult<T>
{
    HttpStatusCode StatusCode { get; set; }
    T Result { get; set; }
    string? Error { get; set; }
}