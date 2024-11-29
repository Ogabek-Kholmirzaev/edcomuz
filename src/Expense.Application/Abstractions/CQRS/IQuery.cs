using MediatR;

namespace Expense.Application.Abstractions.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}