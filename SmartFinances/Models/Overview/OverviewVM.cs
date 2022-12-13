using System.ComponentModel;

namespace SmartFinances.Models.Overview
{
    public class OverviewVM
    {
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
