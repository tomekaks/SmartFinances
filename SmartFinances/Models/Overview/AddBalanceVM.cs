using System.ComponentModel.DataAnnotations;

namespace SmartFinances.Models.Overview
{
    public class AddBalanceVM
    {
        [Range(1, 1000000)]
        public decimal Balance { get; set; }
    }
}
