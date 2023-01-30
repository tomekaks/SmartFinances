using System.ComponentModel;

namespace SmartFinances.Models.Transfers
{
    public class NewTransferVM
    {
        [DisplayName("Receiver's name")]
        public string ReceiverName { get; set; }
        [DisplayName("Receiver's account number")]
        public string ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
    }
}
