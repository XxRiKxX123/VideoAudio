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
    public class MaterialInitalizer : DropCreateDatabaseIfModelChanges<MaterialContext>
    {
        protected override void Seed(MaterialContext context)
        {
            var material = new List<Material>
            {
                new Material {ID = 1, Name= "Люди в черном", Annotation= "Американская фантастическая комедия 1997 года режиссёра Барри Зонненфельда.", Category="Кинокомедия", Type="Фильм", NameFile="Film123.mp4", SizeFile=600},
                new Material {ID = 2, Name= "Я Свободен", Annotation="Культовая рок-баллада. Музыка написана вокалистом Валерием Кипеловым", Category="Heavy metal", Type="Музыка", NameFile="Music.mp4", SizeFile=34},
                new Material {ID = 3, Name= "Смокинг", Annotation= "Фантастическая комедия режиссёра Кевина Донована.", Category="Кинокомедия", Type="Фильм", NameFile="Film123.mp4", SizeFile=700},
                new Material {ID = 4, Name= "Природа", Annotation= "Красивый вид на заходящее солнце", Category="Фотоматериал", Type="Фото", NameFile="Foto.mp4", SizeFile=2},
                
            };
            material.ForEach(s => context.Material.Add(s));
            context.SaveChanges();
        }
    }
}
