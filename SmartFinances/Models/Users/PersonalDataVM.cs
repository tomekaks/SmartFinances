using System.ComponentModel;

namespace SmartFinances.Models.Users
{
    public class PersonalDataVM
    {
        [DisplayName("User name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
    }
}
