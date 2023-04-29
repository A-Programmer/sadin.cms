namespace Sadin.Cms.Application.Common.Queries;
public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, Result<TResult>> where TQuery : IQuery<TResult>
{

}
