using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}
