using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.MaterialModels
{
    public class MaterialDelete
    {

        public int ID;
        public string Name;
        public string NameFile;
        public string Annotation;
        public string Category;
        public string Type;
        public int SizeFile;
        public MaterialDelete(int ID, string Name, string Annotation, string Category, string Type, int SizeFile, string NameFile)
        {
            this.ID = ID;
            this.Name = Name;
            this.NameFile = NameFile;
            this.SizeFile = SizeFile;
            this.Annotation = Annotation;
            this.Category = Category;
            this.Type = Type;
        }
    }
}
