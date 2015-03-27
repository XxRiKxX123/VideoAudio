using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class MaterialContext : DbContext
    {
        public DbSet<Material> Material { get; set; }
    }
}
