using Example.Domain.Messages.BorrowingMessages;
using Example.General.ApiHelpers;
using Example.General.TypedApi;
using Example.Services.BorrowingServices.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingController(ILogger<BorrowingController> logger, IServiceProvider serviceProvider) : ControllerBase
    {
        [HttpPost(Name = "CreateBorrowing")]
        public Task<IActionResult> Book(CreateBorrowingRequest request) 
            => RequestHandler.HandleRequestAsync(() => serviceProvider.GetRequiredService<ICreateBorrowingService>().HandlerAsync(request), logger);
        
        [HttpPut(Name = "ReturnBorrowing")]
        public Task<IObjectResult<bool>> Book(ReturnBorrowingRequest request)
            => RequestHandler.HandleRequestAsync(() => serviceProvider.GetRequiredService<IReturnBorrowingService>().HandlerAsync(request), logger);
    }
}
