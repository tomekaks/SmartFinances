using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public List<ExpenseDto> Expenses { get; set; }
    }
}
