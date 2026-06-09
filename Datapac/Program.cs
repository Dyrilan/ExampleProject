using Example.Database;
using Example.Database.Repository;
using Example.Database.Repository.Interfaces;
using Example.DB.Repository.Interfaces;
using Example.Services.BookServices;
using Example.Services.BookServices.Interfaces;
using Example.Services.BorrowingServices;
using Example.Services.BorrowingServices.Interfaces;
using Example.Services.ReminderServices;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<ExampleContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<ReminderService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICreateBookService, CreateBookService>();
builder.Services.AddScoped<IUpdateBookService, UpdateBookService>();
builder.Services.AddScoped<IGetBookService, GetBookService>();
builder.Services.AddScoped<IDeleteBookService, DeleteBookService>();

builder.Services.AddScoped<ICreateBorrowingService, CreateBorrowingService>();
builder.Services.AddScoped<IReturnBorrowingService, ReturnBorrowingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
