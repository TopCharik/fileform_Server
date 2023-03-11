using FileForm.Api.Extensions;
using FileForm.Api.Helpers;
using FileForm.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Client", p =>
    {
        p.WithOrigins(builder.Configuration["ClientUrl"])
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddBlobService(
    builder.Configuration["AzureStorageConnectionString"],
    builder.Configuration["AzureStorageContainerName"]
);
builder.Services.AddScoped<FormMapper>();

var app = builder.Build();

app.UseCors("Client");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseMiddleware<ExceptionMiddleware>();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
