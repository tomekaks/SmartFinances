﻿using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.RegularExpense.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Handlers.Commands
{
    public class CreateRegularExpenseRequestHandler : IRequestHandler<CreateRegularExpenseRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegularExpenseFactory _regularExpenseFactory;

        public CreateRegularExpenseRequestHandler(IUnitOfWork unitOfWork, IRegularExpenseFactory regularExpenseFactory)
        {
            _unitOfWork = unitOfWork;
            _regularExpenseFactory = regularExpenseFactory;
        }

        public async Task<Unit> Handle(CreateRegularExpenseRequest request, CancellationToken cancellationToken)
        {
            var regularExpense = _regularExpenseFactory.CreateRegularExpense(request.RegularExpenseDto);
            await _unitOfWork.RegularExpenses.AddAsync(regularExpense);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
