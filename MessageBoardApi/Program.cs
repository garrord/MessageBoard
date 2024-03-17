using Data.Contracts;
using Data.Managers;
using Data.QueyRepositories;
using Data.Repositories;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MessageBoardContext>(dbContextOptions => dbContextOptions
    .UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=MessageBoard;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddScoped<ITopicQueryRepository, TopicQueryRepository>();
builder.Services.AddScoped<ITopicQueryRepositoryManager, TopicQueryRepositoryManager>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<ITopicRepositoryManager, TopicRepositoryManager>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
