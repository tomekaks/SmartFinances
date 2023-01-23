using SmartFinances.Application.Dto.TransferDtos;

namespace SmartFinances.Models.Transfers
{
    public class TransfersVM
    {
        public List<OutgoingTransferDto> OutgoingTransfers { get; set; }
        public List<IncomingTransferDto> IncomingTransfers { get; set; }
    }
}
