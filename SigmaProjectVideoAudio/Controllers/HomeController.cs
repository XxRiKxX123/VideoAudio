using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoAudio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string type, char search = ' ', int OrderBy = 0)
        {
            BL.Helpers.MaterialHelper helper = new BL.Helpers.MaterialHelper();
            if (search == ' ')
            {
                if (type == null)
                {
                    IEnumerable<BL.MaterialModels.MaterialInfo> Material = helper.GetMaterialList(OrderBy);
                    return View(Material);
                }
                else
                {
                    IEnumerable<BL.MaterialModels.MaterialInfo> MaterialType = helper.GetMaterialType(type);
                    return View(MaterialType);
                }
            }
            else
            {
                IEnumerable<BL.MaterialModels.MaterialInfo> result = helper.GetMaterialSearch(search);
                return View(result);
            }

        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(BL.MaterialModels.MaterialInfo search)
        {
            return RedirectToAction("Index", "Home", search);
        }
    }
}
