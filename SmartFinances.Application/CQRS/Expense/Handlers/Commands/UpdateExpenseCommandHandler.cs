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
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseFactory _expenseFactory;

        public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IExpenseFactory expenseFactory)
        {
            _unitOfWork = unitOfWork;
            _expenseFactory = expenseFactory;
        }

        public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _unitOfWork.Expenses.GetByIdAsync(request.ExpenseDto.Id);
            expense = _expenseFactory.MapToModel(request.ExpenseDto, expense);

            _unitOfWork.Expenses.Update(expense);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
