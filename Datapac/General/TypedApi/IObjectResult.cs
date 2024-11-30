using Microsoft.AspNetCore.Mvc;

namespace Example.General.TypedApi
{
    public interface IObjectResult<TResponse> : IActionResult
    {
    }
}
