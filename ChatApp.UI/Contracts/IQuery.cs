using System;
using MediatR;

namespace ChatApp.UI.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface IQuery : IRequest
    {
        Guid Id { get; }
    }
}
