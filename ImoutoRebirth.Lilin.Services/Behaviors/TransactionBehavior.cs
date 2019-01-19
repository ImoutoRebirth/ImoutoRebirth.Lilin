﻿using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ImoutoRebirth.Lilin.Core.Infrastructure;
using MediatR;

namespace ImoutoRebirth.Lilin.Services.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            using (await _unitOfWork.CreateTransaction(IsolationLevel.ReadCommitted))
            {
                var response = await next();

                _unitOfWork.CommitTransaction();
                return response;
            }
        }
    }
}