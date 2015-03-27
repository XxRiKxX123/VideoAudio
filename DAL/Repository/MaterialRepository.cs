using DAL.Context;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class MaterialRepository
    {
        private readonly MaterialContext context = new MaterialContext();
        public IEnumerable<Material> Material
        {
            get { return context.Material; }
        }
        public bool AddMaterial(Material material)
        {
            context.Material.Add(material);
            context.SaveChanges();
            return true;
        }
        public bool MaterialEdit(Material material)
        {
            context.Entry(material).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return true;
        }
        public bool MaterialDelete(Material material)
        {
            context.Material.Remove(material);
            context.SaveChanges();
            return true;
        }
    }
}
