namespace Sadin.Cms.Application.ContactUs.Queries.GetContactMessageById;

public record GetContactMessageByIdQuery(Guid Id) : IQuery<ContactMessageResponse>;