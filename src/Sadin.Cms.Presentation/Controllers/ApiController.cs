using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sadin.Cms.Presentation.Constants;
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
    protected ActionResult CustomError(Error error)
    {
        return BadRequest(Result.Failure(error));
    }
}