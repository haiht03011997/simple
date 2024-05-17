using Application;
using Infrastructure;
using WebApi.Common.Mapping;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMappings();
builder.Services.AddApplication();
builder.Services.AddInfrastucture(builder.Configuration);
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("*") // Specify the allowed origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    // Add more policies if needed
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Apply CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
