using MediatR;
using SmartFinances.Application.CQRS.Expense.Requests.Commands;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Expense.Handlers.Commands
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseFactory _expenseFactory;

        public CreateExpenseCommandHandler(IUnitOfWork unitOfWork, IExpenseFactory expenseFactory)
        {
            _unitOfWork = unitOfWork;
            _expenseFactory = expenseFactory;
        }

        public async Task<Unit> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = _expenseFactory.CreateExpense(request.ExpenseDto);
            await _unitOfWork.Expenses.AddAsync(expense);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
