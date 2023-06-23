# Guide

## Running on docker:
If you want to run the docker file you should be in the Cms directory at the command line and then run the `docker build -t mrsadin./cms -f src/Dockerfile .` command. Don't forget the . at the end of the command.  
If you want to run with docker compose you should be at the same directory and run the `docker compose up` command.  

## TODO:
src/Sadin.Cms.Application/ContactUs/Events/**ContactMessageCreatedEventPublisher.cs**
- A : Currently, I am using simplest way to publish events, please refactor and improve considering these items:
  - 1. Currently, it is working like fire and forget, it doesn't have any retry policy.
  - 2. Is it possible to implement idempotency for these kind of events same as DomainEvents?  
- B : Check if I could use another Message Bus like Kafka instead of RabbitMQ (Of course, I don't need to change the Message Bus but it's better to see how it would be hard to change the Message Bus).  
- C : Is it possible to make the publisher better? Like having an interface or abstract class for subscribe/unsubscribe and inherit from them?
- D : Use logger instead of using Console.WriteLine.  
- 




## Idempotent:  
Currently, we are using Polly to make sure that we will try to re-publish events if there was any issue/error while trying for the first time (We can try as many as times we need).  
But there is a question, what will happen to a chain of event handlers when we had a problem in the middle of processing published events?  
For example, when a user is registered we are raising and event and we have 2 event handlers to handle it, one for sending welcome email and one for adding user information to profile table in the database (This is just an example), and let's imagine after running SendWelcomeEmailHandler we fall in a problem and then AddUserProfileHandler does not run!  
Now, again the background job will run and processes the un finished events and again Welcome email will send to the user!  
With idempotent we will take care of this issue, in this scenario we will have another entity (Let's call it OutboxMessageConsumers) which will hold the event consumers (EventHandlers) and while we process the events, before running the event handler we check the OutboxMessageConsumer table to see if there is no consumer with this name, if there was, we will do nothing, if there wasn't we will run the event handler, then after running the event handler we will add this event handler to the OutboxMessageConsumer table to make sure next time, we don't run this event handler.  

## CQRS Unit Tests:
This part is not completed, I just added some test methods to check whether CreateContatcMessageCommandHandler creates the new record, mostly, it is checking for null arguments.  
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


dotnet ef --startup-project src/Sadin.Cms.Api/Sadin.Cms.Api.csproj migrations add "AnnouncementsEntity_Add" -p src/Sadin.Cms.Persistence/Sadin.Cms.Persistence.csproj