using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sadin.Cms.Presentation.Constants;
using Sadin.Common.Abstractions;
using Sadin.Common.Errors;
using Sadin.Common.Result;

namespace Sadin.Cms.Presentation.Controllers;

[ApiController]
[Route(Routes.BaseRootAddress)]
public class ApiController : ControllerBase
{
    public readonly ISender Sender;

    public ApiController(ISender sender)
    {
        Sender = sender;
    }

    [NonAction]
    protected IActionResult HandleFailure(Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult =>
                BadRequest(
                    CreateProblemDetails(
                        "Validation Error",
                        StatusCodes.Status400BadRequest,
                        result.Error,
                        validationResult.Errors)),
            _ => BadRequest(
                CreateProblemDetails(
                    "Bad Request",
                    StatusCodes.Status400BadRequest,
                    result.Error))
        };
    
    [NonAction]
    protected ActionResult CustomError(Error error)
    {
        return BadRequest(Result.Failure(error));
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int statusCode,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Status = statusCode,
            Detail = error.Message,
            Extensions = { { nameof(errors), errors } }
        };
}