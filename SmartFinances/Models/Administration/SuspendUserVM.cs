using System.ComponentModel;

namespace SmartFinances.Models.Administration
{
    public class SuspendUserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [DisplayName("Suspension reason")]
        public string SuspensionReason { get; set; }
    }
}
