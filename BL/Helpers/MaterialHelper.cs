using BL.MaterialModels;
using DAL.Entity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Helpers
{
    public class MaterialHelper
    {
        public bool AddMaterial(MaterialCreate material)
        {
            DAL.Entity.Material newMat = new DAL.Entity.Material { ID = material.ID, Name = material.Name, Annotation = material.Annotation, Category = material.Category,
                                                                   Type = material.Type, SizeFile = material.SizeFile, NameFile = material.NameFile };
            MaterialRepository repo = new MaterialRepository();
            repo.AddMaterial(newMat);
            return true;
        }
        public IEnumerable<MaterialInfo> GetMaterialList(int OrderBy = 0)
        {
            MaterialRepository repo = new MaterialRepository();
            IEnumerable<MaterialInfo> List = repo.Material.ToList().Select(w => new MaterialInfo(w.ID, w.Name, w.Annotation, w.Category, w.Type, w.SizeFile, w.NameFile));
            switch (OrderBy)
            {
                case 1:
                    return List.OrderBy(w => w.Name);
                case 2:
                    return List.OrderBy(w => w.NameFile);
                default:
                    return List;
            }
        }
        public IEnumerable<MaterialInfo> GetMaterialType(string type)
        {
            MaterialRepository repo = new MaterialRepository();
            List<Material> tMaterial = repo.Material.Where(b => b.Type == type).ToList();
            if (tMaterial.Count() > 0)
                return tMaterial.ToList().Select(w => new MaterialInfo(w.ID, w.Name, w.Annotation, w.Category, w.Type, w.SizeFile, w.NameFile));
            else
                return null;
        }
        public MaterialEdit GetEditList(string user,int id = 1)
        {
            MaterialRepository repo = new MaterialRepository();
            DAL.Entity.Material material = repo.Material.Where(w => w.ID == id).First();
            if(material.AddedUser == user)           
            return new BL.MaterialModels.MaterialEdit { ID = material.ID, Name = material.Name, Annotation = material.Annotation, Category = material.Category,
                                                        Type = material.Type, SizeFile = material.SizeFile, NameFile = material.NameFile, AddedUser=material.AddedUser};
            else
                return null;
   
        }
        public MaterialEdit GetAdminEditList(int id = 1)
        {
            MaterialRepository repo = new MaterialRepository();
            DAL.Entity.Material material = repo.Material.Where(w => w.ID == id).First();
            return new BL.MaterialModels.MaterialEdit {ID = material.ID, Name = material.Name, Annotation = material.Annotation, Category = material.Category,
                                                       Type = material.Type, SizeFile = material.SizeFile, NameFile = material.NameFile};

        }
        public bool MaterialEdit(MaterialEdit material)
        {
            DAL.Entity.Material edit = new DAL.Entity.Material { ID = material.ID, Name = material.Name, Annotation = material.Annotation, Category = material.Category,
                                                                 Type = material.Type, SizeFile = material.SizeFile, NameFile = material.NameFile };
            MaterialRepository repo = new MaterialRepository();
            repo.MaterialEdit(edit);
            return true;
        }
        public MaterialDelete GetDeleteList(int id = 1)
        {
            MaterialRepository repo = new MaterialRepository();
            DAL.Entity.Material material = repo.Material.Where(w => w.ID == id).First();
            return new BL.MaterialModels.MaterialDelete(material.ID, material.Name, material.Annotation, material.Category, material.Type, material.SizeFile, material.NameFile);
        }

        public bool MaterialDelete(int id)
        {
            MaterialRepository repo = new MaterialRepository();
            DAL.Entity.Material material = repo.Material.Where(w => w.ID == id).First();
            repo.MaterialDelete(material);
            return true;
        }
        public IEnumerable<MaterialInfo> GetMaterialSearch(char search)
        {
            MaterialRepository repo = new MaterialRepository();
            List<Material> SMaterial = repo.Material.Where(b => b.Name[0] == search).ToList();
            if (SMaterial.Count() > 0)
                return SMaterial.ToList().Select(w => new MaterialInfo(w.ID, w.Name, w.Annotation, w.Category, w.Type, w.SizeFile, w.NameFile));
            else
                return null;
        }
    }
}
