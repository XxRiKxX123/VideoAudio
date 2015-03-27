using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RegisterRepository
    {
        private readonly AccountContext Acontext = new AccountContext();
        public IEnumerable<DAL.Entity.Account> Account
        {
            get { return Acontext.Account; }
        }

        public bool RegAccount(DAL.Entity.Account account)
        {
            DAL.Entity.Roles role;
            role = account.Roles;
            Acontext.Account.Add(account);
            account.Roles = role;
            Acontext.Entry(account.Roles).State = System.Data.Entity.EntityState.Modified;
            Acontext.SaveChanges();
            return true;
        }
        public IEnumerable<DAL.Entity.Roles> RoleAccount
        {
            get { return Acontext.Roles; }
        }
         public bool ActivationAccount(Entity.Account account)
        {
            Acontext.Entry(account).State = System.Data.Entity.EntityState.Modified;
            Acontext.SaveChanges();
            return true;
        }
    }
}
