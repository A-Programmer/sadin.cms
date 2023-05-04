using FluentValidation;

namespace Sadin.Cms.Application.ContactUs.Commands.MarkMessageAsRead;

public sealed class MarkMessageAsReadCommandValidator : AbstractValidator<MarkMessageAsReadCommand>
{
    public MarkMessageAsReadCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}