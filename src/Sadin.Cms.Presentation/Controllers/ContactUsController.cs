using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sadin.Cms.Application.ContactUs.Commands.CreateMessage;
using Sadin.Cms.Application.ContactUs.Commands.DeleteMessage;
using Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsRead;
using Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsUnread;
using Sadin.Cms.Application.ContactUs.Queries.GetAllContactMessages;
using Sadin.Cms.Application.ContactUs.Queries.GetContactMessageById;
using Sadin.Cms.Presentation.Constants;
using Sadin.Cms.Presentation.ViewModels;
using Sadin.Cms.Presentation.ViewModels.ContactUs;
using Sadin.Common.Pagination;
using Sadin.Common.Result;

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
    [ProducesResponseType(typeof(Result<GetContactMessageByIdResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult) ,(int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        GetContactMessageByIdQuery query = new(id);
        var result = await Sender.Send(query, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet]
    [Route(Routes.ContactUs.Get.GetAll)]
    [ProducesResponseType(typeof(Result<PaginatedList<GetAllContactMessagesResponse>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestResult) ,(int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get(
        [FromQuery] PaginationViewModel paginationViewModel,
        [FromQuery] SearchingViewModel searchingViewModel,
        [FromQuery] OrderingViewModel orderingViewModel,
        CancellationToken cancellationToken = default)
    {
        GetAllContactMessagesQuery query = new(
            paginationViewModel.PageIndex,
            paginationViewModel.PageSize,
            searchingViewModel.SearchTerm ?? String.Empty,
            orderingViewModel.OrderByPropertyName ?? "Id",
            orderingViewModel.Descending);
        
        var result = await Sender.Send(query, cancellationToken);
        
        return result.IsSuccess
            ? CustomPagedOk(result.Value,
                result.PageIndex,
                result.TotalPages,
                result.TotalItems,
                result.ShowPagination)
            : BadRequest(result.Error);
    }

    [HttpPost]
    [Route(Routes.ContactUs.Post.Add)]
    [ProducesResponseType(typeof(Result<CreateMessageCommandResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails) ,(int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post(CreateContactMessageViewModel viewModel, CancellationToken cancellationToken)
    {
        CreateMessageCommand command = new(viewModel.FullName, viewModel.Email, viewModel.PhoneNumber,
            viewModel.Subject, viewModel.Content);
        
        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpPut]
    [Route(Routes.ContactUs.Edit.MarkAsRead)]
    [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> MarkAsRead(Guid id, CancellationToken cancellationToken)
    {
        MarkMessageAsReadCommand command = new(id);

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : HandleFailure(result);
    }
    
    [HttpPut]
    [Route(Routes.ContactUs.Edit.MarkAsUnread)]
    [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> MarkAsUnread(Guid id, CancellationToken cancellationToken)
    {
        MarkMessageAsUnreadCommand command = new(id);
    
        var result = await Sender.Send(command, cancellationToken);
    
        return result.IsSuccess ? Ok(result) : HandleFailure(result);
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