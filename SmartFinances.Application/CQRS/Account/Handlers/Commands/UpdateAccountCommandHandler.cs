using MediatR;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.CQRS.Account.Validators;
using SmartFinances.Application.Exeptions;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Handlers.Commands
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAccountCommandHandler(IAccountFactory accountFactory, IUnitOfWork unitOfWork)
        {
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAccountCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationExeption(validationResult);
            }

            var account = await _unitOfWork.Accounts.GetAsync(q => q.Id == request.AccountDto.Id);
            account = _accountFactory.MapToModel(request.AccountDto, account);

            _unitOfWork.Accounts.Update(account);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
