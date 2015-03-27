using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class Material
    {
        [Key]
        public int ID {get; set;}
        public string Name {get; set;}
        public string NameFile {get; set;}
        public int SizeFile { get; set; }
        public string Annotation {get; set;}
        public string Category {get; set;}
        public string Type{get; set;}
        public string AddedUser { get; set; }
    }
}
