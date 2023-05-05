# Guide

## TODO:
- Adding Update process for ContactMessage, Command/Query Handlers, Validators, Repository methods, etc.
- Adding HTTPUpdate Method to the controller and test the flow.
- Adding GetAllMessages feature (Including ApplicationLater, Persistence Layer, Presentation Layer, Infrastructure Layer, etc.)
- Check all features of ContactUs and release this version.
- 

## Idempotent:  
Currently, we are using Polly to make sure that we will try to re-publish events if there was any issue/error while trying for the first time (We can try as many as times we need).  
But there is a question, what will happen to a chain of event handlers when we had a problem in the middle of processing published events?  
For example, when a user is registered we are raising and event and we have 2 event handlers to handle it, one for sending welcome email and one for adding user information to profile table in the database (This is just an example), and let's imagine after running SendWelcomeEmailHandler we fall in a problem and then AddUserProfileHandler does not run!  
Now, again the background job will run and processes the un finished events and again Welcome email will send to the user!  
With idempotent we will take care of this issue, in this scenario we will have another entity (Let's call it OutboxMessageConsumers) which will hold the event consumers (EventHandlers) and while we process the events, before running the event handler we check the OutboxMessageConsumer table to see if there is no consumer with this name, if there was, we will do nothing, if there wasn't we will run the event handler, then after running the event handler we will add this event handler to the OutboxMessageConsumer table to make sure next time, we don't run this event handler.  

## CQRS Unit Tests:
This part is not completed, I just added some test methods to check whether CreateContactMessageCommandHandler creates the new record, mostly, it is checking for null arguments.  
**TODO**  
1. Add new test methods to check whether DomainEvent is raised.
2. Add new test method to check whether EventHandler is handling the Event or not.
3. Add new test method to practice mocking (Repository, EventHandler, EmailSender, ...)  

## Unit of work
**Why do we use UnitOfWork?**  
If we try to use DbContext in our handlers so we will be dependent to the EFCore in the Application Layer, but we don't want to.  
So, we use UnitOfWork and inject it into the handlers, then we will have an instance of UnitOfWork, in the future if we decide to change the ORM or even the database, we wouldn't need to modify the Application Layer.  
Also, by using UnitOfWork we are not making repositories responsible for persisting data.  
When we use IUnitOfWork, we can easily mock it for unit tests.  


dotnet ef --startup-project src/Sadin.Cms.Api/Sadin.Cms.Api.csproj migrations add "AuditableProperties_Add" -p src/Sadin.Cms.Persistence/Sadin.Cms.Persistence.csproj