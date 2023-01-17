using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.CQRS.Expense.Requests.Commands;
using SmartFinances.Application.CQRS.Expense.Requests.Queries;
using SmartFinances.Application.CQRS.RegularExpense.Requests.Commands;
using SmartFinances.Application.CQRS.RegularExpense.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.ExpenseDtos;
using SmartFinances.Application.Dto.RegularExpenseDtos;
using SmartFinances.Interfaces;
using SmartFinances.Models.BudgetPlanner;

namespace SmartFinances.Services
{
    public class BudgetPlannerService : IBudgetPlannerService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BudgetPlannerService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //Expenses

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

        public async Task<ExpensesVM> GetExpensesListAsync(string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);

            var expenseDtoList = await _mediator.Send(new GetExpenseListRequest { AccountId = accountDto.Id });
            var model = new ExpensesVM { Expenses = expenseDtoList, Budget = accountDto.Budget };
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


        //RegularExpenses

        public async Task<RegularExpensesVM> GetRegularExpensesListAsync(string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var regularExpensesDto = await _mediator.Send(new GetRegularExpenseListRequest { AccountId = accountDto.Id });

            return new RegularExpensesVM { RegularExpenses = regularExpensesDto };
        }

        public async Task CreateRegularExpenseAsync(CreateRegularExpenseVM model, string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(model);

            regularExpenseDto.AccountId = accountDto.Id;

            await _mediator.Send(new CreateRegularExpenseRequest { RegularExpenseDto = regularExpenseDto });
        }

        public async Task<EditExpenseVM> GenerateEditRegularExpenseVMAsync(int id)
        {
            var regularExpense = await _mediator.Send(new GetRegularExpenseRequest { Id = id });
            return _mapper.Map<EditExpenseVM>(regularExpense);
        }

        public async Task EditRegularExpenseAsync(EditExpenseVM model)
        {
            var regularExpenseDto = _mapper.Map<RegularExpenseDto>(model);
            await _mediator.Send(new UpdateRegularExpenseRequest { RegularExpenseDto = regularExpenseDto });
        }

        public async Task DeleteRegularExpenseAsync(int id)
        {
            await _mediator.Send(new DeleteRegularExpenseRequest { Id = id });
        }

        public async Task AddRegularExpenseAsync(int id)
        {
            var regularExpenseDto = await _mediator.Send(new GetRegularExpenseRequest { Id = id });
            var expenseDto = _mapper.Map<ExpenseDto>(regularExpenseDto);
            expenseDto.Date = DateTime.Today;

            await _mediator.Send(new CreateExpenseCommand { ExpenseDto = expenseDto });
        }

        public async Task SetBudget(SetBudgetVM model, string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);

            var updateAccountDto = new UpdateAccountDto()
            {
                Id = accountDto.Id,
                Balance = accountDto.Balance,
                Budget = model.Budget
            };

            await _mediator.Send(new UpdateAccountCommand { AccountDto = updateAccountDto });
        }
    }
}
