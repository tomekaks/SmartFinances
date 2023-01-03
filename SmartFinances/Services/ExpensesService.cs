using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Expense.Requests.Commands;
using SmartFinances.Application.CQRS.Expense.Requests.Queries;
using SmartFinances.Application.Dto;
using SmartFinances.Interfaces;
using SmartFinances.Models.Expenses;

namespace SmartFinances.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ExpensesService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task AddExpenseAsync(AddExpenseVM model)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(model);
            expenseDto.Date = DateTime.Today;
            await _mediator.Send(new CreateExpenseCommand { ExpenseDto = expenseDto });
        }

        public async Task<ExpensesVM> GetExpensesListAsync()
        {
            var expenseDtoList = await _mediator.Send(new GetExpenseListRequest());
            var model = new ExpensesVM { Expenses = expenseDtoList };
            return model;
        }
    }
}
