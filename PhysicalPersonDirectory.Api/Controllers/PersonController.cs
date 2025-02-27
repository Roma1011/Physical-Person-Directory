using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PhysicalPersonDirectory.Api.Controllers.Base;
using PhysicalPersonDirectory.Core.UseCases.DTOs.Request;

namespace PhysicalPersonDirectory.Api.Controllers;

[Route(BasePath + "/person")]
public class PersonController:BaseController
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
    
    [HttpPut(nameof(UpdatePerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> UpdatePerson([FromQuery][Required] int id)
    {
        return Ok();
    }
    
    [HttpPost(nameof(AddPerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> AddPerson([FromBody]AddPerson person)
    {
        return Ok();
    }
    
    [HttpPost(nameof(AddRelationPerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> AddRelationPerson([FromQuery][Required] int id)
    {
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
    public async Task<IActionResult> AppendPhoto([FromQuery][Required] int id)
    {
        return Ok();
    }
    
    
    [HttpDelete(nameof(DeletePerson))]
    [BaseResponseAttributes(200,400,404)]
    public async Task<IActionResult> DeletePerson([FromQuery][Required] int id)
    {
        return Ok();
    }
}