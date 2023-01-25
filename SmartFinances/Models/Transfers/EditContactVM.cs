using System.ComponentModel;

namespace SmartFinances.Models.Transfers
{
    public class EditContactVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Account number")]
        public string AccountNumber { get; set; }
    }
}
