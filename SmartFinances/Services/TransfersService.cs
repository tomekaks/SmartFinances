using AutoMapper;
using MediatR;
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

        public async Task<TransfersVM> GetTransfers()
        {
            return new TransfersVM();
        }
    }
}
