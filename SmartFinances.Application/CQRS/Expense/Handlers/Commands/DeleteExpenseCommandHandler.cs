﻿using MediatR;
using SmartFinances.Application.CQRS.Expense.Requests.Commands;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Expense.Handlers.Commands
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _unitOfWork.Expenses.GetAsync(q => q.Id == request.Id);
            _unitOfWork.Expenses.Delete(expense);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
