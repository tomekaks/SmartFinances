using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.CQRS.Expense.Requests.Commands;
using SmartFinances.Application.CQRS.Expense.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.ExpenseDtos;
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

        public async Task AddExpenseAsync(AddExpenseVM model, string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var expenseDto = _mapper.Map<ExpenseDto>(model);

            expenseDto.Date = DateTime.Today;
            expenseDto.AccountId = accountDto.Id;
            await _mediator.Send(new CreateExpenseCommand { ExpenseDto = expenseDto });

            //var updateAccountDto = new UpdateAccountDto 
            //{ Id = accountDto.Id, 
            //  Balance = accountDto.Balance - expenseDto.Amount
            //};

            //await _mediator.Send(new UpdateAccountCommand { AccountDto = updateAccountDto });
        }

        public async Task<ExpensesVM> GetExpensesListAsync(string userId, bool regular)
        {
            var accountDto = await GetAccountDtoAsync(userId);

            var expenseDtoList = await _mediator.Send(new GetExpenseListRequest { AccountId = accountDto.Id, Regular = regular});
            var model = new ExpensesVM { Expenses = expenseDtoList };
            return model;
        }

        public async Task<AccountDto> GetAccountDtoAsync(string userId)
        {
            return await _mediator.Send(new GetAccountRequest { UserId = userId });
        }

        public async Task<EditExpenseVM> GenerateEditExpenseVMAsync(int id)
        {
            var expenseDto = await _mediator.Send(new GetExpenseRequest { Id = id });
            return _mapper.Map<EditExpenseVM>(expenseDto);
        }

        public async Task EditExpenseAsync(EditExpenseVM model, string userId)
        {
            var expenseDto = _mapper.Map<EditExpenseDto>(model);

            await _mediator.Send(new UpdateExpenseCommand { ExpenseDto = expenseDto});
        }

        public async Task DeleteExpenseAsync(int id)
        {
            await _mediator.Send(new DeleteExpenseCommand { Id = id });
        }

        public Task AddRegularExpenseAsync(AddExpenseVM model, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
