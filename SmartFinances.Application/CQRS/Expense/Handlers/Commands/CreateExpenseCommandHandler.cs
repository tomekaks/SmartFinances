using MediatR;
using SmartFinances.Application.CQRS.Expense.Requests.Commands;
using SmartFinances.Application.CQRS.Expense.Validators;
using SmartFinances.Application.Exeptions;
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
            var validator = new CreateExpenseCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationExeption(validationResult);
            }

            var expense = _expenseFactory.CreateExpense(request.ExpenseDto);
            await _unitOfWork.Expenses.AddAsync(expense);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
