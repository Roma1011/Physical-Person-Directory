using PhysicalPersonDirectory.Api.Controllers.Base;
using PhysicalPersonDirectory.Api.Middlewares;
using PhysicalPersonDirectory.Api.SwaggerOptions;
using PhysicalPersonDirectory.Core;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers(controllers =>
{
    controllers.Conventions.Add(new BaseResponseAttributesActionFilter());
});
builder.Services.AddSwaggerGen(swagGen =>
{
    swagGen.OperationFilter<AddAcceptLanguageHeaderFilter>();
    swagGen.EnableAnnotations();
});
builder.Services.AddCore();

var app=builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseAuthentication();
app.UseMiddleware<AcceptLanguageMiddleware>();
app.MapControllers();
app.Run();