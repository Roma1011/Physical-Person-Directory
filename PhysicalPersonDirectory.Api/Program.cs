using PhysicalPersonDirectory.Api.Controllers.Base;
using PhysicalPersonDirectory.Core;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers(controllers =>
{
    controllers.Conventions.Add(new BaseResponseAttributesActionFilter());
});
builder.Services.AddSwaggerGen(swagGen =>
{
    swagGen.EnableAnnotations();
});
builder.Services.AddCore();

var app=builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthentication();
app.MapControllers();
app.Run();