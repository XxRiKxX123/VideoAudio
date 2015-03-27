using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initalizers
{
    public class AccountInitalizer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext AContext)
        {
            var List = new List<Account>
            {
                new Account {ID = 1,LastName ="Петров", MidleName = "Петрович", FirstName = "Петр", Email ="qqq", Password ="qqqqq"}
                
            };
            List.ForEach(s => AContext.Account.Add(s));

            var AccountsRoles = new List<Roles>
            {
                new Roles{RoleID=1, NameRoles="Admin"},
                new Roles{RoleID=2, NameRoles="User"}
            };
            AccountsRoles.ForEach(s => AContext.Roles.Add(s));
            AContext.SaveChanges();

        }
        
    }
}
