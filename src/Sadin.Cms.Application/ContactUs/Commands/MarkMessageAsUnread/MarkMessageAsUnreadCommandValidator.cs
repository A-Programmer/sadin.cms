using FluentValidation;

namespace Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsUnread;

public sealed class MarkMessageAsUnreadCommandValidator : AbstractValidator<MarkMessageAsUnreadCommand>
{
    public MarkMessageAsUnreadCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}