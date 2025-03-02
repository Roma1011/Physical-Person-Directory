using Microsoft.AspNetCore.Mvc;
using PhysicalPersonDirectory.Api.Controllers.Base;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;

namespace PhysicalPersonDirectory.Api.Controllers;

[Route(BasePath+"/city")]
public class CityController(ICityService cityService):BaseController
{
    [HttpPost(nameof(AddCity))]
    [BaseResponseAttributes(200,400,404,409)]
    public async Task<IActionResult> AddCity([FromQuery]string cityName)
    {
        var serviceResponse=await cityService.AddCityAsync(cityName);
        return serviceResponse.IsSuccess ? Ok(serviceResponse) : BadRequest(serviceResponse);
    }
}