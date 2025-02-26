using PhysicalPersonDirectory.Api.Controllers.Base;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers(controllers =>
{
    controllers.Conventions.Add(new BaseResponseAttributesActionFilter());
});
builder.Services.AddSwaggerGen();

var app=builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthentication();
app.MapControllers();
app.Run();