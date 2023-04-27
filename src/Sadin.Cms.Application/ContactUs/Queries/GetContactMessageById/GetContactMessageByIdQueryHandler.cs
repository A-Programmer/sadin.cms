using System.Data;

namespace Sadin.Cms.Application.ContactUs.Queries.GetContactMessageById;

public sealed class GetContactMessageByIdQueryHandler : IQueryHandler<GetContactMessageByIdQuery, ContactMessageResponse>
{
    private readonly IDbConnection _dbConnection;
    public GetContactMessageByIdQueryHandler(IDbConnection dbConnection) =>
        _dbConnection = dbConnection;
    
    public async Task<ContactMessageResponse> Handle(
        GetContactMessageByIdQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        // const string sql = @"SELECT * FROM ""ContactMessages"" WHERE ""Id"" = @MessageId";
        // ContactMessageResponse message = await
        //         _dbConnection.QueryFirstOrDefaultAsync<ContactMessageResponse>(
        //             sql,
        //             new { request.Id });
        //     if (message is null)
        //     {
        //         throw new DomainEntityNotFoundException(request.Id);
        //     }
        // return message;
    }
}