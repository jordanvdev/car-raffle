using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace car_raffle_model.Endpoint_Response;

public class HttpResultToActionResultFilter : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var result = (context.Result) as ObjectResult;

        if (result == null)
            return;
        
        var httpResult = result.Value as IHttpResult;
        
        context.Result = httpResult.StatusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(new { Result = httpResult.Result }),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(httpResult.Error),
            HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(httpResult.Error),
            HttpStatusCode.Forbidden => new ObjectResult(httpResult.Error)
            {
                StatusCode = (int)HttpStatusCode.Forbidden
            },
            HttpStatusCode.NotFound => new NotFoundObjectResult(httpResult.Error),
        };
    }
}