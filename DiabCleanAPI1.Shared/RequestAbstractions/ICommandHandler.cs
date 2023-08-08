using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabCleanAPI.Shared.RequestAbstractions
{
    public interface ICommandHandler<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
        where TIn : ICommand<TOut> { }
}
