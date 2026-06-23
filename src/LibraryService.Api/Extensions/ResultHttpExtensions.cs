using Microsoft.AspNetCore.Mvc;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Extensions;
public static class ResultHttpExtensions
{
    public static IResult ToHttpResult(this Result result) => result.IsSuccess ? Results.NoContent() : Results.Problem(result.Error, statusCode: result.StatusCode);
    public static IResult ToHttpResult<T>(this Result<T> result) => result.IsSuccess ? Results.Ok(result) : Results.Problem(result.Error, statusCode: result.StatusCode);
    public static IResult ToCreatedResult<T>(this Result<T> result, string routeName, object? routeValues) => result.IsSuccess ? Results.CreatedAtRoute(routeName, routeValues, result.Value) : Results.Problem(result.Error, statusCode: result.StatusCode);
    public static ActionResult ToActionResult(this Result result) => result.IsSuccess ? new NoContentResult() : new ObjectResult(new { error = result.Error })
    {
        StatusCode = result.StatusCode
    };
    public static ActionResult<T> ToActionResult<T>(this Result<T> result) => result.IsSuccess ? new OkObjectResult(result.Value) : new ObjectResult(new { error = result.Error })
    {
        StatusCode = result.StatusCode
    };
    public static ActionResult<T> ToCreatedActionResult<T>(this Result<T> result, string routeName, object? routeValues) => result.IsSuccess ? new CreatedAtRouteResult(routeName, routeValues, result.Value) : new ObjectResult(new { error = result.Error })
    {
        StatusCode = result.StatusCode
    };
}