using Microsoft.AspNetCore.Mvc;

namespace PhysicalPersonDirectory.Api.Controllers.Base;

[ApiController]
[Route(BasePath+"/[controller]" )]
public abstract class BaseController:ControllerBase
{
    protected const string BasePath = "PhysicalPersonDirectory";
}