using System.ComponentModel;

namespace SmartFinances.Models.Transfers
{
    public class NewContactVM
    {
        public string Name { get; set; }
        [DisplayName("Account number")]
        public string AccountNumber { get; set; }
    }
}
