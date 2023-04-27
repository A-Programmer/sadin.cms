namespace Sadin.Cms.Application.Common.Commands;
public interface ICommand<out TResult> : IRequest<TResult>
{
}
