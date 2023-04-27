using Microsoft.AspNetCore.Mvc;

namespace Sadin.Cms.Presentation.Controllers;

/// <summary>
/// Represents ContactUs controller.
/// </summary>
public sealed class ContactUsController : ApiController
{
    // TODO: Use pattern like my old projects,
    // There I had PublicBaseController and
    // SecureBaseController
    
    /// <summary>
    /// Gets the ContactMessage with the specific identifier, if it exists.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The ContactMessage with the specific identifier, if it exists.</returns>
    [HttpGet("id")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        // GetContactMessageByIdQuery query = new(id);
        // var result = await Sender.Send(query);
        // return Ok(result);
        // TODO: complete implementation
        return Ok("");
    }
}