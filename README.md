# Guid

## Idempotent:  
Currently, we are using Polly to make sure that we will try to re-publish events if there was any issue/error while trying for the first time (We can try as many as times we need).  
But there is a question, what will happen to a chain of event handlers when we had a problem in the middle of processing published events?  
For example, when a user is registered we are raising and event and we have 2 event handlers to handle it, one for sending welcome email and one for adding user information to profile table in the database (This is just an example), and let's imagine after running SendWelcomeEmailHandler we fall in a problem and then AddUserProfileHandler does not run!  
Now, again the background job will run and processes the un finished events and again Welcome email will send to the user!  
With idempotent we will take care of this issue, in this scenario we will have another entity (Let's call it OutboxMessageConsumers) which will hold the event consumers (EventHandlers) and while we process the events, before running the event handler we check the OutboxMessageConsumer table to see if there is no consumer with this name, if there was, we will do nothing, if there wasn't we will run the event handler, then after running the event handler we will add this event handler to the OutboxMessageConsumer table to make sure next time, we don't run this event handler.  

## CQRS Unit Tests:


dotnet ef --startup-project src/Sadin.Cms.Api/Sadin.Cms.Api.csproj migrations add "Message" -p src/Sadin.Cms.Persistence/Sadin.Cms.Persistence.csproj