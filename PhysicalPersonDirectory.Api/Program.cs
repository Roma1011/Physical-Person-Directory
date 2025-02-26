var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app=builder.Build();

app.UseRouting();

app.UseAuthentication();
app.MapControllers();
app.Run();