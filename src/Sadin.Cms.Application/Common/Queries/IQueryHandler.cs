﻿namespace Sadin.Cms.Application.Common.Queries;
public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{

}
