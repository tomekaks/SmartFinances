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

        public async Task UpdateBalanceAsync(UpdateBalanceVM model)
        {
            var accountDto = _mapper.Map<AccountDto>(model);
            await _mediator.Send(new UpdateAccountCommand { AccountDto = accountDto});
        }

        public async Task<OverviewVM> GenerateOverviewAsync()
        {
            var account = await _mediator.Send(new GetAccountRequest { Id = 2 });
            return _mapper.Map<OverviewVM>(account);
        }

        public async Task<UpdateBalanceVM> GetAccountAsync()
        {
            var accountDto = await _mediator.Send(new GetAccountRequest { Id = 2 });
            return _mapper.Map<UpdateBalanceVM>(accountDto);
        }
    }
}
