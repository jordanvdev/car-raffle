using System.Net;

namespace car_raffle_model.Endpoint_Response;

public class HttpResult<T> : IHttpResult<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T Result { get; set; }
    public string? Error { get; set; }

    public HttpResult()
    {
        
    }

    private HttpResult(HttpStatusCode statusCode, T result)
    {
        StatusCode = statusCode;
        Result = result;
    }
    
    private HttpResult(HttpStatusCode statusCode, string error)
    {
        StatusCode = statusCode;
        Error = error;
    }
    
    public static HttpResult<T> Ok(T result) => new HttpResult<T>(HttpStatusCode.OK, result);
    public static HttpResult<T> NotFound(string error) => new HttpResult<T>(HttpStatusCode.NotFound, error);
    public static HttpResult<T> BadRequest(string error) => new HttpResult<T>(HttpStatusCode.BadRequest, error);
    public static HttpResult<T> Forbidden(string error) => new HttpResult<T>(HttpStatusCode.Forbidden, error);
}