using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sadin.Cms.Application.ContactUs.Commands.CreateMessage;
using Sadin.Cms.Application.ContactUs.Commands.DeleteMessage;
using Sadin.Cms.Application.ContactUs.Queries.GetContactMessageById;
using Sadin.Cms.Presentation.Constants;
using Sadin.Cms.Presentation.ViewModels.ContactUs;

namespace Sadin.Cms.Presentation.Controllers;

/// <summary>
/// Represents ContactUs controller.
/// </summary>
public sealed class ContactUsController : ApiController
{
    // TODO: Use pattern like my old projects,
    // There I had PublicBaseController and
    // SecureBaseController
    
    public ContactUsController(ISender sender) : base(sender)
    {
    }
    
    /// <summary>
    /// Gets the ContactMessage with the specific identifier, if it exists.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The ContactMessage with the specific identifier, if it exists.</returns>
    [HttpGet()]
    [Route(Routes.ContactUs.Get.GetById)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        GetContactMessageByIdQuery query = new(id);
        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost()]
    [Route(Routes.ContactUs.Post.Add)]
    public async Task<IActionResult> Post(CreateContactMessageViewModel viewModel, CancellationToken cancellationToken)
    {
        CreateMessageCommand command = new(viewModel.FullName, viewModel.Email, viewModel.PhoneNumber,
            viewModel.Subject, viewModel.Content);
        
        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpDelete()]
    [Route(Routes.ContactUs.Delete.Remove)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        DeleteContactMessageCommand command = new(id);
        
        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
}