using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface ITransferFactory
    {
        Transfer CreateTransfer(TransferDto transferDto);
        TransferDto CreateTransferDto(Transfer transfer);
        Transfer MapToModel(TransferDto transferDto, Transfer model);
        List<TransferDto> CreateTransferDtoList(List<Transfer> transfers);
    }
}
