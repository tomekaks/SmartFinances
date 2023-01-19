using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.CQRS.Transfer.Requests.Commands;
using SmartFinances.Application.CQRS.Transfer.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Interfaces;
using SmartFinances.Models.Transfers;

namespace SmartFinances.Services
{
    public class TransfersService : ITransfersService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TransfersService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task CreateNewTransfer(NewTransferVM model, string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var receiverAccount = await _mediator.Send(new GetAccountByNumberRequest { AccountNumber = model.ReceiverAccountNumber });

            var transfer = _mapper.Map<TransferDto>(model);
            transfer.SendTime = DateTime.Today;
            transfer.AccountId = accountDto.Id;

            await _mediator.Send(new CreateTransferCommand { TransferDto = transfer });
        }

        public async Task<TransfersVM> GetTransfers(string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var transfers = await _mediator.Send(new GetTransferListRequest { AccountId = accountDto.Id });

            return new TransfersVM { Transfers = transfers };
        }

        private async Task<AccountDto> GetAccountDtoAsync(string userId)
        {
            return await _mediator.Send(new GetAccountRequest { UserId = userId });
        }
    }
}
