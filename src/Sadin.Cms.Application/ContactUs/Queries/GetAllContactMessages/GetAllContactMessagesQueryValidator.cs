using FluentValidation;

namespace Sadin.Cms.Application.ContactUs.Queries.GetAllContactMessages;

public sealed class GetAllContactMessagesQueryValidator : AbstractValidator<GetPaginatedContactMessagesQuery>
{
    public GetAllContactMessagesQueryValidator()
    {
        
    }
}