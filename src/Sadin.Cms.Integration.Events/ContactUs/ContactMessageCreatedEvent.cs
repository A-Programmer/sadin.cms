using Sadin.Common.Abstractions;

namespace Sadin.Cms.Integration.Events.ContactUs;

public record ContactMessageCreatedEvent(string FullName, string Email) : IntegrationEvent;