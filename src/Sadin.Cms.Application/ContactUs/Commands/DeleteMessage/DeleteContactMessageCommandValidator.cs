using FluentValidation;

namespace Sadin.Cms.Application.ContactUs.Commands.DeleteMessage;

public sealed class DeleteContactMessageCommandValidator : AbstractValidator<DeleteContactMessageCommand>
{
    public DeleteContactMessageCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}