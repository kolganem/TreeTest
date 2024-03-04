using System.Text.Json.Serialization;
using StoreProject.Infrastructure;
using TreeWebAPI;
using TreeWebAPI.Infrastructure;
using TreeWebAPI.Infrastructure.Middleware;
using TreeWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TreeDbContext>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITreeNodeRepository, TreeNodeRepository>();
builder.Services.AddScoped<IErrorRecordRepository, ErrorRecordRepository>();

builder.Services.AddScoped<IErrorRecordService, ErrorRecordService>();
builder.Services.AddScoped<ITreeNodeService, TreeNodeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Seed();

app.Run();