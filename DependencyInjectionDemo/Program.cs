using DependencyInjectionDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// formatted output data
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();
builder.Services.AddTransient<OperationService>();
//builder.Services.AddScoped<OperationService>();
//builder.Services.AddSingleton<OperationService>();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
