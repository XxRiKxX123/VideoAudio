using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MaterialModels
{
    public class MaterialEdit
    {
        public int ID { get; set; }
        [LocalizedDisplayName("Name", NameResourceType = typeof(Resx.Material))]
        public string Name { get; set; }
        [LocalizedDisplayName("NameFile", NameResourceType = typeof(Resx.Material))]
        public string NameFile { get; set; }
        [LocalizedDisplayName("SizeFile", NameResourceType = typeof(Resx.Material))]
        public int SizeFile { get; set; }
        [LocalizedDisplayName("Annotation", NameResourceType = typeof(Resx.Material))]
        public string Annotation { get; set; }
        [LocalizedDisplayName("Category", NameResourceType = typeof(Resx.Material))]
        public string Category { get; set; }
        [LocalizedDisplayName("Type", NameResourceType = typeof(Resx.Material))]
        public string Type { get; set; }
        public string AddedUser { get; set; }
        public MaterialEdit(int ID, string Name, string Annotation, string Category, string Type, int SizeFile, string NameFile)
        {
            this.ID = ID;
            this.Name = Name;
            this.NameFile = NameFile;
            this.SizeFile = SizeFile;
            this.Annotation = Annotation;
            this.Category = Category;
            this.Type = Type;
            this.AddedUser=AddedUser;
        }
        public MaterialEdit()
        {
            this.ID = ID;
            this.Name = Name;
            this.NameFile = NameFile;
            this.SizeFile = SizeFile;
            this.Annotation = Annotation;
            this.Category = Category;
            this.Type = Type;
            this.AddedUser=AddedUser;
        }
    }
}
