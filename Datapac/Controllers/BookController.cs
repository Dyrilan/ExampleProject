using Example.Domain.Messages.BookMessages;
using Example.General.ApiHelpers;
using Example.General.Attributes;
using Example.General.TypedApi;
using Example.Services.BookServices.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(ILogger<BookController> logger, IServiceProvider serviceProvider) : ControllerBase
    {
        [HttpPost(Name = "CreateBook")]
        public Task<IObjectResult<CreateBookResponse>> Book(CreateBookRequest request)
            => RequestHandler.HandleRequestAsync(() => serviceProvider.GetRequiredService<ICreateBookService>().HandlerAsync(request), logger);

        [HttpGet(Name = "GetBook")]
        public Task<IObjectResult<GetBookResponse>> Book([FromQuery][GuidNotEmpty] Guid id)
        {
            return RequestHandler.HandleRequestAsync(() => serviceProvider.GetRequiredService<IGetBookService>().HandlerAsync(id), logger);
        }

        [HttpPut(Name = "UpdateBook")]
        public Task<IObjectResult<UpdateBookResponse>> Book(UpdateBookRequest request)
            => RequestHandler.HandleRequestAsync(() => serviceProvider.GetRequiredService<IUpdateBookService>().HandlerAsync(request), logger);

        [HttpDelete(Name = "DeleteBook")]
        //I know it should be called Book but i have just one parameter it conflicts with GET book
        public Task<IActionResult> DeleteBook([FromQuery][GuidNotEmpty] Guid id)
            => RequestHandler.HandleRequestAsync(() => serviceProvider.GetRequiredService<IDeleteBookService>().HandlerAsync(id), logger);
    }
}
