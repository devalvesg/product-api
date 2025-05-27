using Application.Mappings;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddData(builder.Configuration);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<Api.Filters.ApiResponseWrapperFilter>();
});
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseMiddleware<Api.Middlewares.ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
