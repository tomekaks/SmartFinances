using System.ComponentModel.DataAnnotations;

namespace SmartFinances.Models.Overview
{
    public class UpdateBalanceVM
    {
        public int Id { get; set; }
        [Range(1, 1000000)]
        public decimal Balance { get; set; }
    }
}
