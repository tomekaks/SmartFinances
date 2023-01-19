﻿using SmartFinances.Application.Dto.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto.TransferDtos
{
    public class TransferDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SendTime { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderAccountNumber { get; set; }
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public int AccountId { get; set; }
        public AccountDto AccountDto { get; set; }
        public string Title { get; set; }
    }
}
