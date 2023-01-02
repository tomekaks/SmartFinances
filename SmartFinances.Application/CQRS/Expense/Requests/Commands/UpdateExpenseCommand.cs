using MediatR;
using SmartFinances.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Expense.Requests.Commands
{
    public class UpdateExpenseCommand : IRequest
    {
        public ExpenseDto ExpenseDto{ get; set; }
    }
}
