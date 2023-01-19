﻿using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Transfer.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Transfer.Handlers.Commands
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public CreateTransferCommandHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task<Unit> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = _transferFactory.CreateTransfer(request.TransferDto);
            await _unitOfWork.Transfers.AddAsync(transfer);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}