namespace Sadin.Cms.Application.Common.Queries;

public interface IQuery<TResult> : IRequest<Result<TResult>>
{
}