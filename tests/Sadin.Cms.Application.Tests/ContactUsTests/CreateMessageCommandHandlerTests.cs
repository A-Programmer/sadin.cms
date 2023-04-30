using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Sadin.Cms.Application.ContactUs.Commands.CreateMessage;
using Sadin.Cms.Domain.Abstractions;
using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Common.Exceptions.DomainExceptions;
using Xunit.Sdk;

namespace Sadin.Cms.Application.Tests.ContactUsTests;

public class CreateMessageCommandHandlerTests
{
    private readonly IContactMessagesRepository _contactMessagesRepositoryMock;
    private readonly IUnitOfWork _uowMock;

    public CreateMessageCommandHandlerTests()
    {
        _contactMessagesRepositoryMock = Substitute.For<IContactMessagesRepository>();
        _uowMock = Substitute.For<IUnitOfWork>();
    }
    
    [Fact]
    public async Task Handle_FullNameIsEmpty_ShouldReturnDomainNullArgumentException()
    {
        // Arrange
        CreateMessageCommand command = new(
            "",
            "mrsadin@gmail.com",
            "+989308638095", 
            "Hello", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        // Act
        var action = async () => await handler.Handle(command, default);

        // Assert
        await Assert.ThrowsAsync<DomainArgumentNullException>(action);
    }
    
    // [Fact]
    // public async Task Hendle
}