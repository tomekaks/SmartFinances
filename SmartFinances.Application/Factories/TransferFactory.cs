using AutoMapper;
using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Factories
{
    public class TransferFactory : ITransferFactory
    {
        private readonly IMapper _mapper;

        public TransferFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Transfer CreateTransfer(TransferDto transferDto)
        {
            return _mapper.Map<Transfer>(transferDto);
        }

        public TransferDto CreateTransferDto(Transfer transfer)
        {
            return _mapper.Map<TransferDto>(transfer);
        }

        public List<TransferDto> CreateTransferDtoList(List<Transfer> transfers)
        {
            return _mapper.Map<List<TransferDto>>(transfers);
        }

        public Transfer MapToModel(TransferDto transferDto, Transfer model)
        {
            return _mapper.Map(transferDto, model);
        }
    }
}
