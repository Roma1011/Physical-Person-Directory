using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PhysicalPersonDirectory.Api.Controllers.Base;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;
using PhysicalPersonDirectory.Core.UseCases.Services.Promises;

namespace PhysicalPersonDirectory.Api.Controllers;

[Route(BasePath + "/person")]
public class PersonController(IPersonService personService):BaseController
{
    
    [HttpGet(nameof(SearchPerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> SearchPerson([FromQuery][Required] int id)
    {
        return Ok();
    }

    [HttpGet(nameof(GetPersonById))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> GetPersonById([FromQuery][Required] int id)
    {
        return Ok();
    }
    
    [HttpPost(nameof(AddPerson))]
    [BaseResponseAttributes(201,400,404,409)]
    public async Task<IActionResult> AddPerson([FromBody]AddPerson person)
    {
        var serviceResponse=await personService.AddPersonAsync(person);
        return serviceResponse.StatusCode == 201 ? Created() : BadRequest(serviceResponse);
    }
    
    [HttpPost(nameof(AddRelationPerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> AddRelationPerson(AddRelationPerson relationPerson)
    {
        await personService.AddRelationPersonAsync(relationPerson);
        return Ok();
    }
    
    [HttpPost(nameof(RemoveRelationPerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> RemoveRelationPerson([FromQuery][Required] int id)
    {
        return Ok();
    }
    
    [HttpPost(nameof(AppendPhoto))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> AppendPhoto(AppendImage appendImage)
    {
        var serviceResponse=await personService.AppendPhotoAsync(appendImage);
        return serviceResponse.StatusCode == 200 ? Ok(serviceResponse) : BadRequest(serviceResponse);
    }
    
    [HttpPut(nameof(UpdatePerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> UpdatePerson(UpdatePerson person)
    {
        var serviceResponse=await personService.UpdatePersonAsync(person);
        return serviceResponse.StatusCode == 201 ? Ok(serviceResponse) : BadRequest(serviceResponse);
    }
    
    [HttpDelete(nameof(DeletePerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> DeletePerson([FromQuery][Required] int id)
    {
        return Ok();
    }
}