using Example.DB;
using Example.DB.Repository;
using Example.DB.Repository.Interfaces;
using Example.Services.BookServices;
using Example.Services.BookServices.Interfaces;
using Example.Services.BorrowingServices;
using Example.Services.BorrowingServices.Interfaces;
using Example.Services.ReminderServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<ExampleContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<ReminderService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>((serviceProvider) => new BorrowingRepository(serviceProvider.GetRequiredService<ExampleContext>(), configuration.GetSection("Values").GetValue<int>("RemindDueDays")));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddTransient<ICreateBookService, CreateBookService>();
builder.Services.AddTransient<IUpdateBookService, UpdateBookService>();
builder.Services.AddTransient<IGetBookService, GetBookService>();
builder.Services.AddTransient<IDeleteBookService, DeleteBookService>();

builder.Services.AddTransient<ICreateBorrowingService, CreateBorrowingService>();
builder.Services.AddTransient<IReturnBorrowingService, ReturnBorrowingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
