using FluentValidation;
using Sadin.Cms.Domain.Aggregates.ContactUs.ValueObjects;

namespace Sadin.Cms.Application.ContactUs.Commands.CreateMessage;

public sealed class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .Custom((email, context) =>
            {
                if (!email.IsValidEmail())
                    context.AddFailure("Email address is not valid.");
            });
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(FullName.MaxLength);
        RuleFor(x => x.Subject)
            .NotEmpty()
            .MaximumLength(Subject.MaxLength);
        RuleFor(x => x.Content).NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .Custom((phoneNumber, context) =>
            {
                if (!phoneNumber.IsValidMobile())
                    context.AddFailure("Phone number is not valid.");
            });
    }
}