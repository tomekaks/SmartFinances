namespace SmartFinances.Models.Transfers
{
    public class NewTransferVM
    {
        public string ReceiverName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
    }
}
