using Expense.API.Middlewares;
using Expense.Application;
using Expense.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowLocalHost",
        policyBuilder => policyBuilder
            .WithOrigins("https://localhost:7225")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureModule(builder.Configuration);
builder.Services.AddApplicationModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalHost");

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.UseInfrastructureModule();

app.Run();