using Example.General.TypedApi;

using Microsoft.AspNetCore.Mvc;

namespace Example.General.ApiHelpers
{
    public static class RequestHandler
    {
        private const string CONTACT_ADMINISTRATOR = "For more informations contact administrator";

        public static async Task<IActionResult> HandleRequestAsync(Func<Task> request, ILogger logger)
        {
            try
            {
                await request();
                return new OkResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return new BadRequestObjectResult(CONTACT_ADMINISTRATOR);
            }
        }

        public static async Task<IObjectResult<TResponse>> HandleRequestAsync<TResponse>(Func<Task<TResponse>> request, ILogger logger)
        {
            try
            {
                return ObjectResult<TResponse>.Ok(await request());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return ObjectResult<TResponse>.BadRequest(CONTACT_ADMINISTRATOR);
            }
        }        
    }
}
