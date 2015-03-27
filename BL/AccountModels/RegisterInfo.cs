using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AccountModels
{
    public class RegisterInfo
    {
        public int ID { get; set; }
        [LocalizedDisplayName("LastName", NameResourceType = typeof(Resx.AccountsStrings))]
        public string LastName { get; set; }
        [LocalizedDisplayName("MidleName", NameResourceType = typeof(Resx.AccountsStrings))]
        public string MidleName { get; set; }
        [LocalizedDisplayName("FirstName", NameResourceType = typeof(Resx.AccountsStrings))]
        public string FirstName { get; set; }
        [LocalizedDisplayName("Login", NameResourceType = typeof(Resx.AccountsStrings))]
        public string Login { get; set; }
        [LocalizedDisplayName("Password", NameResourceType = typeof(Resx.AccountsStrings))]
        public string Password { get; set; }
        [LocalizedDisplayName("Email", NameResourceType = typeof(Resx.AccountsStrings))]
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }

    }
}
