using CSharpApp.Core.Shared;
using MediatR;

namespace CSharpApp.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse>: IRequestHandler<TQuery, Result<TResponse>> where TQuery: IQuery<TResponse> {}
