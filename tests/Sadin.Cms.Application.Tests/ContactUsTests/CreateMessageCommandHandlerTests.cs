using System.Text;
using FluentAssertions;
using NSubstitute;
using Sadin.Cms.Application.ContactUs.Commands.CreateMessage;
using Sadin.Cms.Domain.Abstractions;
using Sadin.Cms.Domain.Aggregates.ContactUs;
using Sadin.Common.Exceptions.DomainExceptions;
using Sadin.Common.Result;

namespace Sadin.Cms.Application.Tests.ContactUsTests;

// TODO : Add domain event and event handlers tests
public class CreateMessageCommandHandlerTests
{
    private readonly IContactMessagesRepository _contactMessagesRepositoryMock;
    private readonly IUnitOfWork _uowMock;

    public CreateMessageCommandHandlerTests()
    {
        _contactMessagesRepositoryMock = Substitute
            .For<IContactMessagesRepository>();
        
        _uowMock = Substitute
            .For<IUnitOfWork>();
    }
    
    [Fact]
    public async Task Handle_FullNameIsEmpty_ShouldThrowDomainNullArgumentException()
    {
        CreateMessageCommand command = CreateCommand(
            "",
            "mrsadin@gmail.com",
            "+989308638095", 
            "Hello", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);

        await action.Should().ThrowAsync<DomainArgumentNullException>();
    }
    
    [Fact]
    public async Task Handle_EmailIsEmpty_ShouldThrowDomainNullArgumentException()
    {
        CreateMessageCommand command = CreateCommand(
            "Kamran Sadin",
            "",
            "+989308638095", 
            "Hello", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);

        await action.Should().ThrowAsync<DomainArgumentNullException>();
    }
    
    [Fact]
    public async Task Handle_EmailIsInvalid_ShouldThrowDomainArgumentInvalidException()
    {
        CreateMessageCommand command = CreateCommand(
            "Kamran Sadin",
            "InvalidEmail",
            "+989308638095", 
            "Hello", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);

        await action.Should().ThrowAsync<DomainValidationException>();
    }
    
    [Fact]
    public async Task Handle_PhoneNumberIsEmpty_ShouldNotThrowAnyException()
    {
        CreateMessageCommand command = CreateCommand(
            "Kamran Sadin",
            "mrsadin@gmail.com",
            "", 
            "Hello", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);
        
        await action.Should().NotThrowAsync<Exception>();
    }
    
    [Fact]
    public async Task Handle_SubjectIsEmpty_ShouldThrowDomainArgumentInvalidException()
    {
        CreateMessageCommand command = CreateCommand(
            "Kamran Sadin",
            "mrsadin@gmail.com",
            "+989308638095", 
            "", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);

        await action.Should().ThrowAsync<DomainArgumentNullException>();
    }
    
    [Fact]
    public async Task Handle_SubjectIsMoreThanMaxLength_ShouldThrowDomainArgumentInvalidException()
    {
        StringBuilder stringBuilder = new();
        for (int i = 0; i < 501; i++)
            stringBuilder.Append("A");
        CreateMessageCommand command = CreateCommand(
            "Kamran Sadin",
            "mrsadin@gmail.com",
            "+989308638095", 
            stringBuilder.ToString(), 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);

        await action.Should().ThrowAsync<DomainValidationException>();
    }
    
    [Fact]
    public async Task Handle_ContentIsEmpty_ShouldThrowDomainArgumentInvalidException()
    {
        CreateMessageCommand command = CreateCommand(
            "Kamran Sadin",
            "mrsadin@gmail.com",
            "+989308638095", 
            "Subject", 
            "");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        var action = async () => await handler.Handle(command, default);

        await action.Should().ThrowAsync<DomainArgumentNullException>();
    }

    [Fact]
    public async Task Handle_InputIsValid_ShouldSuccessResult()
    {
        CreateMessageCommand command = new(
            "Kamran Sadin",
            "mrsadin@gmail.com",
            "+989308638095", 
            "Hello", 
            "This is a test");
        CreateMessageCommandHandler handler = new(_contactMessagesRepositoryMock, _uowMock);
        
        Result result = await handler.Handle(command, default);
        
        result.IsSuccess.Should().BeTrue();
    }

    private static CreateMessageCommand CreateCommand(string fullName, string email, string phoneNumber, string subject,
        string content)
    {
        return new CreateMessageCommand(
            fullName,
            email,
            phoneNumber, 
            subject, 
            content);
    }
}