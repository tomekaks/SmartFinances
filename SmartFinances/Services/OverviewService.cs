using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.Dto;
using SmartFinances.Interfaces;
using SmartFinances.Models.Overview;

namespace SmartFinances.Services
{
    public class OverviewService : IOverviewService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OverviewService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task AddFundsAsync(AddFundsVM model, string userId)
        {
            var accountDto = await GetAccountAsync(userId);
            accountDto.Balance += model.Balance;

            await _mediator.Send(new UpdateAccountCommand { AccountDto = accountDto});
        }

        public async Task<AddFundsVM> GenerateAddFundsViewAsync(string userId)
        {
            var accountDto = await GetAccountAsync(userId);
            return _mapper.Map<AddFundsVM>(accountDto);
        }

        public async Task<OverviewVM> GenerateOverviewAsync(string userId)
        {
            var account = await _mediator.Send(new GetAccountRequest { UserId = userId });
            return _mapper.Map<OverviewVM>(account);
        }

        public async Task<AccountDto> GetAccountAsync(string userId)
        {
            return await _mediator.Send(new GetAccountRequest { UserId = userId });
        }
    }
}
