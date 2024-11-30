using Microsoft.AspNetCore.Mvc;

namespace Example.General.TypedApi
{
    public class ObjectResult<TResponse> : ObjectResult, IObjectResult<TResponse>
    {
        public static IObjectResult<TResponse> Ok(TResponse? value)
            => new ObjectResult<TResponse>(value!, StatusCodes.Status200OK);

        public static IObjectResult<TResponse> BadRequest(object? value = null)
            => new ObjectResult<TResponse>(value, StatusCodes.Status400BadRequest);

        private ObjectResult(object? value, int? statusCode)
            : base(value)
        {
            StatusCode = statusCode;
        }
    }
}
