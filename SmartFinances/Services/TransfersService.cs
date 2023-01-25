using AutoMapper;
using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Queries;
using SmartFinances.Application.CQRS.Contact.Requests.Commands;
using SmartFinances.Application.CQRS.Contact.Requests.Queries;
using SmartFinances.Application.CQRS.Transfer.Requests.Commands;
using SmartFinances.Application.CQRS.Transfer.Requests.Queries;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.ContactDtos;
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

        public async Task CreateNewContact(NewContactVM model, string userId)
        {
            var contactDto = _mapper.Map<ContactDto>(model);
            contactDto.UserId = userId;

            await _mediator.Send(new CreateContactCommand { ContactDto = contactDto });
        }

        public async Task CreateNewTransfer(NewTransferVM model, string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var receiverAccount = await _mediator.Send(new GetAccountByNumberRequest { AccountNumber = model.ReceiverAccountNumber });

            var transfer = _mapper.Map<OutgoingTransferDto>(model);
            transfer.SendTime = DateTime.Today;
            transfer.AccountId = accountDto.Id;

            await _mediator.Send(new CreateTransferCommand { TransferDto = transfer });
        }

        public Task DeleteContact(int id)
        {
            return _mediator.Send(new DeleteContactCommand { Id = id });
        }

        public async Task EditContact(EditContactVM model)
        {
            var contactDto = _mapper.Map<ContactDto>(model);
            await _mediator.Send(new UpdateContactCommand { ContactDto = contactDto });
        }

        public async Task<EditContactVM> GetContact(int id)
        {
            var contactDto = await _mediator.Send(new GetContactRequest { Id = id });
            return _mapper.Map<EditContactVM>(contactDto);
        }

        public async Task<ContactsVM> GetContactList(string userId)
        {
            var contacts = await _mediator.Send(new GetContactListRequest { UserId = userId });

            return new ContactsVM()
            {
                Contacts = contacts
            };
        }

        public async Task<TransfersVM> GetTransfers(string userId)
        {
            var accountDto = await GetAccountDtoAsync(userId);
            var outgoingTransfers = await _mediator.Send(new GetOutgoingTransfersRequest { AccountId = accountDto.Id });
            var incomingTransfers = await _mediator.Send(new GetIncomingTransfersRequest { AccountNumber = accountDto.Number });

            return new TransfersVM { OutgoingTransfers = outgoingTransfers, IncomingTransfers = incomingTransfers };
        }

        public async Task<NewTransferVM> UseContact(int id)
        {
            var contact = await _mediator.Send(new GetContactRequest { Id = id });

            return new NewTransferVM()
            {
                ReceiverName = contact.Name,
                ReceiverAccountNumber = contact.AccountNumber
            };
        }

        private async Task<AccountDto> GetAccountDtoAsync(string userId)
        {
            return await _mediator.Send(new GetAccountRequest { UserId = userId });
        }
    }
}
