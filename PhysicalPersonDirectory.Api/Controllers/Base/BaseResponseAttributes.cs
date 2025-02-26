using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace PhysicalPersonDirectory.Api.Controllers.Base;

public class BaseResponseAttributesAttribute(params int[] statusCodes) : Attribute
{
    public int[] StatusCodes => statusCodes;
}

public class BaseResponseAttributesActionFilter : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        var attribute = action.Attributes
            .OfType<BaseResponseAttributesAttribute>()
            .FirstOrDefault();
            
        if (attribute == null)
            return;

        foreach (var statusCode in attribute.StatusCodes)
        {
            action.Filters.Add(new ProducesResponseTypeAttribute(typeof(int),statusCode));
        }
    }
}