using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Domain.ErrorModel;
using System.Text.Json;

namespace Restaurants.API.ActionFilters;

public class ValidationFilterAttribute : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {

    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        var param = context.ActionArguments
            .SingleOrDefault(x => x.Value.ToString().Contains("Command")).Value;

        if (param is null)
        {
            context.Result = new BadRequestObjectResult(
                new ErrorDetails
                {
                    StatusCode = 400 ,
                    Message = $"Object is null. Controller: {controller}, action: {action}"
                }
            );
            return;
        }

        if (!context.ModelState.IsValid)
        {
            context.Result = new UnprocessableEntityObjectResult(
                new
                {
                    StatusCode = 422 ,
                    Message = context
                        .ModelState
                        .Where(ms => ms.Value.Errors.Any())
                        .ToDictionary(
                            ms => ms.Key ,
                            ms => ms.Value
                                    .Errors
                                    .Select(error => error.ErrorMessage)
                                    .ToArray()
                        )
                }
            );
        }
    }
}