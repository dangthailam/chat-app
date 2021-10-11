using System;
using MediatR;

namespace ChatApp.UI.Contracts
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface ICommand: IRequest
    {
        Guid Id { get; }
    }
}
