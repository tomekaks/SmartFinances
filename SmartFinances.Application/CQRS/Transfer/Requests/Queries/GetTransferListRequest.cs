using MediatR;
using SmartFinances.Application.Dto.TransferDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Transfer.Requests.Queries
{
    public  class GetTransferListRequest : IRequest<List<TransferDto>>
    {
        public int AccountId { get; set; }
    }
}
