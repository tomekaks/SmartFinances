using MediatR;
using SmartFinances.Application.CQRS.RegularExpense.Handlers.Validators;
using SmartFinances.Application.CQRS.RegularExpense.Requests.Commands;
using SmartFinances.Application.Exeptions;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.RegularExpense.Handlers.Commands
{
    public class UpdateRegularExpenseCommandHandler : IRequestHandler<UpdateRegularExpenseCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegularExpenseFactory _regularExpenseFactory;

        public UpdateRegularExpenseCommandHandler(IUnitOfWork unitOfWork, IRegularExpenseFactory regularExpenseFactory)
        {
            _unitOfWork = unitOfWork;
            _regularExpenseFactory = regularExpenseFactory;
        }

        public async Task<Unit> Handle(UpdateRegularExpenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRegularExpenseCommandValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationExeption(validationResult);
            }

            var regularExpense = await _unitOfWork.RegularExpenses.GetByIdAsync(request.RegularExpenseDto.Id);

            if (regularExpense != null)
            {
                regularExpense = _regularExpenseFactory.MapToModel(request.RegularExpenseDto, regularExpense);
                _unitOfWork.RegularExpenses.Update(regularExpense);
                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
