using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using BL.AccountModels;
using DAL.Entity;

namespace BL.Helpers
{
   public class RolesHelper
    {
       public bool UserRoles(string login)
       {
           RegisterRepository repo = new RegisterRepository();
           List<Account> role = repo.Account.Where(b => b.Login == login && b.Roles.NameRoles == "Admin").ToList();
           if (role.Count() > 0)
               return true;
           else
               return false;

       }
       public DAL.Entity.Roles RoleUser()
       {
           DAL.Repository.RegisterRepository repo = new DAL.Repository.RegisterRepository();
           DAL.Entity.Roles roleuser = repo.RoleAccount.Where(u => u.RoleID == 2).FirstOrDefault();
           return new DAL.Entity.Roles(roleuser.RoleID, roleuser.NameRoles);
       }

    }
}
