using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Roles> Roles { get; set; }

    }
}
