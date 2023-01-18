﻿using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Transfer.Requests.Queries;
using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Transfer.Handlers.Queries
{
    public class GetTransferListRequestHandler : IRequestHandler<GetTransferListRequest, List<TransferDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransferFactory _transferFactory;

        public GetTransferListRequestHandler(IUnitOfWork unitOfWork, ITransferFactory transferFactory)
        {
            _unitOfWork = unitOfWork;
            _transferFactory = transferFactory;
        }

        public async Task<List<TransferDto>> Handle(GetTransferListRequest request, CancellationToken cancellationToken)
        {
            var transferList = await _unitOfWork.Transfers.GetAllAsync(q => q.SenderId == request.AccountId || 
                                                                            q.ReceiverId == request.AccountId);
            return _transferFactory.CreateTransferDtoList(transferList.ToList());
        }
    }
}
