﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Core.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<RegularExpense> RegularExpenses { get; set; }
    }
}
